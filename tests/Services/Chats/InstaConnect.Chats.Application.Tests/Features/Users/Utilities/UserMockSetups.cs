using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Domain.Features.Users.Models.Requests;

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

		public void SetupAddAsync(
			AddUserCommand command,
			UserId id,
			CancellationToken cancellationToken)
		{
			userService
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}

		public void SetupUpdateAsync(
			UpdateUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			userService.SetupUpdateAsync(request.IsUpdateUserCommand(), user.ToResponse(request), cancellationToken);
		}

		public void SetupUpdateAsync(
			UpdateUserCommand command,
			UserId id,
			CancellationToken cancellationToken)
		{
			userService
				.UpdateAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
