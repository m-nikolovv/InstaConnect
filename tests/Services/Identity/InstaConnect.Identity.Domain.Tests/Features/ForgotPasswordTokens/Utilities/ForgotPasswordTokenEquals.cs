using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEquals
{
	extension(ForgotPasswordTokenId response)
	{
		public bool Matches(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
		{
			return response.Matches(forgotPasswordToken.Id);
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyForgotPasswordTokenCommand command, IPasswordHasher passwordHasher)
		{
			return user.Id.Matches(command.Id.Id) &&
				   user.Name.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.Email.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.FirstName.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.LastName.IsNotNullOrEmptyOrWhiteSpace() &&
				   (user.ProfileImageUrl == null || user.ProfileImageUrl.Value.IsNotNullOrEmptyOrWhiteSpace()) &&
				   passwordHasher.IsMatch(command.Password, user.PasswordHash) &&
				   user.IsEmailConfirmed &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc != default;
		}
	}

	extension(ForgotPasswordTokenEventRequest request)
	{
		public bool Matches(AddForgotPasswordTokenCommand command, ForgotPasswordToken? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   request.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   request.User.Matches(command, entity.User) &&
				   request.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(VerifyForgotPasswordTokenCommand command, ForgotPasswordToken? entity)
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
		public bool Matches(AddForgotPasswordTokenCommand command, User? entity)
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

		public bool Matches(VerifyForgotPasswordTokenCommand command, User? entity)
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

	extension(ForgotPasswordToken forgotPasswordToken)
	{
		public bool Matches(AddForgotPasswordTokenCommand command)
		{
			return forgotPasswordToken.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   forgotPasswordToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   forgotPasswordToken.CreatedAtUtc != default &&
				   forgotPasswordToken.ExpiresAtUtc != default;
		}

		public bool Matches(VerifyForgotPasswordTokenCommand command)
		{
			return forgotPasswordToken.Id.Id.Matches(command.Id.Id) &&
				   forgotPasswordToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   forgotPasswordToken.CreatedAtUtc != default &&
				   forgotPasswordToken.ExpiresAtUtc != default;
		}
	}

	extension(ICollection<ForgotPasswordToken> forgotPasswordTokens)
	{
		public bool Matches(AddForgotPasswordTokenCommand command)
		{
			return forgotPasswordTokens.AllAndNotEmpty(forgotPasswordToken => forgotPasswordToken.Matches(command));
		}

		public bool Matches(VerifyForgotPasswordTokenCommand command)
		{
			return forgotPasswordTokens.AllAndNotEmpty(forgotPasswordToken => forgotPasswordToken.Matches(command));
		}
	}

	extension(ForgotPasswordTokenAddedEventRequest request)
	{
		public bool Matches(AddForgotPasswordTokenCommand command, ForgotPasswordToken entity)
		{
			return request.ForgotPasswordToken.Matches(command, entity);
		}
	}

	extension(ICollection<ForgotPasswordTokenAddedEventRequest> requests)
	{
		public bool Matches(AddForgotPasswordTokenCommand command, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return requests.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (request, entity) => request.Matches(command, entity));
		}
	}

	extension(ForgotPasswordTokenDeletedEventRequest request)
	{
		public bool Matches(VerifyForgotPasswordTokenCommand command, ForgotPasswordToken entity)
		{
			return request.ForgotPasswordToken.Matches(command, entity);
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> requests)
	{
		public bool Matches(VerifyForgotPasswordTokenCommand command, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return requests.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (request, entity) => request.Matches(command, entity));
		}
	}
}
