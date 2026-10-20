using InstaConnect.Common.Events.Features.AccessTokens.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(UserClaim userClaim)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(userClaim.CreatedAtUtc);
		}
	}

	extension(IUserClaimFactory factory)
	{
		public void SetupCreate(
			AddUserClaimCommand command,
			UserClaim userClaim)
		{
			factory.SetupCreate(
				command.Id,
				command.Claim,
				userClaim.To(command));
		}

		public void SetupCreate(
			UserId id,
			ApplicationClaims claim,
			UserClaim userClaim)
		{
			factory
				.Create(
					id,
					claim)
				.ReturnsResponse(userClaim);
		}
	}

	extension(IUserClaimCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			DeleteUserClaimCommand command,
			UserClaimInclude include,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, userClaim, cancellationToken);
		}

		public void SetupGetByIdAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(userClaim.Id, userClaim, cancellationToken);
		}

		public void SetupGetByIdAsync(
			UserClaimId id,
			UserClaimInclude include,
			UserClaim? userClaim,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, include, cancellationToken)
				.ReturnsTaskResponse(userClaim);
		}

		public void SetupGetByIdAsync(
			UserClaimId id,
			UserClaim? userClaim,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(userClaim);
		}

		public void RemoveGetByIdAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(userClaim.Id, null, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			DeleteUserClaimCommand command,
			UserClaimInclude include,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddUserClaimCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, user, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			AddUserClaimCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, false, cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllUserClaimsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.Id, query.Current, user.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllUserClaimsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.Id, query.Current, null, cancellationToken);
		}
	}

	extension(IUserClaimQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllUserClaimsQuery query,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllAsync(query.Filter, query.Sorting, query.Pagination, query.Current, userClaims.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllAsync(
			UserClaimsFilterQuery filter,
			UserClaimsSortingQuery sorting,
			UserClaimsPaginationQuery pagination,
			CurrentUserQuery current,
			ICollection<UserClaimResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(filter, sorting, pagination, current, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountAsync(
			GetAllUserClaimsQuery query,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountAsync(query.Filter, userClaims.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountAsync(
			UserClaimsFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}
	}

	extension(IUserClaimQueryService service)
	{
		public void SetupGetAllAsync(
			GetAllUserClaimsQuery query,
			UserClaimCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IUserClaimCommandService service)
	{
		public void SetupAddAsync(
			AddUserClaimCommand command,
			UserClaimId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
