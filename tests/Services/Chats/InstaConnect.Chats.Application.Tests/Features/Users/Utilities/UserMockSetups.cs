using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Application.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserCommandService userService)
	{
		public void SetupAddAsync(
		AddUserCommandRequest request,
		User user,
		CancellationToken cancellationToken)
		{
			userService.SetupAddAsync(request.IsAddUserCommand(), user.ToResponse(request), cancellationToken);
		}

		public void SetupUpdateAsync(
			UpdateUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			userService.SetupUpdateAsync(request.IsUpdateUserCommand(), user.ToResponse(request), cancellationToken);
		}
	}
}
