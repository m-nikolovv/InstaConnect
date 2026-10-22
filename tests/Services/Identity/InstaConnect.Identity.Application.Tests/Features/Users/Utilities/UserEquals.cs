using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserAddedEventRequest r)
	{
		public bool Matches(AddUserCommandRequest request, User entity)
		{
			return r.User.Matches(request, entity);
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public bool Matches(UpdateCurrentUserCommandRequest request, User entity)
		{
			return r.User.Matches(request, entity);
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public bool Matches(DeleteUserCommandRequest request, User entity)
		{
			return r.User.Matches(request, entity);
		}

		public bool Matches(DeleteCurrentUserCommandRequest request, User entity)
		{
			return r.User.Matches(request, entity);
		}
	}

	extension(UserEventRequest r)
	{
		public bool Matches(AddUserCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(request.Name) &&
				   r.Email.EqualsOrdinalIgnoreCase(request.Email) &&
				   r.FirstName == request.FirstName &&
				   r.LastName == request.LastName &&
				   r.ProfileImageUrl == request.ProfileImage?.GetUrlValue() &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdateCurrentUserCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(request.Name) &&
				   r.Email.EqualsOrdinalIgnoreCase(request.Email) &&
				   r.FirstName == request.FirstName &&
				   r.LastName == request.LastName &&
				   (request.ProfileImage == null || r.ProfileImageUrl == request.ProfileImage.GetUrlValue()) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeleteUserCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeleteCurrentUserCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.CurrentId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(GetAllUsersQuery query)
	{
		public bool Matches(GetAllUsersQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllUsersQuery, UsersSortTerm, UsersSortingQuery, GetAllUsersQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllUsersQuery, UsersPaginationQuery, GetAllUsersQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllUsersQueryRequest request)
		{
			return query.Filter.Name.Matches(request.Name) &&
				   query.Filter.FirstName == request.FirstName &&
				   query.Filter.LastName == request.LastName;
		}
	}

	extension(GetUserByIdQuery query)
	{
		public bool Matches(GetUserByIdQueryRequest request)
		{
			return query.Id.Matches(request.Id) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool Matches(GetCurrentUserByIdQueryRequest request)
		{
			return query.Id.Matches(request.CurrentId) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool Matches(GetUserDetailsByIdQueryRequest request)
		{
			return query.Id.Matches(request.Id) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool Matches(GetCurrentUserDetailsByIdQueryRequest request)
		{
			return query.Id.Matches(request.CurrentId) &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddUserCommand command)
	{
		public bool Matches(AddUserCommandRequest request)
		{
			return command.Email.Matches(request.Email) &&
				   command.Name.Matches(request.Name) &&
				   command.FirstName == request.FirstName &&
				   command.LastName == request.LastName &&
				   command.Password == request.Password &&
				   command.ConfirmPassword == request.ConfirmPassword &&
				   command.ProfileImage == request.ProfileImage;
		}
	}

	extension(UpdateUserCommand command)
	{
		public bool Matches(UpdateCurrentUserCommandRequest request)
		{
			return command.Id.Matches(request.Id) &&
				   command.Email.Matches(request.Email) &&
				   command.Name.Matches(request.Name) &&
				   command.FirstName == request.FirstName &&
				   command.LastName == request.LastName &&
				   command.ProfileImage == request.ProfileImage;
		}
	}

	extension(DeleteUserCommand command)
	{
		public bool Matches(DeleteUserCommandRequest request)
		{
			return command.Id.Matches(request.Id);
		}

		public bool Matches(DeleteCurrentUserCommandRequest request)
		{
			return command.Id.Matches(request.CurrentId);
		}
	}

	extension(AddUserCommandResponse response)
	{
		public bool Matches(AddUserCommandRequest request, User user)
		{
			return response.Response.Matches(user.Id);
		}
	}

	extension(UpdateCurrentUserCommandResponse response)
	{
		public bool Matches(UpdateCurrentUserCommandRequest request, User user)
		{
			return response.Response.Matches(user.Id);
		}
	}

	extension(GetUserByIdQueryResponse response)
	{
		public bool Matches(GetUserByIdQueryRequest request, User user)
		{
			return response.Response.MatchesFull(user);
		}
	}

	extension(GetCurrentUserByIdQueryResponse response)
	{
		public bool Matches(GetCurrentUserByIdQueryRequest request, User user)
		{
			return response.Response.MatchesFull(user);
		}
	}

	extension(GetUserDetailsByIdQueryResponse response)
	{
		public bool Matches(GetUserDetailsByIdQueryRequest request, User user)
		{
			return response.Response.MatchesFull(request, user);
		}
	}

	extension(GetCurrentUserDetailsByIdQueryResponse response)
	{
		public bool Matches(GetCurrentUserDetailsByIdQueryRequest request, User user)
		{
			return response.Response.MatchesFull(request, user);
		}
	}

	extension(GetAllUsersQueryResponse response)
	{
		public bool Matches(
		GetAllUsersQueryRequest request,
		ICollection<User> users)
		{
			return response.Response.MatchesFull(
					   request,
					   (response, user) => response.MatchesFull(user),
					   user => user.MatchesFilter(request),
					   users);
		}

		public bool Matches(
			GetAllUsersQueryRequest request,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			return response.Response.MatchesFull(
					   request,
					   (response, user) => response.MatchesFull(user),
					   user => user.MatchesFilter(request),
					   users,
					   termTransformer);
		}
	}

	extension(User user)
	{
		public bool Matches(AddUserCommandRequest request, IPasswordHasher passwordHasher)
		{
			return user.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.FirstName == request.FirstName &&
				   user.LastName == request.LastName &&
				   user.Name.Matches(request.Name) &&
				   user.Email.Matches(request.Email) &&
				   user.ProfileImageUrl.Matches(request.ProfileImage?.GetUrlValue()) &&
				   passwordHasher.IsMatch(request.Password, user.PasswordHash) &&
				   user.IsEmailNotConfirmed &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc != default;
		}

		public bool Matches(UpdateCurrentUserCommandRequest request)
		{
			return user.Id.Matches(request.Id) &&
				   user.FirstName == request.FirstName &&
				   user.LastName == request.LastName &&
				   user.Name.Matches(request.Name) &&
				   user.Email.Matches(request.Email) &&
				   (request.ProfileImage == null || user.ProfileImageUrl.Matches(request.ProfileImage.GetUrlValue())) &&
				   user.PasswordHash.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllUsersQueryRequest request)
		{
			return user.Name.Value.StartsWithOrdinalIgnoreCase(request.Name) &&
				   user.FirstName.StartsWithOrdinalIgnoreCase(request.FirstName) &&
				   user.LastName.StartsWithOrdinalIgnoreCase(request.LastName);
		}
	}

	extension(UserIdCommandResponse response)
	{
		public bool Matches(UserId id)
		{
			return id.Matches(response.Id);
		}
	}

	extension(UserQueryResponse? response)
	{
		public bool MatchesFull(User? user)
		{
			return response != null &&
				   user != null &&
				   user.Id.Matches(response.Id) &&
				   user.FirstName == response.FirstName &&
				   user.LastName == response.LastName &&
				   user.Name.Matches(response.Name) &&
				   user.ProfileImageUrl.Matches(response.ProfileImageUrl) &&
				   user.CreatedAtUtc == response.CreatedAtUtc &&
				   user.UpdatedAtUtc == response.UpdatedAtUtc;
		}
	}

	extension(UserDetailsQueryResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, User? user)
		where TRequest : ICurrentUserableQueryRequest
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
	}

	extension(UserCollectionQueryResponse response)
	{
		public bool MatchesFull<TRequest>(
		TRequest request,
		Func<UserQueryResponse, User, bool> matches,
		Func<User, bool> matchesFilter,
		ICollection<User> users)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, users.Count(matchesFilter)) &&
				   response.Users.MatchesCollection(request,
													users,
													response => new(response.Id),
													user => user.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesFull<TRequest>(
			TRequest request,
			Func<UserQueryResponse, User, bool> matches,
			Func<User, bool> matchesFilter,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, users.Count(matchesFilter)) &&
				   response.Users.MatchesSortedCollection(request,
														  users,
														  matches,
														  termTransformer,
														  matchesFilter);
		}
	}

	extension(EmailConfirmationToken entity)
	{
		public bool Matches(AddUserCommandRequest request)
		{
			return entity.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.CreatedAtUtc != default &&
				   entity.ExpiresAtUtc != default;
		}

		public bool Matches(UpdateCurrentUserCommandRequest request)
		{
			return entity.Id.Id.Matches(request.Id) &&
				   entity.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.CreatedAtUtc != default &&
				   entity.ExpiresAtUtc != default;
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest r)
	{
		public bool Matches(AddUserCommandRequest request, EmailConfirmationToken entity)
		{
			return r.EmailConfirmationToken.Matches(request, entity);
		}
	}

	extension(EmailConfirmationTokenEventRequest r)
	{
		public bool Matches(AddUserCommandRequest request, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   r.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdateCurrentUserCommandRequest request, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool Matches(AddUserCommandRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(request, e));
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest r)
	{
		public bool Matches(UpdateCurrentUserCommandRequest request, EmailConfirmationToken entity)
		{
			return r.EmailConfirmationToken.Matches(request, entity);
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool Matches(UpdateCurrentUserCommandRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(request, e));
		}
	}

	extension(ICollection<EmailConfirmationToken> entities)
	{
		public bool Matches(AddUserCommandRequest request)
		{
			return entities.AllAndNotEmpty(entity => entity.Matches(request));
		}

		public bool Matches(UpdateCurrentUserCommandRequest request)
		{
			return entities.AllAndNotEmpty(entity => entity.Matches(request));
		}
	}

	extension<TQuery>(TQuery query) where TQuery : ICurrentUserableQuery
	{
		public bool MatchesCurrentUserable<TQueryRequest>(
		TQueryRequest request)
		where TQueryRequest : ICurrentUserableQueryRequest
		{
			return query.Current.Id.Matches(request.CurrentId);
		}
	}
}
