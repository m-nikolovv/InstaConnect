using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Endpoints;

public class GetAllPostLikesForUserFunctionalTests : BasePostLikePresentationQueryFunctionalTest
{
	private readonly GetAllPostLikesForUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostLikesForUserApiRequestBuilder _requestBuilder;
	private readonly GetAllPostLikesForUserApiRequest _request;

	public GetAllPostLikesForUserFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostLike);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserId(request, messageTransformer);
	}

	[Theory]
	[UserIdTooLongData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(request, messageTransformer);
	}

	[Theory]
	[PostLikesSortOrderEmptyData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostLikesSortOrderEmptyWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortOrder(request, messageTransformer);
	}

	[Theory]
	[PostLikesForUserSortTermEmptyData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
		IEnumTransformer<PostLikesForUserSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostLikesForUserSortTermEmptyWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
		IEnumTransformer<PostLikesForUserSortTerm> transformer, IEnumMessageTransformer<PostLikesForUserSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortTerm(request, messageTransformer);
	}

	[Theory]
	[PostLikePageTooSmallData]
	[PostLikePageTooLargeData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostLikePageTooSmallWithMessageData]
	[PostLikePageTooLargeWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPage(request, messageTransformer);
	}

	[Theory]
	[PostLikePageSizeTooSmallData]
	[PostLikePageSizeTooLargeData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostLikePageSizeTooSmallWithMessageData]
	[PostLikePageSizeTooLargeWithMessageData]
	public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPageSize(request, messageTransformer);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await LikeApiClient.GetAllForUserProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostLikesSortOrderAscendingData]
	[PostLikesSortOrderDescendingData]
	public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostLikesForUserSortTermCreatedAtData]
	[PostLikesForUserSortTermUserNameData]
	public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostLikesForUserSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await LikeApiClient.GetAllForUserAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User, PostLikes);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User, PostLikes);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User, PostLikes);
	}

	[Theory]
	[PostLikesSortOrderWithAscendingTermData]
	[PostLikesSortOrderWithDescendingTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostLike> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User, PostLikes, termTransformer);
	}

	[Theory]
	[PostLikesForUserSortTermWithCreatedAtTermData]
	[PostLikesForUserSortTermWithUserNameTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostLikesForUserSortTerm> transformer, ISortEnumTermTransformer<PostLike> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await LikeApiClient.GetAllForUserAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User, PostLikes, termTransformer);
	}
}
