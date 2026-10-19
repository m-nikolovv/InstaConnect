using InstaConnect.Chats.Tests.Features.Users.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Functional.Features.Users.Endpoints;

public class DeleteUserInfrastructureFunctionalTests : BaseUserInfrastructureCommandFunctionalTest
{
	private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserDeletedEventRequestBuilder _requestBuilder;
	private readonly UserDeletedEventRequest _request;

	public DeleteUserInfrastructureFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task PublishAsync_ShouldFaultUserDeletedEvent_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldFaultUserDeletedEvent_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request);
	}

	[Fact]
	public async Task PublishAsync_ShouldConsumeUserDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldConsumeUserDeletedEvent_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUser_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}
}
