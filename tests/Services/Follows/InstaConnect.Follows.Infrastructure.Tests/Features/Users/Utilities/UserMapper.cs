using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			UserId id,
			CurrentUserQuery currentUserQuery)
		{
			return user.ToFullResponse();
		}
	}
}
