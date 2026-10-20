using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Endpoints;

public class GetAllChatMessagesFunctionalTests : BaseChatMessagePresentationQueryFunctionalTest
{
	private readonly GetAllChatMessagesApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllChatMessagesApiRequestBuilder _requestBuilder;
	private readonly GetAllChatMessagesApiRequest _request;

	private readonly GetAllChatMessagesApiRequestBuilder _invertedRequestBuilder;
	private readonly GetAllChatMessagesApiRequest _invertedRequest;

	public GetAllChatMessagesFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage);
		_request = _requestBuilder.Build();

		_invertedRequestBuilder = _requestBuilderFactory.Create(ChatMessage).WithCurrentUserId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedRequest = _invertedRequestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ApiClient.GetAllUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantTwoId(request, messageTransformer);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(request, messageTransformer);
	}

	[Theory]
	[ChatMessagesSortOrderEmptyData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessagesSortOrderEmptyWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer,
		IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await ApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortOrder(request, messageTransformer);
	}

	[Theory]
	[ChatMessagesSortTermEmptyData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
		IEnumTransformer<ChatMessagesSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessagesSortTermEmptyWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
		IEnumTransformer<ChatMessagesSortTerm> transformer,
		IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await ApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortTerm(request, messageTransformer);
	}

	[Theory]
	[ChatMessagePageTooSmallData]
	[ChatMessagePageTooLargeData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessagePageTooSmallWithMessageData]
	[ChatMessagePageTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await ApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPage(request, messageTransformer);
	}

	[Theory]
	[ChatMessagePageSizeTooSmallData]
	[ChatMessagePageSizeTooLargeData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessagePageSizeTooSmallWithMessageData]
	[ChatMessagePageSizeTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await ApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPageSize(request, messageTransformer);
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveNotFoundStatusCode_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessagesSortOrderAscendingData]
	[ChatMessagesSortOrderDescendingData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessagesSortTermCreatedAtData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Chat, ChatMessages);
	}

	[Theory]
	[ChatMessagesSortOrderWithAscendingTermData]
	[ChatMessagesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await ApiClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Chat, ChatMessages, termTransformer);
	}

	[Theory]
	[ChatMessagesSortTermWithCreatedAtTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await ApiClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Chat, ChatMessages, termTransformer);
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessagesSortOrderAscendingData]
	[ChatMessagesSortOrderDescendingData]
	public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessagesSortTermCreatedAtData]
	public async Task GetAllAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await ApiClient.GetAllStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.GetAllAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedRequest, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, Chat, ChatMessages);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await ApiClient.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, Chat, ChatMessages);
	}

	[Theory]
	[ChatMessagesSortOrderWithAscendingTermData]
	[ChatMessagesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await ApiClient.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, Chat, ChatMessages, termTransformer);
	}

	[Theory]
	[ChatMessagesSortTermWithCreatedAtTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatMessagesSortTerm> transformer, ISortEnumTermTransformer<ChatMessage> termTransformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await ApiClient.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, Chat, ChatMessages, termTransformer);
	}
}
