using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Page;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.PageSize;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.Posts.Controllers;

public class GetAllPostsControllerIntegrationTests : BasePostPresentationQueryIntegrationTest
{
	private readonly GetAllPostsApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostsApiRequestBuilder _requestBuilder;
	private readonly GetAllPostsApiRequest _request;

	public GetAllPostsControllerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
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
	[PostTitleTooLongWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenTitleIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForTitleAsync(
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
	[PostsSortOrderEmptyWithMessageData]
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
	[PostsSortTermEmptyWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenSortTermIsInvalid(
		IEnumTransformer<PostsSortTerm> transformer, IEnumMessageTransformer<PostsSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForSortTermAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostPageTooSmallWithMessageData]
	[PostPageTooLargeWithMessageData]
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
	[PostPageSizeTooSmallWithMessageData]
	[PostPageSizeTooLargeWithMessageData]
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
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.GetAllAsync(_request, CancellationToken);

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
	[PostTitleNullData]
	[PostTitleEmptyData]
	[PostTitleDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndTitleAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

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
	[PostsSortOrderAscendingData]
	[PostsSortOrderDescendingData]
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
	[PostsSortTermCreatedAtData]
	[PostsSortTermTitleData]
	[PostsSortTermUserNameData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostsSortTerm> transformer)
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
		response.ShouldSatisfy(_request, Posts);
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
		response.ShouldSatisfy(request, Posts);
	}

	[Theory]
	[PostTitleNullData]
	[PostTitleEmptyData]
	[PostTitleDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndTitleAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Posts);
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
		response.ShouldSatisfy(request, Posts);
	}

	[Theory]
	[PostsSortOrderWithAscendingTermData]
	[PostsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Posts, termTransformer);
	}

	[Theory]
	[PostsSortTermWithCreatedAtTermData]
	[PostsSortTermWithTitleTermData]
	[PostsSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostsSortTerm> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Posts, termTransformer);
	}
}
