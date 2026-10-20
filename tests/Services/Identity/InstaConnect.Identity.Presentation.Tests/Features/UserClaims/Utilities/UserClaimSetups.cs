using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Presentation.Features.UserClaims.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public UserClaimController GetUserClaimController()
		{
			return serviceProvider.GetRequiredService<UserClaimController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public UserClaimController GetUserClaimController()
		{
			return serviceScope.ServiceProvider.GetUserClaimController();
		}

		internal async Task<UserClaim?> GetByIdAsync(
		UserClaimIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new UserClaimId(new(id.Id), id.Claim),
				cancellationToken);
		}

		public async Task<UserClaim?> GetByIdAsync(
		AddUserClaimApiResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<UserClaim?> GetByIdAsync(
		ActionResult<AddUserClaimApiResponse> response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}
	}
}
