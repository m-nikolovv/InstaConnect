using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

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
	}

	extension(IUserCommandService userService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddUserCommandRequest request,
		CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneAddAsync(request.IsAddUserCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateCurrentUserCommandRequest request,
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

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteCurrentUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteUserCommand(), cancellationToken);
		}
	}
}
