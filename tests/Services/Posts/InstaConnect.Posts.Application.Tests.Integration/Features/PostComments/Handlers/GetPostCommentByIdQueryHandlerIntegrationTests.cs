namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Handlers;

public class GetPostCommentByIdQueryHandlerIntegrationTests : BasePostCommentApplicationQueryIntegrationTest
{
	private readonly GetPostCommentByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostCommentByIdQueryRequestBuilder _requestBuilder;
	private readonly GetPostCommentByIdQueryRequest _request;

	public GetPostCommentByIdQueryHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostComment, CancellationToken);
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
	[PostCommentIdNullWithMessageData]
	[PostCommentIdEmptyWithMessageData]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForCommentIdAsync(
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
	public async Task SendAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Sender.ShouldThrowPostCommentNotFoundExceptionAsync(_request, CancellationToken);
	}


	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, PostComment);
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
		response.ShouldSatisfy(request, PostComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostComment);
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
		response.ShouldSatisfy(request, PostComment);
	}
}
