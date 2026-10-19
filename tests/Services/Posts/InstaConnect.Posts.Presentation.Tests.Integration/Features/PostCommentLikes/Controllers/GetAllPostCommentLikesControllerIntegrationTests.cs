using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostCommentLikes.Controllers;

public class GetAllPostCommentLikesControllerIntegrationTests : BasePostCommentLikePresentationQueryIntegrationTest
{
	private readonly GetAllPostCommentLikesApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentLikesApiRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentLikesApiRequest _request;

	public GetAllPostCommentLikesControllerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
	}

	[Theory]
	[PostIdNullWithMessageData]
	[PostIdEmptyWithMessageData]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentIdNullWithMessageData]
	[PostCommentIdEmptyWithMessageData]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForCommentIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserNameTooLongWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenUserNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserName(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForUserNameAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentLikesSortOrderEmptyWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForSortOrderAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentLikesSortTermEmptyWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenSortTermIsInvalid(
		IEnumTransformer<PostCommentLikesSortTerm> transformer, IEnumMessageTransformer<PostCommentLikesSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForSortTermAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentLikePageTooSmallWithMessageData]
	[PostCommentLikePageTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForPageAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentLikePageSizeTooSmallWithMessageData]
	[PostCommentLikePageSizeTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForPageSizeAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Controller.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Controller.ShouldThrowPostCommentNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndUserNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserName(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[PostCommentLikesSortOrderAscendingData]
	[PostCommentLikesSortOrderDescendingData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[PostCommentLikesSortTermCreatedAtData]
	[PostCommentLikesSortTermUserNameData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostCommentLikesSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, PostComment, PostCommentLikes);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostComment, PostCommentLikes);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostComment, PostCommentLikes);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndUserNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserName(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostComment, PostCommentLikes);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostComment, PostCommentLikes);
	}

	[Theory]
	[PostCommentLikesSortOrderWithAscendingTermData]
	[PostCommentLikesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostCommentLike> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostComment, PostCommentLikes, termTransformer);
	}

	[Theory]
	[PostCommentLikesSortTermWithCreatedAtTermData]
	[PostCommentLikesSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostCommentLikesSortTerm> transformer, ISortEnumTermTransformer<PostCommentLike> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, PostComment, PostCommentLikes, termTransformer);
	}
}
