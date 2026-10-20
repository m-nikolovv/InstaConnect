using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserFactory factory)
	{
		public void SetupCreate(
			AddUserCommand command,
			User user)
		{
			factory.SetupCreate(
				command.Name,
				command.FirstName,
				command.LastName,
				command.Email,
				command.Password,
				user.To(command));
		}

		public void SetupCreate(
			Name name,
			string firstName,
			string lastName,
			Email email,
			string password,
			User user)
		{
			factory
				.Create(
					name,
					firstName,
					lastName,
					email,
					password)
				.ReturnsResponse(user);
		}
	}

	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(User user)
		{
			guidProvider.SetupNewStringGuid(user.Id.Id);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(User user)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(user.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			UpdateUserCommand command,
			User user)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(user.UpdatedAtUtc);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupIsEmailUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupIsEmailUniqueAsync(command.Email, true, cancellationToken);
		}

		public void SetupIsEmailUniqueAsync(
			UpdateUserCommand command,
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
			CancellationToken cancellationToken)
		{
			repository.SetupIsEmailUniqueAsync(command.Email, false, cancellationToken);
		}

		public void RemoveIsEmailUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupIsEmailUniqueAsync(command.Email, false, cancellationToken);
		}

		public void SetupIsNameUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupIsNameUniqueAsync(command.Name, true, cancellationToken);
		}

		public void SetupIsNameUniqueAsync(
			UpdateUserCommand command,
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
			CancellationToken cancellationToken)
		{
			repository.SetupIsNameUniqueAsync(command.Name, false, cancellationToken);
		}

		public void RemoveIsNameUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupIsNameUniqueAsync(command.Name, false, cancellationToken);
		}

		public void SetupGetByIdAsync(
			UpdateUserCommand command,
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, user, cancellationToken);
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
			UserInclude include,
			User? user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, include, cancellationToken)
				.ReturnsTaskResponse(user);
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
			UserInclude include,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, null, cancellationToken);
		}

		public void SetupGetByNameAsync(
			Name name,
			UserInclude include,
			User? user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(name, include, cancellationToken)
				.ReturnsTaskResponse(user);
		}

		public void SetupGetByNameAsync(
			Name name,
			User? user,
			CancellationToken cancellationToken)
		{
			repository
				.GetByNameAsync(name, cancellationToken)
				.ReturnsTaskResponse(user);
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
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllUsersQuery query,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllAsync(query.Filter, query.Sorting, query.Pagination, query.Current, users.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllAsync(
			UsersFilterQuery filter,
			UsersSortingQuery sorting,
			UsersPaginationQuery pagination,
			CurrentUserQuery current,
			ICollection<UserResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(filter, sorting, pagination, current, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountAsync(
			GetAllUsersQuery query,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountAsync(query.Filter, users.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountAsync(
			UsersFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetByIdAsync(
			GetUserByIdQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.Current, user.ToResponse(query), cancellationToken);
		}

		public void SetupGetByIdAsync(
			UserId id,
			CurrentUserQuery current,
			UserResponse? response,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, current, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void RemoveGetByIdAsync(
			GetUserByIdQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.Current, null, cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenFactory factory)
	{
		public void SetupCreate(
			AddUserCommand command,
			EmailConfirmationToken emailConfirmationToken)
		{
			factory.SetupCreate(emailConfirmationToken.Id.Id, emailConfirmationToken.To(command));
		}
	}

	extension(IUserQueryService service)
	{
		public void SetupGetAllAsync(
			GetAllUsersQuery query,
			UserCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetUserByIdQuery query,
			UserResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query, cancellationToken)
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
