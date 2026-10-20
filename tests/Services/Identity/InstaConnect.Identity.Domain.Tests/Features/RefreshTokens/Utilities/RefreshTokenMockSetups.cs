using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(RefreshToken refreshToken)
		{
			guidProvider.SetupNewStringGuid(refreshToken.Id.Value);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(RefreshToken refreshToken)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(refreshToken.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			RefreshToken refreshToken,
			IOptions<RefreshTokenOptions> refreshTokenOptions)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(refreshTokenOptions.Value.LifetimeSeconds, refreshToken.ExpiresAtUtc);
		}

		public void SetupGetOffsetUtcNow(RotateRefreshTokenCommand command, DateTimeOffset utcNow)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(utcNow);
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void SetupIsMismatch(IssueRefreshTokenCommand command, User user)
		{
			passwordHasher.SetupIsMismatch(command.Password, user.PasswordHash, true);
		}
	}

	extension(IRefreshTokenFactory factory)
	{
		public void SetupCreate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			factory.SetupCreate(refreshToken.Id.Id, refreshToken);
		}

		public void SetupCreate(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			factory.SetupCreate(command.Id.Id, refreshToken);
		}

		public void SetupCreate(
			UserId id,
			RefreshToken refreshToken)
		{
			factory
				.Create(id)
				.ReturnsResponse(refreshToken);
		}
	}

	extension(ISessionTokenGenerator generator)
	{
		public void SetupGenerate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator.SetupGenerate(refreshToken, refreshToken.ToResponse(command));
		}

		public void SetupGenerate(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator.SetupGenerate(refreshToken, refreshToken.ToResponse(command));
		}

		public void SetupGenerate(
			RefreshToken refreshToken,
			SessionToken sessionToken)
		{
			generator
				.Generate(refreshToken)
				.ReturnsResponse(sessionToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetByNameAsync(
			IssueRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByNameAsync(command.Name, include, user, cancellationToken);
		}

		public void RemoveGetByNameAsync(
			IssueRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByNameAsync(command.Name, include, null, cancellationToken);
		}

		public void SetupGetByIdAsync(
			RotateRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id.Id, include, user, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			RotateRefreshTokenCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id.Id, include, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, false, cancellationToken);
		}
	}

	extension(IRefreshTokenCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, refreshToken, cancellationToken);
		}

		public void SetupGetByIdAsync(
			DeleteRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, refreshToken, cancellationToken);
		}

		public void SetupGetByIdAsync(
			RefreshTokenId id,
			RefreshToken? refreshToken,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(refreshToken);
		}

		public void RemoveGetByIdAsync(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, null, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			DeleteRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, null, cancellationToken);
		}
	}

	extension(IRefreshTokenCommandService service)
	{
		public void SetupIssueAsync(
			IssueRefreshTokenCommand command,
			SessionToken sessionToken,
			CancellationToken cancellationToken)
		{
			service
				.IssueAsync(command, cancellationToken)
				.ReturnsTaskResponse(sessionToken);
		}

		public void SetupRotateAsync(
			RotateRefreshTokenCommand command,
			SessionToken sessionToken,
			CancellationToken cancellationToken)
		{
			service
				.RotateAsync(command, cancellationToken)
				.ReturnsTaskResponse(sessionToken);
		}
	}
}
