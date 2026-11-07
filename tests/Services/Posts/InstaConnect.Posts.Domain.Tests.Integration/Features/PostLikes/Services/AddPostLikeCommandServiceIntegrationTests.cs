using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostLikes.Services;

public class AddPostLikeCommandServiceIntegrationTests : BasePostLikeDomainCommandIntegrationTest
{
	private readonly AddPostLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostLikeCommandBuilder _commandBuilder;
	private readonly AddPostLikeCommand _command;

	public AddPostLikeCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Post, User);
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(PostLike, CancellationToken);

		// Assert
		await Service.ShouldThrowPostLikeAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostLike, CancellationToken);
		var command = _commandBuilder.WithId(transformer).Build();

		// Assert
		await Service.ShouldThrowPostLikeAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExistsAndUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostLike, CancellationToken);
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Assert
		await Service.ShouldThrowPostLikeAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, postLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postLike);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostLike_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postLike.ShouldSatisfy(_command);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostLike_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postLike.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostLike_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postLike.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, postLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postLike);
	}
}
