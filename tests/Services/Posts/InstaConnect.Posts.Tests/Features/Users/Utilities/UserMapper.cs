using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public UserId ToId()
		{
			return user.Id;
		}

		public UserResponse ToFullResponse()
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
	}

	extension(ICollection<User> users)
	{
		public ICollection<UserResponse> ToFullResponse()
		{
			return [.. users.Select(user => user.ToFullResponse())];
		}
	}
}
