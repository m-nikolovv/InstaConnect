using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;

public static class UserClaimMockAssertions
{
	extension(IUserClaimFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddUserClaimCommand command)
		{
			factory.ShouldHaveReceivedOneCreate(
				command.Id,
				command.Claim);
		}

		public void ShouldHaveReceivedOneCreate(
			UserId id,
			ApplicationClaims claim)
		{
			factory.ShouldHaveReceivedOne().Create(
				id,
				claim);
		}
	}

	extension(IUserClaimCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				userClaim.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteUserClaimCommand command,
			UserClaimInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UserClaimId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UserClaimId id,
			UserClaimInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsUserClaim(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(userClaim, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteAsync(command.IsUserClaim(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(userClaim, cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllUserClaimsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Filter.Id,
				query.Current,
				cancellationToken);
		}
	}

	extension(IUserClaimQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllUserClaimsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetAllAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.Current,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllAsync(
			UserClaimsFilterQuery filter,
			UserClaimsSortingQuery sorting,
			UserClaimsPaginationQuery pagination,
			CurrentUserQuery current,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				filter,
				sorting,
				pagination,
				current,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			GetAllUserClaimsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			UserClaimsFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				filter,
				cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsUserClaimAddedEventRequest(userClaim), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			DeleteUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsUserClaimDeletedEventRequest(userClaim), cancellationToken);
		}
	}

	extension(IUserClaimQueryService service)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllUserClaimsQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}
	}

	extension(IUserClaimCommandService service)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
