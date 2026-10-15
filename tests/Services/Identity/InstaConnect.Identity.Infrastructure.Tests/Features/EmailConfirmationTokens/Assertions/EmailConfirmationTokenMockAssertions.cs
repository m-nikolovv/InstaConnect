using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMockAssertions
{
	extension(IEmailConfirmationTokenCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(EmailConfirmationTokenId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<EmailConfirmationTokenId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().UpdateAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteRangeAsync(emailConfirmationTokens, cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(EmailConfirmationTokenId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(ICollection<EmailConfirmationTokenId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			EmailConfirmationTokenId id,
			EmailConfirmationTokenInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(EmailConfirmationTokenInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			EmailConfirmationTokenId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			EmailConfirmationTokenId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<EmailConfirmationTokenId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
