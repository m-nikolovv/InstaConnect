using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Users.Builders;
using InstaConnect.Follows.Domain.Tests.Integration.Features.Users.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Users.Services;

public class DeleteUserCommandServiceIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly DeleteUserCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteUserCommandBuilder _commandBuilder;
	private readonly DeleteUserCommand _command;

	public DeleteUserCommandServiceIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(Follows, CancellationToken);
		await ServiceScope.AddRangeAsync(UserFollowFollowers, CancellationToken);
		await ServiceScope.AddRangeAsync(UserFollowFollowings, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await UserService.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserFollowFollowers_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userFollowFollowers = await ServiceScope.GetByIdRangeAsync(UserFollowFollowerIds, CancellationToken);

		// Assert
		userFollowFollowers.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserFollowFollowers_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userFollowFollowers = await ServiceScope.GetByIdRangeAsync(UserFollowFollowerIds, CancellationToken);

		// Assert
		userFollowFollowers.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserFollowFollowings_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userFollowFollowings = await ServiceScope.GetByIdRangeAsync(UserFollowFollowingIds, CancellationToken);

		// Assert
		userFollowFollowings.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserFollowFollowings_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userFollowFollowings = await ServiceScope.GetByIdRangeAsync(UserFollowFollowingIds, CancellationToken);

		// Assert
		userFollowFollowings.ShouldBeEmpty();
	}
}
