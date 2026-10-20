using InstaConnect.Identity.Application.Features.RefreshTokens.Models;
using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<RefreshToken?> GetByIdAsync(
		RefreshTokenIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new RefreshTokenId(new(id.Id), id.Value),
				cancellationToken);
		}

		public async Task<RefreshToken?> GetByIdAsync(
		IssueRefreshTokenCommandResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response.Id,
				cancellationToken);
		}

		public async Task<RefreshToken?> GetByIdAsync(
		RotateRefreshTokenCommandResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response.Id,
				cancellationToken);
		}
	}
}
