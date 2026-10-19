using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Handlers;

public class GetAllFollowsForFollowingQueryHandlerIntegrationTests : BaseFollowApplicationQueryIntegrationTest
{
	private readonly GetAllFollowsForFollowingQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllFollowsForFollowingQueryRequestBuilder _requestBuilder;
	private readonly GetAllFollowsForFollowingQueryRequest _request;

	public GetAllFollowsForFollowingQueryHandlerIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follow);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Follows, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForFollowingIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserNameTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenFollowerNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerName(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForFollowerNameAsync(
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

	[Theory]
	[FollowsSortOrderEmptyWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForSortOrderAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[FollowsForFollowingSortTermEmptyWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenSortTermIsInvalid(
		IEnumTransformer<FollowsForFollowingSortTerm> transformer, IEnumMessageTransformer<FollowsForFollowingSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForSortTermAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[FollowPageTooSmallWithMessageData]
	[FollowPageTooLargeWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForPageAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[FollowPageSizeTooSmallWithMessageData]
	[FollowPageSizeTooLargeWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForPageSizeAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowFollowingNotFoundException_WhenFollowingNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Following, CancellationToken);

		// Assert
		await Sender.ShouldThrowFollowingNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Following, Follows);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Following, Follows);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndFollowerNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerName(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Following, Follows);
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
		response.ShouldSatisfy(request, Following, Follows);
	}

	[Theory]
	[FollowsSortOrderWithAscendingTermData]
	[FollowsSortOrderWithDescendingTermData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Follow> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Following, Follows, termTransformer);
	}

	[Theory]
	[FollowsForFollowingSortTermWithCreatedAtTermData]
	[FollowsForFollowingSortTermWithFollowerNameTermData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<FollowsForFollowingSortTerm> transformer, ISortEnumTermTransformer<Follow> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Following, Follows, termTransformer);
	}
}
