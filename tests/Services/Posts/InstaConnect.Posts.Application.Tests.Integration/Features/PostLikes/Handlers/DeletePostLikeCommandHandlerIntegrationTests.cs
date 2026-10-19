namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Handlers;

public class DeletePostLikeCommandHandlerIntegrationTests : BasePostLikeApplicationCommandIntegrationTest
{
	private readonly DeletePostLikeCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostLikeCommandRequestBuilder _requestBuilder;
	private readonly DeletePostLikeCommandRequest _request;

	public DeletePostLikeCommandHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostLike);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostLike, CancellationToken);
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
			messageTransformer, request, CancellationToken);
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
	public async Task SendAsync_ShouldThrowPostLikeNotFoundException_WhenPostLikeNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostLike, CancellationToken);

		// Assert
		await Sender.ShouldThrowPostLikeNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeletePostLike_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		postLike.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldDeletePostLike_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		postLike.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeletePostLike_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		postLike.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, PostLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, PostLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, PostLike);
	}
}
