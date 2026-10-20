using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(ForgotPasswordToken forgotPasswordToken)
		{
			guidProvider.SetupNewStringGuid(forgotPasswordToken.Id.Value);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(ForgotPasswordToken forgotPasswordToken)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(forgotPasswordToken.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			ForgotPasswordToken forgotPasswordToken,
			IOptions<ForgotPasswordTokenOptions> forgotPasswordTokenOptions)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(forgotPasswordTokenOptions.Value.LifetimeSeconds, forgotPasswordToken.ExpiresAtUtc);
		}

		public void SetupGetOffsetUtcNow(VerifyForgotPasswordTokenCommand command, DateTimeOffset utcNow)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(utcNow);
		}
	}

	extension(IForgotPasswordTokenFactory factory)
	{
		public void SetupCreate(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
		{
			factory.SetupCreate(forgotPasswordToken.Id.Id, forgotPasswordToken);
		}

		public void SetupCreate(
			UserId id,
			ForgotPasswordToken forgotPasswordToken)
		{
			factory
				.Create(id)
				.ReturnsResponse(forgotPasswordToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByNameAsync(
			AddForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByNameAsync(command.Name, user, cancellationToken);
		}

		public void RemoveGetByNameAsync(
			AddForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByNameAsync(command.Name, null, cancellationToken);
		}

		public void SetupGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id.Id, include, user, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id.Id, include, null, cancellationToken);
		}
	}

	extension(IForgotPasswordTokenCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, forgotPasswordToken, cancellationToken);
		}

		public void SetupGetByIdAsync(
			ForgotPasswordTokenId id,
			ForgotPasswordToken? forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(forgotPasswordToken);
		}

		public void RemoveGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, null, cancellationToken);
		}
	}

	extension(IForgotPasswordTokenCommandService service)
	{
		public void SetupAddAsync(
			AddForgotPasswordTokenCommand command,
			ForgotPasswordTokenId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
