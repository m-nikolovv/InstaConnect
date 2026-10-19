using InstaConnect.Posts.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Functional.Features.Users.Endpoints;

public class AddUserInfrastructureFunctionalTests : BaseUserInfrastructureCommandFunctionalTest
{
	private readonly UserAddedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserAddedEventRequestBuilder _requestBuilder;
	private readonly UserAddedEventRequest _request;

	public AddUserInfrastructureFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameTooShortData]
	[UserNameTooLongData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserFirstNameNullData]
	[UserFirstNameEmptyData]
	[UserFirstNameTooShortData]
	[UserFirstNameTooLongData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenFirstNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserLastNameNullData]
	[UserLastNameEmptyData]
	[UserLastNameTooShortData]
	[UserLastNameTooLongData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenLastNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailNullData]
	[UserEmailEmptyData]
	[UserEmailTooShortData]
	[UserEmailTooLongData]
	[UserEmailInvalidData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserProfileImageTooLongData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenProfileImageIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserCreatedAtUtcEmptyData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenCreatedAtUtcIsInvalid(
		IDateTimeOffsetTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCreatedAtUtc(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserUpdatedAtUtcEmptyData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenUpdatedAtUtcIsInvalid(
		IDateTimeOffsetTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUpdatedAtUtc(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenUserAlreadyExists()
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);
		var request = _requestBuilder.WithId(newUser.Id).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenUserAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);
		var request = _requestBuilder.WithId(newUser.Id, transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenUserEmailAlreadyExists()
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);
		var request = _requestBuilder.WithEmail(newUser.Email).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenUserEmailAlreadyExistsAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);
		var request = _requestBuilder.WithEmail(newUser.Email, transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenUserNameAlreadyExists()
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);
		var request = _requestBuilder.WithName(newUser.Name).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task PublishAsync_ShouldFaultUserAddedEvent_WhenUserNameAlreadyExistsAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);
		var request = _requestBuilder.WithName(newUser.Name, transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldConsumeUserAddedEvent_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task PublishAsync_ShouldConsumeUserAddedEvent_WhenProfileImageIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldAddUser_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task PublishAsync_ShouldAddUser_WhenProfileImageIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}
}
