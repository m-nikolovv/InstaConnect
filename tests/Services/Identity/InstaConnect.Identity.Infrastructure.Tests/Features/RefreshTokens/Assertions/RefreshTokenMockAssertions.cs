using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMockAssertions
{
	extension(IRefreshTokenCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(RefreshTokenId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<RefreshTokenId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(refreshToken, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddRangeAsync(
			ICollection<RefreshToken> refreshTokens,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddRangeAsync(refreshTokens, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().UpdateAsync(refreshToken, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(refreshToken, cancellationToken);
		}
	}

	extension(IRefreshTokenFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(RefreshTokenId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(ICollection<RefreshTokenId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public void ShouldHaveReceivedOneInclude(
			RefreshTokenId id,
			RefreshTokenInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(RefreshTokenInclude include)
		{
			fluent.ShouldHaveReceivedOne().Include(include);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			RefreshTokenId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<RefreshTokenId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
