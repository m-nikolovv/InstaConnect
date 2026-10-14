using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;


public static class ForgotPasswordTokenEquals
{
	extension(AddForgotPasswordTokenCommandRequest command)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request)
		{
			return command.Name == request.Name;
		}
	}

	extension(VerifyForgotPasswordTokenCommandRequest command)
	{
		public bool Matches(VerifyForgotPasswordTokenApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Value == request.Value &&
				   command.Password == request.Body.Password &&
				   command.ConfirmPassword == request.Body.ConfirmPassword;
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyForgotPasswordTokenApiRequest request, IPasswordHasher passwordHasher)
		{
			return user.Id.Matches(request.Id) &&
				   user.Name.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.Email.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.FirstName.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.LastName.IsNotNullOrEmptyOrWhiteSpace() &&
				   (user.ProfileImage == null || user.ProfileImage.Url.IsNotNullOrEmptyOrWhiteSpace()) &&
				   passwordHasher.IsMatch(request.Body.Password, user.PasswordHash) &&
				   user.IsEmailConfirmed &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc != default;
		}
	}

	extension(ForgotPasswordToken entity)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request)
		{
			return entity.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.CreatedAtUtc != default &&
				   entity.ExpiresAtUtc != default;
		}
	}

	extension(ICollection<ForgotPasswordToken> entities)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request)
		{
			return entities.AllAndNotEmpty(entity => entity.Matches(request));
		}
	}

	extension(ForgotPasswordTokenEventRequest r)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request, ForgotPasswordToken? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   r.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(VerifyForgotPasswordTokenApiRequest request, ForgotPasswordToken? entity)
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
		public bool Matches(AddForgotPasswordTokenApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(request.Name) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImage?.Url &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(VerifyForgotPasswordTokenApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImage?.Url &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(ForgotPasswordTokenAddedEventRequest r)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request, ForgotPasswordToken entity)
		{
			return r.ForgotPasswordToken.Matches(request, entity);
		}
	}

	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public bool Matches(AddForgotPasswordTokenApiRequest request, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return r.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}

	extension(ForgotPasswordTokenDeletedEventRequest r)
	{
		public bool Matches(VerifyForgotPasswordTokenApiRequest request, ForgotPasswordToken entity)
		{
			return r.ForgotPasswordToken.Matches(request, entity);
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public bool Matches(VerifyForgotPasswordTokenApiRequest request, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return r.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}
}
