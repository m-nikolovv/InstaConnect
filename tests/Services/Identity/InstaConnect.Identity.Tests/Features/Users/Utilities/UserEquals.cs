namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(User entity)
	{
		public bool Matches(User user)
		{
			return entity.Id.Matches(user.Id) &&
				   entity.Name.Matches(user.Name) &&
				   entity.Email.Matches(user.Email) &&
				   entity.FirstName == user.FirstName &&
				   entity.LastName == user.LastName &&
				   entity.ProfileImageUrl.Matches(user.ProfileImageUrl) &&
				   entity.PasswordHash == user.PasswordHash &&
				   entity.CreatedAtUtc == user.CreatedAtUtc &&
				   entity.UpdatedAtUtc == user.UpdatedAtUtc;
		}
	}

	extension(UserId p)
	{
		public bool Matches(UserId id)
		{
			return p.Matches(id.Id);
		}

		public bool Matches(string id)
		{
			return p.Id.EqualsOrdinalIgnoreCase(id);
		}
	}
}
