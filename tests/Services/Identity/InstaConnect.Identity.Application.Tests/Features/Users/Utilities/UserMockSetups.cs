using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserQueryService service)
	{
		public void SetupGetAllAsync(
		GetAllUsersQueryRequest request,
		ICollection<User> users,
		CancellationToken cancellationToken)
		{
			service.SetupGetAllAsync(request.IsGetAllUsersQuery(), users.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service.SetupGetByIdAsync(request.IsGetUserByIdQuery(), user.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetCurrentUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service.SetupGetByIdAsync(request.IsGetUserByIdQuery(), user.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service.SetupGetByIdAsync(request.IsGetUserByIdQuery(), user.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetCurrentUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service.SetupGetByIdAsync(request.IsGetUserByIdQuery(), user.ToResponse(request), cancellationToken);
		}
	}

	extension(IUserCommandService service)
	{
		public void SetupAddAsync(
		AddUserCommandRequest request,
		User user,
		CancellationToken cancellationToken)
		{
			service.SetupAddAsync(request.IsAddUserCommand(), user.ToResponse(request), cancellationToken);
		}

		public void SetupUpdateAsync(
			UpdateCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service.SetupUpdateAsync(request.IsUpdateUserCommand(), user.ToResponse(request), cancellationToken);
		}
	}
}
