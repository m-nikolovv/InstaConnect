using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Assertions;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Services;

public class DeleteFollowCommandServiceIntegrationTests : BaseFollowDomainCommandIntegrationTest
{
	private readonly DeleteFollowCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteFollowCommandBuilder _commandBuilder;
	private readonly DeleteFollowCommand _command;

	public DeleteFollowCommandServiceIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Follow);
		_command = _commandBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupDeleteAsync(_command, Follow, CancellationToken);
		await base.InitializeAsync();
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowFollowNotFoundException_WhenFollowNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follow, CancellationToken);

		// Assert
		await Service.ShouldThrowFollowNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenCommandAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowerId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenCommandAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowingId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedFollow_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(_command, CancellationToken);

		// Assert
		cachedFollow.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedFollow_WhenCommandAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowerId(transformer).Build();
		await ServiceScope.AddFollowCacheAsync(command, Follow, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedFollow.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedFollow_WhenCommandAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowingId(transformer).Build();
		await ServiceScope.AddFollowCacheAsync(command, Follow, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedFollow.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishFollowDeletedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishFollowDeletedEvent_WhenCommandAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowerId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishFollowDeletedEvent_WhenCommandAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithFollowingId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, Follow);
	}
}
