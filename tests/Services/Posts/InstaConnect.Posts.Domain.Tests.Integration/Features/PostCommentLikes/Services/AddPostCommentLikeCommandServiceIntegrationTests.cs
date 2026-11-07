using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostCommentLikes.Services;

public class AddPostCommentLikeCommandServiceIntegrationTests : BasePostCommentLikeDomainCommandIntegrationTest
{
	private readonly AddPostCommentLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostCommentLikeCommandBuilder _commandBuilder;
	private readonly AddPostCommentLikeCommand _command;

	public AddPostCommentLikeCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostComment, User);
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
	public async Task AddAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
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
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var command = _commandBuilder.WithId(transformer).Build();

		// Assert
		await Service.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndCommentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Assert
		await Service.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Assert
		await Service.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, postCommentLike);
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
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postCommentLike);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postCommentLike);
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
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postCommentLike);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(_command);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(command);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, postCommentLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postCommentLike);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postCommentLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postCommentLike);
	}
}
