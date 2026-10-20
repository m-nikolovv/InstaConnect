using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(AddUserCommand command)
		{
			factory.ShouldHaveReceivedOneCreate(
				command.Name,
				command.FirstName,
				command.LastName,
				command.Email,
				command.Password);
		}

		public void ShouldHaveReceivedOneCreate(
			Name name,
			string firstName,
			string lastName,
			Email email,
			string password)
		{
			factory.ShouldHaveReceivedOne().Create(
				name,
				firstName,
				lastName,
				email,
				password);
		}
	}

	extension(IImageHandler imageHandler)
	{
		public async Task ShouldHaveReceivedOneUploadAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOneUploadAsync(command.ProfileImage!, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUploadAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOneUploadAsync(command.ProfileImage!, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroUploadAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZeroUploadAsync(command.ProfileImage!, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroUploadAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZeroUploadAsync(command.ProfileImage!, cancellationToken);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(UpdateUserCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneIsEmailUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneIsEmailUniqueAsync(command.Email, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsEmailUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneIsEmailUniqueAsync(command.Email, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsEmailUniqueAsync(
			Email email,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsEmailUniqueAsync(email, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsNameUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneIsNameUniqueAsync(command.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsNameUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneIsNameUniqueAsync(command.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsNameUniqueAsync(
			Name name,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsNameUniqueAsync(name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UpdateUserCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UserId id,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByNameAsync(
			Name name,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByNameAsync(
				name,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByNameAsync(
			Name name,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByNameAsync(name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsUser(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(user, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneUpdateAsync(command.IsUser(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(user, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteAsync(command.IsUser(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(user, cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllUsersQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetAllAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.Current,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllAsync(
			UsersFilterQuery filter,
			UsersSortingQuery sorting,
			UsersPaginationQuery pagination,
			CurrentUserQuery current,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				filter,
				sorting,
				pagination,
				current,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			GetAllUsersQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			UsersFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetUserByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Id,
				query.Current,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UserId id,
			CurrentUserQuery current,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				current,
				cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsUserAddedEventRequest(user), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsUserUpdatedEventRequest(user), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsUserDeletedEventRequest(user), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			AddUserCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsEmailConfirmationTokenAddedEventRequest(emailConfirmationToken), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishEmailConfirmationTokenDeletedAsync(
			UpdateUserCommand command,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsEmailConfirmationTokenDeletedEventRequestCollection(emailConfirmationTokens), cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroPublishEmailConfirmationTokenDeletedAsync(
			UpdateUserCommand command,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedZeroPublishAsync(command.IsEmailConfirmationTokenDeletedEventRequestCollection(emailConfirmationTokens), cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddUserCommand command,
			User user)
		{
			factory.ShouldHaveReceivedOneCreate(user.Id);
		}
	}

	extension(IEmailConfirmationTokenCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsEmailConfirmationToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteRangeAsync(command.IsEmailConfirmationTokenCollection(), cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroDeleteRangeAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedZeroDeleteRangeAsync(command.IsEmailConfirmationTokenCollection(), cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenEmailSender emailSender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOneSendAsync(command.IsEmailConfirmationToken(), cancellationToken);
		}
	}

	extension(IUserQueryService service)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllUsersQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetUserByIdQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IUserCommandService service)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().UpdateAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
