namespace InstaConnect.Chats.Domain.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddUserCommand command)
		{
			factory.ShouldHaveReceivedOneCreate(
				command.Id,
				command.FirstName,
				command.LastName,
				command.Name,
				command.Email,
				command.ProfileImageUrl,
				command.CreatedAtUtc,
				command.UpdatedAtUtc);
		}

		public void ShouldHaveReceivedOneCreate(
			UserId id,
			string firstName,
			string lastName,
			Name name,
			Email email,
			Url? profileImageUrl,
			DateTimeOffset createdAtUtc,
			DateTimeOffset updatedAtUtc)
		{
			factory.ShouldHaveReceivedOne().Create(
				id,
				firstName,
				lastName,
				name,
				email,
				profileImageUrl,
				createdAtUtc,
				updatedAtUtc);
		}
	}

	extension(IUserCommandRepository repository)
	{
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

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsNameUniqueAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneIsNameUniqueAsync(request.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsNameUniqueAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneIsNameUniqueAsync(request.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsNameUniqueAsync(
			Name name,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsNameUniqueAsync(name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsEmailUniqueAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneIsEmailUniqueAsync(request.Email, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsEmailUniqueAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneIsEmailUniqueAsync(request.Email, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsEmailUniqueAsync(
			Email email,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsEmailUniqueAsync(email, cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UserId id,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(id, currentUser, cancellationToken);
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
