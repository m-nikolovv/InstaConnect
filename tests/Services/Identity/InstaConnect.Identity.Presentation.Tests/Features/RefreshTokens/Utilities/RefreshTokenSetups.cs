using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public RefreshTokenController GetRefreshTokenController()
		{
			return serviceProvider.GetRequiredService<RefreshTokenController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public RefreshTokenController GetRefreshTokenController()
		{
			return serviceScope.ServiceProvider.GetRefreshTokenController();
		}

		public async Task<RefreshToken?> GetByIdAsync(
			RefreshTokenCookieApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new RefreshTokenId(new(response.IdCookie.GetStringValue()), response.ValueCookie.GetStringValue()),
				cancellationToken);
		}
	}
}
