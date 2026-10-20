using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMockSetups
{
	extension(IForgotPasswordTokenCollection collection)
	{
		public void SetupAggregateFluent(
			ForgotPasswordTokenId id,
			IForgotPasswordTokenFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ICollection<ForgotPasswordTokenId> ids,
			IForgotPasswordTokenFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IForgotPasswordTokenFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IForgotPasswordTokenFluent fluent)
	{
		public void SetupAnyAsync(
			ForgotPasswordTokenId id,
			ForgotPasswordToken? forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(forgotPasswordToken != null, cancellationToken);
		}

		public void SetupApplyIncludes(
			ForgotPasswordTokenId id,
			ForgotPasswordTokenInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(ForgotPasswordTokenInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(ForgotPasswordTokenId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ICollection<ForgotPasswordTokenId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
		}

		public void SetupFirstOrDefaultAsync(
			ForgotPasswordTokenId id,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(forgotPasswordToken, cancellationToken);
		}

		public void SetupToListAsync(
			ICollection<ForgotPasswordTokenId> ids,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(forgotPasswordTokens, cancellationToken);
		}
	}
}
