using InstaConnect.Common.Application.Tests.Features.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllUsersApiRequest request,
		ICollection<User> users,
		CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllUsersQueryRequest(), users.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			GetUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetUserByIdQueryRequest(), user.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			GetUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetUserDetailsByIdQueryRequest(), user.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			GetCurrentUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetCurrentUserByIdQueryRequest(), user.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetCurrentUserDetailsByIdQueryRequest(), user.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			AddUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsAddUserCommandRequest(), user.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			UpdateCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsUpdateCurrentUserCommandRequest(), user.ToResponse(request), cancellationToken);
		}
	}
}
