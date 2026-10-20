using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Tests.Features.Common.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMockAssertions
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(IOptions<RefreshTokenOptions> refreshTokenOptions)
		{
			dateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(refreshTokenOptions.Value.LifetimeSeconds);
		}

		public void ShouldHaveReceivedOneGetOffsetUtcNow(RotateRefreshTokenCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void ShouldHaveReceivedOneIsMismatch(IssueRefreshTokenCommand command, User user)
		{
			passwordHasher.ShouldHaveReceivedOneIsMismatch(command.Password, user.PasswordHash);
		}
	}

	extension(IRefreshTokenFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			factory.ShouldHaveReceivedOneCreate(refreshToken.Id.Id);
		}

		public void ShouldHaveReceivedOneCreate(RotateRefreshTokenCommand command)
		{
			factory.ShouldHaveReceivedOneCreate(command.Id.Id);
		}

		public void ShouldHaveReceivedOneCreate(UserId id)
		{
			factory.ShouldHaveReceivedOne().Create(id);
		}
	}

	extension(ISessionTokenGenerator generator)
	{
		public void ShouldHaveReceivedOneGenerate(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator.ShouldHaveReceivedOneGenerate(refreshToken);
		}

		public void ShouldHaveReceivedOneGenerate(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			generator.ShouldHaveReceivedOneGenerate(refreshToken);
		}

		public void ShouldHaveReceivedOneGenerate(RefreshToken refreshToken)
		{
			generator.ShouldHaveReceivedOne().Generate(refreshToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByNameAsync(
			IssueRefreshTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByNameAsync(
				command.Name,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			RotateRefreshTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}
	}

	extension(IRefreshTokenCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			RefreshTokenId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			IssueRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsRefreshToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsRefreshToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(refreshToken, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteAsync(command.IsRefreshToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteAsync(command.IsRefreshToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(refreshToken, cancellationToken);
		}
	}

	extension(IRefreshTokenCommandService service)
	{
		public async Task ShouldHaveReceivedOneIssueAsync(
			IssueRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().IssueAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneRotateAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().RotateAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
