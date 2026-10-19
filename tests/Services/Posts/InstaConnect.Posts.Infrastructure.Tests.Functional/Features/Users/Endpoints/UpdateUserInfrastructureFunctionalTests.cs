using InstaConnect.Posts.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Functional.Features.Users.Endpoints;

public class UpdateUserInfrastructureFunctionalTests : BaseUserInfrastructureCommandFunctionalTest
{
	private readonly UserUpdatedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserUpdatedEventRequestBuilder _requestBuilder;
	private readonly UserUpdatedEventRequest _request;

	public UpdateUserInfrastructureFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameTooShortData]
	[UserNameTooLongData]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserFirstNameNullData]
	[UserFirstNameEmptyData]
	[UserFirstNameTooShortData]
	[UserFirstNameTooLongData]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenFirstNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserLastNameNullData]
	[UserLastNameEmptyData]
	[UserLastNameTooShortData]
	[UserLastNameTooLongData]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenLastNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailNullData]
	[UserEmailEmptyData]
	[UserEmailTooShortData]
	[UserEmailTooLongData]
	[UserEmailInvalidData]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserProfileImageTooLongData]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenProfileImageIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserUpdatedAtUtcEmptyData]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenUpdatedAtUtcIsInvalid(
		IDateTimeOffsetTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUpdatedAtUtc(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request);
	}

	[Fact]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenUserEmailAlreadyExists()
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);

		var request = _requestBuilder.WithEmail(newUser.Email).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenUserEmailAlreadyExistsAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);

		var request = _requestBuilder.WithEmail(newUser.Email, transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenUserNameAlreadyExists()
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);

		var request = _requestBuilder.WithName(newUser.Name).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task PublishAsync_ShouldFaultUserUpdatedEvent_WhenUserNameAlreadyExistsAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);

		var request = _requestBuilder.WithName(newUser.Name, transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task PublishAsync_ShouldConsumeUserUpdatedEvent_WhenProfileImageIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldUpdateUser_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldUpdateUser_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task PublishAsync_ShouldUpdateUser_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldUpdateUser_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task PublishAsync_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task PublishAsync_ShouldUpdateUser_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldUpdateUser_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task PublishAsync_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task PublishAsync_ShouldUpdateUser_WhenRequestAndProfileImageAreValid(
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
