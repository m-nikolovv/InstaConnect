using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserId response)
	{
		public bool Matches(AddUserCommand command, User user)
		{
			return response.Matches(user.Id);
		}

		public bool Matches(UpdateUserCommand command, User user)
		{
			return response.Matches(command.Id);
		}
	}

	extension(User user)
	{
		public bool Matches(AddUserCommand command)
		{
			return user.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.Name.Matches(command.Name) &&
				   user.Email.Matches(command.Email) &&
				   user.FirstName == command.FirstName &&
				   user.LastName == command.LastName &&
				   user.ProfileImageUrl.Matches(command.ProfileImage?.GetUrlValue()) &&
				   user.PasswordHash.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.IsEmailNotConfirmed &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc != default;
		}

		public bool Matches(UpdateUserCommand command)
		{
			return user.Id.Matches(command.Id) &&
				   user.Name.Matches(command.Name) &&
				   user.Email.Matches(command.Email) &&
				   user.FirstName == command.FirstName &&
				   user.LastName == command.LastName &&
				   (command.ProfileImage == null || user.ProfileImageUrl.Matches(command.ProfileImage.GetUrlValue())) &&
				   user.PasswordHash.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc != default;
		}

		public bool Matches(DeleteUserCommand command)
		{
			return user.Id.Matches(command.Id) &&
				   user.Name.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.Email.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.FirstName.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.LastName.IsNotNullOrEmptyOrWhiteSpace() &&
				   (user.ProfileImageUrl == null || user.ProfileImageUrl.Value.IsNotNullOrEmptyOrWhiteSpace()) &&
				   user.PasswordHash.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.IsEmailConfirmed &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(UsersFilterQuery query)
		{
			return user.Name.Value.StartsWithOrdinalIgnoreCase(query.Name.Value) &&
				   user.FirstName.StartsWithOrdinalIgnoreCase(query.FirstName) &&
				   user.LastName.StartsWithOrdinalIgnoreCase(query.LastName);
		}
	}

	extension(UserResponse? response)
	{
		public bool MatchesFull(User? user)
		{
			return response != null &&
				   user != null &&
				   user.Id.Matches(response.Id) &&
				   user.FirstName == response.FirstName &&
				   user.LastName == response.LastName &&
				   user.Name.Matches(response.Name) &&
				   user.Email.Matches(response.Email) &&
				   user.ProfileImageUrl.Matches(response.ProfileImageUrl) &&
				   user.CreatedAtUtc == response.CreatedAtUtc &&
				   user.UpdatedAtUtc == response.UpdatedAtUtc;
		}

		public bool Matches(GetUserByIdQuery query, User user)
		{
			return response.MatchesFull(user);
		}
	}

	extension(UserCollectionResponse response)
	{
		public bool Matches(
			GetAllUsersQuery query,
			ICollection<User> users)
		{
			return response.MatchesCollectionResponse(query.Pagination, users.Count(user => user.MatchesFilter(query.Filter))) &&
				   response.Users.MatchesCollection(query.Pagination,
													users,
													response => response.Id,
													user => user.Id,
													(response, user) => response.MatchesFull(user),
													user => user.MatchesFilter(query.Filter));
		}

		public bool Matches(
			GetAllUsersQuery query,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			return response.MatchesCollectionResponse(query.Pagination, users.Count(user => user.MatchesFilter(query.Filter))) &&
				   response.Users.MatchesSortedCollection(query.Pagination,
														  users,
														  (response, user) => response.MatchesFull(user),
														  termTransformer,
														  user => user.MatchesFilter(query.Filter));
		}
	}

	extension(UserAddedEventRequest request)
	{
		public bool Matches(AddUserCommand command, User entity)
		{
			return request.User.Matches(command, entity);
		}
	}

	extension(UserUpdatedEventRequest request)
	{
		public bool Matches(UpdateUserCommand command, User entity)
		{
			return request.User.Matches(command, entity);
		}
	}

	extension(UserDeletedEventRequest request)
	{
		public bool Matches(DeleteUserCommand command, User entity)
		{
			return request.User.Matches(command, entity);
		}
	}

	extension(UserEventRequest request)
	{
		public bool Matches(AddUserCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(command.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(command.Email.Value) &&
				   request.FirstName == command.FirstName &&
				   request.LastName == command.LastName &&
				   request.ProfileImageUrl == command.ProfileImage?.GetUrlValue() &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdateUserCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(command.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(command.Email.Value) &&
				   request.FirstName == command.FirstName &&
				   request.LastName == command.LastName &&
				   (command.ProfileImage == null || request.ProfileImageUrl == command.ProfileImage.GetUrlValue()) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeleteUserCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public bool Matches(AddUserCommand command)
		{
			return emailConfirmationToken.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   emailConfirmationToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   emailConfirmationToken.CreatedAtUtc != default &&
				   emailConfirmationToken.ExpiresAtUtc != default;
		}

		public bool Matches(UpdateUserCommand command)
		{
			return emailConfirmationToken.Id.Id.Matches(command.Id) &&
				   emailConfirmationToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   emailConfirmationToken.CreatedAtUtc != default &&
				   emailConfirmationToken.ExpiresAtUtc != default;
		}
	}

	extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		public bool Matches(AddUserCommand command)
		{
			return emailConfirmationTokens.AllAndNotEmpty(emailConfirmationToken => emailConfirmationToken.Matches(command));
		}

		public bool Matches(UpdateUserCommand command)
		{
			return emailConfirmationTokens.AllAndNotEmpty(emailConfirmationToken => emailConfirmationToken.Matches(command));
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest r)
	{
		public bool Matches(AddUserCommand command, EmailConfirmationToken entity)
		{
			return r.EmailConfirmationToken.Matches(command, entity);
		}
	}

	extension(EmailConfirmationTokenEventRequest request)
	{
		public bool Matches(AddUserCommand command, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   request.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   request.User.Matches(command, entity.User) &&
				   request.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdateUserCommand command, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   request.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   request.User.Matches(command, entity.User) &&
				   request.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool Matches(AddUserCommand command, ICollection<EmailConfirmationToken> entities)
		{
			return r.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(command, e));
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest r)
	{
		public bool Matches(UpdateUserCommand command, EmailConfirmationToken entity)
		{
			return r.EmailConfirmationToken.Matches(command, entity);
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool Matches(UpdateUserCommand command, ICollection<EmailConfirmationToken> entities)
		{
			return r.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(command, e));
		}
	}
}
