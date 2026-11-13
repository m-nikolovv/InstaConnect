using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMockAssertions
{
	extension(IForgotPasswordTokenCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(ForgotPasswordTokenId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<ForgotPasswordTokenId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddRangeAsync(
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddRangeAsync(forgotPasswordTokens, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().UpdateAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteRangeAsync(forgotPasswordTokens, cancellationToken);
		}
	}

	extension(IForgotPasswordTokenFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(ForgotPasswordTokenId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(ICollection<ForgotPasswordTokenId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public void ShouldHaveReceivedOneInclude(
			ForgotPasswordTokenId id,
			ForgotPasswordTokenInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(ForgotPasswordTokenInclude include)
		{
			fluent.ShouldHaveReceivedOne().Include(include);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			ForgotPasswordTokenId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			ForgotPasswordTokenId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<ForgotPasswordTokenId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
