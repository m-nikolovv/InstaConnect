namespace InstaConnect.Follows.Domain.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserId response)
	{
		public bool Matches(
		AddUserCommand command,
		User user)
		{
			return response.Matches(command.Id);
		}

		public bool Matches(
		UpdateUserCommand command,
		User user)
		{
			return response.Matches(command.Id);
		}
	}

	extension(User u)
	{
		public bool Matches(AddUserCommand command)
		{
			return u.Id.Matches(command.Id) &&
				   u.FirstName == command.FirstName &&
				   u.LastName == command.LastName &&
				   u.Name.Matches(command.Name) &&
				   u.Email.Matches(command.Email) &&
				   u.ProfileImageUrl.Matches(command.ProfileImageUrl) &&
				   u.CreatedAtUtc == command.CreatedAtUtc &&
				   u.UpdatedAtUtc == command.UpdatedAtUtc;
		}

		public bool Matches(UpdateUserCommand command)
		{
			return u.Id.Matches(command.Id) &&
				   u.FirstName == command.FirstName &&
				   u.LastName == command.LastName &&
				   u.Name.Matches(command.Name) &&
				   u.Email.Matches(command.Email) &&
				   u.ProfileImageUrl.Matches(command.ProfileImageUrl) &&
				   u.CreatedAtUtc != default &&
				   u.UpdatedAtUtc == command.UpdatedAtUtc;
		}

		public bool Matches(DeleteUserCommand command)
		{
			return u.Id.Matches(command.Id) &&
				   u.Name.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   u.Email.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   u.FirstName.IsNotNullOrEmptyOrWhiteSpace() &&
				   u.LastName.IsNotNullOrEmptyOrWhiteSpace() &&
				   (u.ProfileImageUrl == null || u.ProfileImageUrl.Value.IsNotNullOrEmptyOrWhiteSpace()) &&
				   u.CreatedAtUtc != default &&
				   u.UpdatedAtUtc != default;
		}
	}
}
