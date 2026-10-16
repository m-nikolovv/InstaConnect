namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		internal UserResponse ToFullResponse()
		{
			return new(user.Id,
					   user.FirstName,
					   user.LastName,
					   user.Email,
					   user.Name,
					   user.ProfileImageUrl,
					   user.CreatedAtUtc,
					   user.UpdatedAtUtc);
		}

		public User To(AddUserCommand command)
		{
			return new(
				user.Id,
				command.FirstName,
				command.LastName,
				command.Email,
				command.Name,
				user.PasswordHash,
				false,
				null,
				user.CreatedAtUtc,
				user.UpdatedAtUtc);
		}

		public UserId ToResponse(
			AddUserCommand command)
		{
			return user.ToId();
		}

		public UserId ToResponse(
			UpdateUserCommand command)
		{
			return user.ToId();
		}

		public UserResponse ToResponse(
			GetUserByIdQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(ICollection<User> users)
	{
		public ICollection<UserResponse> ToResponse(
			GetAllUsersQuery query)
		{
			return users.Filter(query.Pagination, user => user.MatchesFilter(query.Filter), user => user.ToFullResponse());
		}

		public long ToTotalCountResponse(
			GetAllUsersQuery query)
		{
			return users.Count(user => user.MatchesFilter(query.Filter));
		}
	}

	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public EmailConfirmationToken To(AddUserCommand command)
		{
			return new EmailConfirmationToken(
				emailConfirmationToken.Id,
				emailConfirmationToken.ExpiresAtUtc,
				emailConfirmationToken.CreatedAtUtc).AddUser(emailConfirmationToken.User?.To(command));
		}
	}
}
