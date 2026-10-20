using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.EventHandlers.v1;

public class UserDeletedEventHandlerIntegrationTests : BaseUserInfrastructureEventHandlerIntegrationTest
{
	private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserDeletedEventRequestBuilder _requestBuilder;
	private readonly UserDeletedEventRequest _request;

	private readonly UserDeletedEventHandler _handler;

	public UserDeletedEventHandlerIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = ServiceScope.GetUserDeletedEventHandler();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task Consume_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await _handler.ShouldThrowInvalidValidationExceptionForIdAsync(request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task Consume_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await _handler.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task Consume_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}
}
