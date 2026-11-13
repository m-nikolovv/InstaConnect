using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IRefreshTokenCollection collection)
	{
		public void SetupAggregateFluent(
			RefreshTokenId id,
			IRefreshTokenFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ICollection<RefreshTokenId> ids,
			IRefreshTokenFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IRefreshTokenFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IRefreshTokenFluent fluent)
	{
		public void SetupInclude(
			RefreshTokenId id,
			RefreshTokenInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(RefreshTokenInclude include)
		{
			fluent.Include(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(RefreshTokenId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ICollection<RefreshTokenId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
		}

		public void SetupFirstOrDefaultAsync(
			RefreshTokenId id,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(refreshToken, cancellationToken);
		}

		public void SetupToListAsync(
			ICollection<RefreshTokenId> ids,
			ICollection<RefreshToken> refreshTokens,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(refreshTokens, cancellationToken);
		}
	}
}
