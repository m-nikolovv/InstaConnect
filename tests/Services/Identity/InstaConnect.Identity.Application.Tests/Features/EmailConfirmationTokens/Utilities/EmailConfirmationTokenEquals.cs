using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
	extension(AddEmailConfirmationTokenCommand command)
	{
		public bool Matches(AddEmailConfirmationTokenCommandRequest request)
		{
			return command.Name.Matches(request.Name);
		}
	}

	extension(VerifyEmailConfirmationTokenCommand command)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.Value);
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommandRequest request)
		{
			return user.Id.Matches(request.Id) &&
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
	}

	extension(EmailConfirmationToken entity)
	{
		public bool Matches(AddEmailConfirmationTokenCommandRequest request)
		{
			return entity.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.CreatedAtUtc != default &&
				   entity.ExpiresAtUtc != default;
		}
	}

	extension(ICollection<EmailConfirmationToken> entities)
	{
		public bool Matches(AddEmailConfirmationTokenCommandRequest request)
		{
			return entities.AllAndNotEmpty(entity => entity.Matches(request));
		}
	}

	extension(EmailConfirmationTokenEventRequest r)
	{
		public bool Matches(AddEmailConfirmationTokenCommandRequest request, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   r.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(VerifyEmailConfirmationTokenCommandRequest request, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   r.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest r)
	{
		public bool Matches(AddEmailConfirmationTokenCommandRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(request.Name) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(VerifyEmailConfirmationTokenCommandRequest request, User? entity)
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
	}

	extension(EmailConfirmationTokenAddedEventRequest r)
	{
		public bool Matches(AddEmailConfirmationTokenCommandRequest request, EmailConfirmationToken entity)
		{
			return r.EmailConfirmationToken.Matches(request, entity);
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public bool Matches(AddEmailConfirmationTokenCommandRequest request, ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return r.MatchesCollection(emailConfirmationTokens,
											  r => new(new(r.EmailConfirmationToken.Id), r.EmailConfirmationToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest r)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommandRequest request, EmailConfirmationToken entity)
		{
			return r.EmailConfirmationToken.Matches(request, entity);
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommandRequest request, ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return r.MatchesCollection(emailConfirmationTokens,
											  r => new(new(r.EmailConfirmationToken.Id), r.EmailConfirmationToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}
}
