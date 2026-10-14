using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEquals
{
	extension(AddForgotPasswordTokenCommand command)
	{
		public bool Matches(AddForgotPasswordTokenCommandRequest request)
		{
			return command.Name.Matches(request.Name);
		}
	}

	extension(VerifyForgotPasswordTokenCommand command)
	{
		public bool Matches(VerifyForgotPasswordTokenCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.Value) &&
				   command.Password == request.Password &&
				   command.ConfirmPassword == request.ConfirmPassword;
		}
	}

	extension(User user)
	{
		public bool Matches(VerifyForgotPasswordTokenCommandRequest request, IPasswordHasher passwordHasher)
		{
			return user.Id.Matches(request.Id) &&
				   user.Name.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.Email.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.FirstName.IsNotNullOrEmptyOrWhiteSpace() &&
				   user.LastName.IsNotNullOrEmptyOrWhiteSpace() &&
				   (user.ProfileImage == null || user.ProfileImage.Url.IsNotNullOrEmptyOrWhiteSpace()) &&
				   passwordHasher.IsMatch(request.Password, user.PasswordHash) &&
				   user.IsEmailConfirmed &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc != default;
		}
	}

	extension(ForgotPasswordToken entity)
	{
		public bool Matches(AddForgotPasswordTokenCommandRequest request)
		{
			return entity.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   entity.CreatedAtUtc != default &&
				   entity.ExpiresAtUtc != default;
		}
	}

	extension(ICollection<ForgotPasswordToken> entities)
	{
		public bool Matches(AddForgotPasswordTokenCommandRequest request)
		{
			return entities.AllAndNotEmpty(entity => entity.Matches(request));
		}
	}

	extension(ForgotPasswordTokenEventRequest r)
	{
		public bool Matches(AddForgotPasswordTokenCommandRequest request, ForgotPasswordToken? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   r.Value.EqualsOrdinalIgnoreCase(entity.Id.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.ExpiresAtUtc == entity.ExpiresAtUtc &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(VerifyForgotPasswordTokenCommandRequest request, ForgotPasswordToken? entity)
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
		public bool Matches(AddForgotPasswordTokenCommandRequest request, User? entity)
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

		public bool Matches(VerifyForgotPasswordTokenCommandRequest request, User? entity)
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
		public bool Matches(AddForgotPasswordTokenCommandRequest request, ForgotPasswordToken entity)
		{
			return r.ForgotPasswordToken.Matches(request, entity);
		}
	}

	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public bool Matches(AddForgotPasswordTokenCommandRequest request, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return r.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}

	extension(ForgotPasswordTokenDeletedEventRequest r)
	{
		public bool Matches(VerifyForgotPasswordTokenCommandRequest request, ForgotPasswordToken entity)
		{
			return r.ForgotPasswordToken.Matches(request, entity);
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public bool Matches(VerifyForgotPasswordTokenCommandRequest request, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return r.MatchesCollection(forgotPasswordTokens,
											  r => new(new(r.ForgotPasswordToken.Id), r.ForgotPasswordToken.Value),
											  f => f.Id,
											  (r, entity) => r.Matches(request, entity));
		}
	}
}
