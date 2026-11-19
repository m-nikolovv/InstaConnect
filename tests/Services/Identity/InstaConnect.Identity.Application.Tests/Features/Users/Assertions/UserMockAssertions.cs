using InstaConnect.Identity.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserQueryService userService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllUsersQueryRequest request,
		CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllUsersQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllUsersQuery query,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetUserByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetCurrentUserByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetUserDetailsByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetCurrentUserDetailsByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetUserByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetUserByIdQuery query,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IUserCommandService userService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddUserCommandRequest request,
		CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneAddAsync(request.IsAddUserCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateCurrentUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneUpdateAsync(request.IsUpdateUserCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().UpdateAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteUserCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteCurrentUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteUserCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
