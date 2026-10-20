using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

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

		public UserId ToResponse(
			AddUserCommandRequest request)
		{
			return new(request.Id);
		}

		public UserId ToResponse(
			UpdateUserCommandRequest request)
		{
			return user.ToId();
		}
	}
}
