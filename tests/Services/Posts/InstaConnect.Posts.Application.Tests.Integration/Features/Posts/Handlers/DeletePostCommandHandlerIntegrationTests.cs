using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Handlers;

public class DeletePostCommandHandlerIntegrationTests : BasePostApplicationCommandIntegrationTest
{
	private readonly DeletePostCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostCommandRequestBuilder _requestBuilder;
	private readonly DeletePostCommandRequest _request;

	public DeletePostCommandHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
	}

	[Theory]
	[PostIdNullWithMessageData]
	[PostIdEmptyWithMessageData]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForUserIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Sender.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowPostForbiddenException_WhenPostForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithUserId(user.Id).Build();

		// Assert
		await Sender.ShouldThrowPostForbiddenExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeletePost_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldDeletePost_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeletePost_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishPostDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, Post);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, Post);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostDeletedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, Post);
	}
}
