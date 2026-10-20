using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.Chats.Controllers;

public class GetAllChatsControllerIntegrationTests : BaseChatPresentationQueryIntegrationTest
{
	private readonly GetAllChatsApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllChatsApiRequestBuilder _requestBuilder;
	private readonly GetAllChatsApiRequest _request;

	private readonly GetAllChatsApiRequestBuilder _invertedRequestBuilder;
	private readonly GetAllChatsApiRequest _invertedRequest;

	public GetAllChatsControllerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_invertedRequestBuilder = _requestBuilderFactory.Create(Chat).WithCurrentUserId(ParticipantTwoId).WithParticipantTwoName(ParticipantOne.Name);
		_invertedRequest = _invertedRequestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
	}

	[Theory]
	[UserNameTooLongWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenParticipantTwoNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForParticipantTwoNameAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
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
	[ChatsSortOrderEmptyWithMessageData]
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
	[ChatsSortTermEmptyWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenSortTermIsInvalid(
		IEnumTransformer<ChatsSortTerm> transformer, IEnumMessageTransformer<ChatsSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForSortTermAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[ChatPageTooSmallWithMessageData]
	[ChatPageTooLargeWithMessageData]
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
	[ChatPageSizeTooSmallWithMessageData]
	[ChatPageSizeTooLargeWithMessageData]
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
	public async Task GetAllAsync_ShouldThrowParticipantOneNotFoundException_WhenParticipantOneNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantOne, CancellationToken);

		// Assert
		await Controller.ShouldThrowParticipantOneNotFoundExceptionAsync(_request, CancellationToken);
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
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
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
	[ChatsSortOrderAscendingData]
	[ChatsSortOrderDescendingData]
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
	[ChatsSortTermCreatedAtData]
	[ChatsSortTermParticipantTwoNameData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatsSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnInvertedOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.GetAllAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedOkStatusCode_WhenRequestAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[ChatsSortOrderAscendingData]
	[ChatsSortOrderDescendingData]
	public async Task GetAllAsync_ShouldReturnInvertedOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[ChatsSortTermCreatedAtData]
	[ChatsSortTermParticipantTwoNameData]
	public async Task GetAllAsync_ShouldReturnInvertedOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatsSortTerm> transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, ParticipantOne, Chats);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, ParticipantOne, Chats);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, ParticipantOne, Chats);
	}

	[Theory]
	[ChatsSortOrderWithAscendingTermData]
	[ChatsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, ParticipantOne, Chats, termTransformer);
	}

	[Theory]
	[ChatsSortTermWithCreatedAtTermData]
	[ChatsSortTermWithParticipantTwoNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, ParticipantOne, Chats, termTransformer);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.GetAllAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedRequest, ParticipantTwo, Chats);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoName(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, ParticipantTwo, Chats);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, ParticipantTwo, Chats);
	}

	[Theory]
	[ChatsSortOrderWithAscendingTermData]
	[ChatsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, ParticipantTwo, Chats, termTransformer);
	}

	[Theory]
	[ChatsSortTermWithCreatedAtTermData]
	[ChatsSortTermWithParticipantTwoNameTermData]
	public async Task GetAllAsync_ShouldReturnInvertedResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<ChatsSortTerm> transformer, ISortEnumTermTransformer<Chat> termTransformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Controller.GetAllAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, ParticipantTwo, Chats, termTransformer);
	}
}
