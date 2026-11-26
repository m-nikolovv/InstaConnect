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

		public async Task InitializeAddAsync(
			IssueRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(refreshToken, cancellationToken);
		}

		public async Task DisposeAddAsync(
			IssueRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(refreshToken, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(refreshToken, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(refreshToken, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			RotateRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(refreshToken, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			RotateRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(refreshToken, cancellationToken);
		}
	}
}
