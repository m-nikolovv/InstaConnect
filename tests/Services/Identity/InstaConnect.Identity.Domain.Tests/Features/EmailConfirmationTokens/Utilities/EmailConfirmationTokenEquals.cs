using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
	extension(EmailConfirmationTokenId response)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
		{
			return response.Matches(emailConfirmationToken.Id);
		}
	}

	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command)
		{
			return emailConfirmationToken.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   emailConfirmationToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   emailConfirmationToken.CreatedAtUtc != default &&
				   emailConfirmationToken.ExpiresAtUtc != default;
		}

		public bool Matches(VerifyEmailConfirmationTokenCommand command)
		{
			return emailConfirmationToken.Id.Id.Matches(command.Id.Id) &&
				   emailConfirmationToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   emailConfirmationToken.CreatedAtUtc != default &&
				   emailConfirmationToken.ExpiresAtUtc != default;
		}
	}

	extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command)
		{
			return emailConfirmationTokens.AllAndNotEmpty(emailConfirmationToken => emailConfirmationToken.Matches(command));
		}

		public bool Matches(VerifyEmailConfirmationTokenCommand command)
		{
			return emailConfirmationTokens.AllAndNotEmpty(emailConfirmationToken => emailConfirmationToken.Matches(command));
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommand command)
		{
			return user.Id.Matches(command.Id.Id) &&
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

	extension(EmailConfirmationTokenEventRequest request)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   request.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   request.User.Matches(command, entity.User) &&
				   request.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(VerifyEmailConfirmationTokenCommand command, EmailConfirmationToken? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   request.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   request.User.Matches(command, entity.User) &&
				   request.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserEventRequest request)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(command.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(VerifyEmailConfirmationTokenCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(EmailConfirmationTokenAddedEventRequest request)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, EmailConfirmationToken entity)
		{
			return request.MatchesId(entity.Id.Value) &&
				   request.EmailConfirmationToken.Matches(command, entity);
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> requests)
	{
		public bool Matches(AddEmailConfirmationTokenCommand command, ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return requests.MatchesCollection(emailConfirmationTokens,
											  r => new(new(r.EmailConfirmationToken.Id), r.EmailConfirmationToken.Value),
											  f => f.Id,
											  (request, entity) => request.Matches(command, entity));
		}
	}

	extension(EmailConfirmationTokenDeletedEventRequest request)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommand command, EmailConfirmationToken entity)
		{
			return request.MatchesId(command.Id.Value) &&
				   request.EmailConfirmationToken.Matches(command, entity);
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> requests)
	{
		public bool Matches(VerifyEmailConfirmationTokenCommand command, ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return requests.MatchesCollection(emailConfirmationTokens,
											  r => new(new(r.EmailConfirmationToken.Id), r.EmailConfirmationToken.Value),
											  f => f.Id,
											  (request, entity) => request.Matches(command, entity));
		}
	}
}
