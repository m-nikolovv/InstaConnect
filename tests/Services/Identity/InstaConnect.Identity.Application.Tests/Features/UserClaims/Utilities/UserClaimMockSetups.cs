using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IUserClaimQueryService service)
	{
		public void SetupGetAllAsync(
		GetAllUserClaimsQueryRequest request,
		User user,
		ICollection<UserClaim> userClaims,
		CancellationToken cancellationToken)
		{
			service.SetupGetAllAsync(request.IsGetAllUserClaimsQuery(), userClaims.ToResponse(request, user), cancellationToken);
		}

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
		AddUserClaimCommandRequest request,
		UserClaim userClaim,
		CancellationToken cancellationToken)
		{
			service.SetupAddAsync(request.IsAddUserClaimCommand(), userClaim.ToResponse(request), cancellationToken);
		}

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
