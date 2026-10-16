using InstaConnect.Chats.Domain.Features.Users.Models.Responses;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserFactory factory)
	{
		public void SetupCreate(
			AddUserCommand command,
			User user)
		{
			factory.SetupCreate(
				command.Id,
				command.FirstName,
				command.LastName,
				command.Name,
				command.Email,
				command.ProfileImageUrl,
				command.CreatedAtUtc,
				command.UpdatedAtUtc,
				user.To(command));
		}

		public void SetupCreate(
			UserId id,
			string firstName,
			string lastName,
			Name name,
			Email email,
			Url? profileImageUrl,
			DateTimeOffset createdAtUtc,
			DateTimeOffset updatedAtUtc,
			User user)
		{
			factory
				.Create(
					id,
					firstName,
					lastName,
					name,
					email,
					profileImageUrl,
					createdAtUtc,
					updatedAtUtc)
				.ReturnsResponse(user);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupExistsByIdAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id, true, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			UserId id,
			bool exists,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(exists);
		}

		public void RemoveExistsByIdAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id, false, cancellationToken);
		}

		public void SetupGetByIdAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, user, cancellationToken);
		}

		public void SetupGetByIdAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, user, cancellationToken);
		}

		public void SetupGetByIdAsync(
			UserId id,
			User? user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void RemoveGetByIdAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, null, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, null, cancellationToken);
		}

		public void SetupIsNameUniqueAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupIsNameUniqueAsync(command.Name, true, cancellationToken);
		}

		public void SetupIsNameUniqueAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupIsNameUniqueAsync(command.Name, true, cancellationToken);
		}

		public void SetupIsNameUniqueAsync(
			Name name,
			bool isUnique,
			CancellationToken cancellationToken)
		{
			repository
				.IsNameUniqueAsync(name, cancellationToken)
				.ReturnsTaskResponse(isUnique);
		}

		public void RemoveIsNameUniqueAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupIsNameUniqueAsync(command.Name, false, cancellationToken);
		}

		public void RemoveIsNameUniqueAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupIsNameUniqueAsync(command.Name, false, cancellationToken);
		}

		public void SetupIsEmailUniqueAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupIsEmailUniqueAsync(command.Email, true, cancellationToken);
		}

		public void SetupIsEmailUniqueAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupIsEmailUniqueAsync(command.Email, true, cancellationToken);
		}

		public void SetupIsEmailUniqueAsync(
			Email email,
			bool isUnique,
			CancellationToken cancellationToken)
		{
			repository
				.IsEmailUniqueAsync(email, cancellationToken)
				.ReturnsTaskResponse(isUnique);
		}

		public void RemoveIsEmailUniqueAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupIsEmailUniqueAsync(command.Email, false, cancellationToken);
		}

		public void RemoveIsEmailUniqueAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupIsEmailUniqueAsync(command.Email, false, cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			UserId id,
			CurrentUserQuery currentUser,
			UserResponse? response,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, currentUser, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IUserCommandService service)
	{
		public void SetupAddAsync(
			AddUserCommand command,
			UserId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}

		public void SetupUpdateAsync(
			UpdateUserCommand command,
			UserId id,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
