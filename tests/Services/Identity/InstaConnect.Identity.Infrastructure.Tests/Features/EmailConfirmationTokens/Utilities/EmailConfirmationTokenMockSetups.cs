using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMockSetups
{
	extension(IEmailConfirmationTokenCollection collection)
	{
		public void SetupAggregateFluent(
			EmailConfirmationTokenId id,
			IEmailConfirmationTokenFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ICollection<EmailConfirmationTokenId> ids,
			IEmailConfirmationTokenFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IEmailConfirmationTokenFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IEmailConfirmationTokenFluent fluent)
	{
		public void SetupAnyAsync(
			EmailConfirmationTokenId id,
			EmailConfirmationToken? emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(emailConfirmationToken != null, cancellationToken);
		}

		public void SetupApplyIncludes(
			EmailConfirmationTokenId id,
			EmailConfirmationTokenInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(EmailConfirmationTokenInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(EmailConfirmationTokenId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ICollection<EmailConfirmationTokenId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
		}

		public void SetupFirstOrDefaultAsync(
			EmailConfirmationTokenId id,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(emailConfirmationToken, cancellationToken);
		}

		public void SetupToListAsync(
			ICollection<EmailConfirmationTokenId> ids,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(emailConfirmationTokens, cancellationToken);
		}
	}
}
