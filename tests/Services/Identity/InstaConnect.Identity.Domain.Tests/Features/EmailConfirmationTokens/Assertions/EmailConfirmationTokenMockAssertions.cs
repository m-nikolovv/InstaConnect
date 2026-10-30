using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMockAssertions
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(IOptions<EmailConfirmationTokenOptions> emailConfirmationTokenOptions)
		{
			dateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(emailConfirmationTokenOptions.Value.LifetimeSeconds);
		}

		public void ShouldHaveReceivedOneGetOffsetUtcNow(VerifyEmailConfirmationTokenCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
		}
	}

	extension(IEmailConfirmationTokenFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
		{
			factory.ShouldHaveReceivedOneCreate(emailConfirmationToken.Id.Id);
		}

		public void ShouldHaveReceivedOneCreate(UserId id)
		{
			factory.ShouldHaveReceivedOne().Create(id);
		}
	}

	extension(IEmailConfirmationTokenEmailSender emailSender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOneSendAsync(command.IsEmailConfirmationToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOne().SendAsync(emailConfirmationToken, cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsEmailConfirmationTokenAddedEventRequest(emailConfirmationToken), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishRangeAsync(
			VerifyEmailConfirmationTokenCommand command,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishRangeAsync(command.IsEmailConfirmationTokenDeletedEventRequestCollection(emailConfirmationTokens), cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByNameAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByNameAsync(command.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneUpdateAsync(command.IsUser(), cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsEmailConfirmationToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			EmailConfirmationTokenId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteRangeAsync(command.IsEmailConfirmationTokenCollection(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			IEnumerable<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteRangeAsync(emailConfirmationTokens, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroDeleteRangeAsync(
			IEnumerable<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedZero().DeleteRangeAsync(emailConfirmationTokens, cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenCommandService service)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneVerifyAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().VerifyAsync(command, cancellationToken);
		}
	}
}
