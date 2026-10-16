using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
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

		public UserId ToResponse(
			AddUserCommandRequest request)
		{
			return user.ToId();
		}

		public UserId ToResponse(
			UpdateUserCommandRequest request)
		{
			return user.ToId();
		}
	}
}
