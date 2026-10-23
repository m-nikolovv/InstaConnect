using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Tests.Features.Common.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMockAssertions
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(IOptions<ForgotPasswordTokenOptions> forgotPasswordTokenOptions)
		{
			dateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(forgotPasswordTokenOptions.Value.LifetimeSeconds);
		}

		public void ShouldHaveReceivedOneGetOffsetUtcNow(VerifyForgotPasswordTokenCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void ShouldHaveReceivedOneHash(VerifyForgotPasswordTokenCommand command)
		{
			passwordHasher.ShouldHaveReceivedOneHash(command.Password);
		}
	}

	extension(IForgotPasswordTokenFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
		{
			factory.ShouldHaveReceivedOneCreate(forgotPasswordToken.Id.Id);
		}

		public void ShouldHaveReceivedOneCreate(UserId id)
		{
			factory.ShouldHaveReceivedOne().Create(id);
		}
	}

	extension(IForgotPasswordTokenEmailSender emailSender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOneSendAsync(command.IsForgotPasswordToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOne().SendAsync(forgotPasswordToken, cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsForgotPasswordTokenAddedEventRequest(forgotPasswordToken), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishRangeAsync(
			VerifyForgotPasswordTokenCommand command,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishRangeAsync(command.IsForgotPasswordTokenDeletedEventRequestCollection(forgotPasswordTokens), cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByNameAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByNameAsync(command.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			VerifyForgotPasswordTokenCommand command,
			IPasswordHasher passwordHasher,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneUpdateAsync(command.IsUser(passwordHasher), cancellationToken);
		}
	}

	extension(IForgotPasswordTokenCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsForgotPasswordToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			ForgotPasswordTokenId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteRangeAsync(command.IsForgotPasswordTokenCollection(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			IEnumerable<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteRangeAsync(forgotPasswordTokens, cancellationToken);
		}
	}

	extension(IForgotPasswordTokenCommandService service)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneVerifyAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().VerifyAsync(command, cancellationToken);
		}
	}
}
