using InstaConnect.Follows.Tests.Features.Follows.Assertions;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Services;

public class AddFollowCommandServiceIntegrationTests : BaseFollowDomainCommandIntegrationTest
{
	private readonly AddFollowCommandBuilderFactory _commandBuilderFactory;
	private readonly AddFollowCommandBuilder _commandBuilder;
	private readonly AddFollowCommand _command;

	public AddFollowCommandServiceIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Follower, Following);
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowFollowerNotFoundException_WhenFollowerNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follower, CancellationToken);

		// Assert
		await Service.ShouldThrowFollowerNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowFollowingNotFoundException_WhenFollowingNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Following, CancellationToken);

		// Assert
		await Service.ShouldThrowFollowingNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);

		// Assert
		await Service.ShouldThrowFollowAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExistsAndFollowerIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var command = _commandBuilder.WithFollowerId(transformer).Build();

		// Assert
		await Service.ShouldThrowFollowAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExistsAndFollowingIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var command = _commandBuilder.WithFollowingId(transformer).Build();

		// Assert
		await Service.ShouldThrowFollowAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, follow);
	}

	[Fact]
	public async Task AddAsync_ShouldAddFollow_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddFollow_WhenCommandAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddFollow_WhenCommandAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenCommandAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenCommandAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, follow);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishFollowAddedNotification_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await NotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_command, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedNotification_WhenCommandAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await NotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedNotification_WhenCommandAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await NotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, follow);
	}
}
