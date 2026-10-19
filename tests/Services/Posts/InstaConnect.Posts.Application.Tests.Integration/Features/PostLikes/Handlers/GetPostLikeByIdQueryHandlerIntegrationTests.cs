namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Handlers;

public class GetPostLikeByIdQueryHandlerIntegrationTests : BasePostLikeApplicationQueryIntegrationTest
{
	private readonly GetPostLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostLikeByIdQueryRequestBuilder _requestBuilder;
	private readonly GetPostLikeByIdQueryRequest _request;

	public GetPostLikeByIdQueryHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
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
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, PostLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostLike);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostLike);
	}
}
