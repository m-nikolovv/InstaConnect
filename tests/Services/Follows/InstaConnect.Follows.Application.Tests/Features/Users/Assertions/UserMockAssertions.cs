using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Application.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserCommandService userService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddUserCommandRequest request,
		CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneAddAsync(request.IsAddUserCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneUpdateAsync(request.IsUpdateUserCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteUserCommand(), cancellationToken);
		}
	}
}
