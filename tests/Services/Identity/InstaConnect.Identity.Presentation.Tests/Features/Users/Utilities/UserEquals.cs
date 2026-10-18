using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Presentation.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserAddedEventRequest r)
	{
		public bool Matches(AddUserApiRequest request, User entity)
		{
			return r.User.Matches(request, entity);
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public bool Matches(UpdateCurrentUserApiRequest request, User entity)
		{
			return r.User.Matches(request, entity);
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public bool Matches(DeleteUserApiRequest request, User entity)
		{
			return r.User.Matches(request, entity);
		}

		public bool Matches(DeleteCurrentUserApiRequest request, User entity)
		{
			return r.User.Matches(request, entity);
		}
	}

	extension(UserEventRequest r)
	{
		public bool Matches(AddUserApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(request.Form.Name) &&
				   r.Email.EqualsOrdinalIgnoreCase(request.Form.Email) &&
				   r.FirstName == request.Form.FirstName &&
				   r.LastName == request.Form.LastName &&
				   r.ProfileImageUrl == request.Form.ProfileImage?.GetUrlValue() &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdateCurrentUserApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(request.Form.Name) &&
				   r.Email.EqualsOrdinalIgnoreCase(request.Form.Email) &&
				   r.FirstName == request.Form.FirstName &&
				   r.LastName == request.Form.LastName &&
				   (request.Form.ProfileImage == null || r.ProfileImageUrl == request.Form.ProfileImage.GetUrlValue()) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeleteUserApiRequest request, User? entity)
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

		public bool Matches(DeleteCurrentUserApiRequest request, User? entity)
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

	extension(GetAllUsersQueryRequest query)
	{
		public bool Matches(GetAllUsersApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllUsersQueryRequest, UsersSortTerm, GetAllUsersApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllUsersApiRequest request)
		{
			return query.Name == request.Name &&
				   query.FirstName == request.FirstName &&
				   query.LastName == request.LastName;
		}
	}

	extension(GetUserByIdQueryRequest query)
	{
		public bool Matches(GetUserByIdApiRequest request)
		{
			return query.Id == request.Id &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(GetUserDetailsByIdQueryRequest query)
	{
		public bool Matches(GetUserDetailsByIdApiRequest request)
		{
			return query.Id == request.Id &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(GetCurrentUserByIdQueryRequest query)
	{
		public bool Matches(GetCurrentUserByIdApiRequest request)
		{
			return query.CurrentId == request.CurrentId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(GetCurrentUserDetailsByIdQueryRequest query)
	{
		public bool Matches(GetCurrentUserDetailsByIdApiRequest request)
		{
			return query.CurrentId == request.CurrentId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddUserCommandRequest command)
	{
		public bool Matches(AddUserApiRequest request)
		{
			return command.Email == request.Form.Email &&
				   command.Name == request.Form.Name &&
				   command.FirstName == request.Form.FirstName &&
				   command.LastName == request.Form.LastName &&
				   command.Password == request.Form.Password &&
				   command.ConfirmPassword == request.Form.ConfirmPassword &&
				   command.ProfileImage == request.Form.ProfileImage;
		}
	}

	extension(UpdateCurrentUserCommandRequest command)
	{
		public bool Matches(UpdateCurrentUserApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Email == request.Form.Email &&
				   command.Name == request.Form.Name &&
				   command.FirstName == request.Form.FirstName &&
				   command.LastName == request.Form.LastName &&
				   command.ProfileImage == request.Form.ProfileImage;
		}
	}

	extension(DeleteUserCommandRequest command)
	{
		public bool Matches(DeleteUserApiRequest request)
		{
			return command.Id == request.Id;
		}
	}

	extension(DeleteCurrentUserCommandRequest command)
	{
		public bool Matches(DeleteCurrentUserApiRequest request)
		{
			return command.CurrentId == request.CurrentId;
		}
	}

	extension(AddUserApiResponse response)
	{
		public bool Matches(
		AddUserApiRequest request,
		User user)
		{
			return response.Response.Matches(user.Id);
		}
	}

	extension(UpdateCurrentUserApiResponse response)
	{
		public bool Matches(
		UpdateCurrentUserApiRequest request,
		User user)
		{
			return response.Response.Matches(user.Id);
		}
	}

	extension(GetUserByIdApiResponse response)
	{
		public bool Matches(GetUserByIdApiRequest request, User user)
		{
			return response.Response.MatchesFull(user);
		}
	}


	extension(GetUserDetailsByIdApiResponse response)
	{
		public bool Matches(GetUserDetailsByIdApiRequest request, User user)
		{
			return response.Response.MatchesFull(user);
		}
	}

	extension(GetCurrentUserByIdApiResponse response)
	{
		public bool Matches(GetCurrentUserByIdApiRequest request, User user)
		{
			return response.Response.MatchesFull(user);
		}
	}


	extension(GetCurrentUserDetailsByIdApiResponse response)
	{
		public bool Matches(GetCurrentUserDetailsByIdApiRequest request, User user)
		{
			return response.Response.MatchesFull(user);
		}
	}

	extension(GetAllUsersApiResponse response)
	{
		public bool Matches(
		GetAllUsersApiRequest request,
		ICollection<User> users)
		{
			return response.Response.MatchesFull(
					   request,
					   (response, user) => response.MatchesFull(user),
					   user => user.MatchesFilter(request),
					   users);
		}

		public bool Matches(
			GetAllUsersApiRequest request,
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
		public bool Matches(AddUserApiRequest request, IPasswordHasher passwordHasher)
		{
			return user.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.FirstName == request.Form.FirstName &&
				   user.LastName == request.Form.LastName &&
				   user.Name.Matches(request.Form.Name) &&
				   user.Email.Matches(request.Form.Email) &&
				   user.ProfileImageUrl.Matches(request.Form.ProfileImage?.GetUrlValue()) &&
				   passwordHasher.IsMatch(request.Form.Password, user.PasswordHash) &&
				   user.IsEmailNotConfirmed &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc != default;
		}

		public bool Matches(UpdateCurrentUserApiRequest request)
		{
			return user.Id.Matches(request.Id) &&
				   user.FirstName == request.Form.FirstName &&
				   user.LastName == request.Form.LastName &&
				   user.Name.Matches(request.Form.Name) &&
				   user.Email.Matches(request.Form.Email) &&
				   (request.Form.ProfileImage == null || user.ProfileImageUrl.Matches(request.Form.ProfileImage.GetUrlValue())) &&
				   user.PasswordHash.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllUsersApiRequest request)
		{

			return user.Name.Value.StartsWithOrdinalIgnoreCase(request.Name) &&
				   user.FirstName.StartsWithOrdinalIgnoreCase(request.FirstName) &&
				   user.LastName.StartsWithOrdinalIgnoreCase(request.LastName);
		}
	}

	extension(UserIdApiResponse response)
	{
		public bool Matches(UserId id)
		{
			return id.Matches(response.Id);
		}
	}

	extension(UserApiResponse? response)
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

	extension(UserDetailsApiResponse? response)
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
	}

	extension(UserCollectionApiResponse response)
	{
		public bool MatchesFull<TRequest>(
		TRequest request,
		Func<UserApiResponse, User, bool> matches,
		Func<User, bool> matchesFilter,
		ICollection<User> users)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<UserApiResponse, User, bool> matches,
			Func<User, bool> matchesFilter,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, users.Count(matchesFilter)) &&
				   response.Users.MatchesSortedCollection(request,
														  users,
														  matches,
														  termTransformer,
														  matchesFilter);
		}
	}



	extension(EmailConfirmationTokenAddedEventRequest r)
	{
		public bool Matches(AddUserApiRequest request, EmailConfirmationToken entity)
		{
			return r.EmailConfirmationToken.Matches(request, entity);
		}
	}

	extension(EmailConfirmationTokenEventRequest r)
	{
		public bool Matches(AddUserApiRequest request, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   r.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdateCurrentUserApiRequest request, EmailConfirmationToken? entity)
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
		public bool Matches(AddUserApiRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(request, e));
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest r)
	{
		public bool Matches(UpdateCurrentUserApiRequest request, EmailConfirmationToken entity)
		{
			return r.EmailConfirmationToken.Matches(request, entity);
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool Matches(UpdateCurrentUserApiRequest request, ICollection<EmailConfirmationToken> entities)
		{
			return r.MatchesCollection(entities,
											  e => new(new(e.EmailConfirmationToken.Id), e.EmailConfirmationToken.Value),
											  e => e.Id,
											  (emailConfirmationToken, e) => emailConfirmationToken.Matches(request, e));
		}
	}

	extension(EmailConfirmationToken entity)
	{
		public bool Matches(AddUserApiRequest request)
		{
			return entity.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.CreatedAtUtc != default &&
				   entity.ExpiresAtUtc != default;
		}
	}

	extension(ICollection<EmailConfirmationToken> entities)
	{
		public bool Matches(AddUserApiRequest request)
		{
			return entities.AllAndNotEmpty(entity => entity.Matches(request));
		}

		public bool Matches(UpdateCurrentUserApiRequest request)
		{
			return entities.AllAndNotEmpty(entity => entity.Id.Id.Matches(request.Id));
		}
	}

	extension<TQueryRequest>(TQueryRequest query) where TQueryRequest : ICurrentUserableQueryRequest
	{
		public bool MatchesCurrentUserable<TApiRequest>(
		TApiRequest request)
		where TApiRequest : ICurrentUserableApiRequest
		{
			return query.CurrentId == request.CurrentId;
		}
	}
}
