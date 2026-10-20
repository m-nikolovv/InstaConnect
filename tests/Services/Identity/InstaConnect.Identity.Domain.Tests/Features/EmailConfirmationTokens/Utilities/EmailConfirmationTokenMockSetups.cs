using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(EmailConfirmationToken emailConfirmationToken)
		{
			guidProvider.SetupNewStringGuid(emailConfirmationToken.Id.Value);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(EmailConfirmationToken emailConfirmationToken)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(emailConfirmationToken.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			EmailConfirmationToken emailConfirmationToken,
			IOptions<EmailConfirmationTokenOptions> emailConfirmationTokenOptions)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(emailConfirmationTokenOptions.Value.LifetimeSeconds, emailConfirmationToken.ExpiresAtUtc);
		}

		public void SetupGetOffsetUtcNow(VerifyEmailConfirmationTokenCommand command, DateTimeOffset utcNow)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(utcNow);
		}
	}

	extension(IEmailConfirmationTokenFactory factory)
	{
		public void SetupCreate(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
		{
			factory.SetupCreate(emailConfirmationToken.Id.Id, emailConfirmationToken);
		}

		public void SetupCreate(
			UserId id,
			EmailConfirmationToken emailConfirmationToken)
		{
			factory
				.Create(id)
				.ReturnsResponse(emailConfirmationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByNameAsync(
			AddEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByNameAsync(command.Name, user, cancellationToken);
		}

		public void RemoveGetByNameAsync(
			AddEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByNameAsync(command.Name, null, cancellationToken);
		}

		public void SetupGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id.Id, include, user, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id.Id, include, null, cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, emailConfirmationToken, cancellationToken);
		}

		public void SetupGetByIdAsync(
			EmailConfirmationTokenId id,
			EmailConfirmationToken? emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(emailConfirmationToken);
		}

		public void RemoveGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, null, cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenCommandService service)
	{
		public void SetupAddAsync(
			AddEmailConfirmationTokenCommand command,
			EmailConfirmationTokenId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
