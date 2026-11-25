using InstaConnect.Identity.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;

public static class UserInfrastructureMatcher
{
	extension(User user)
	{
		public UserResponse IsUserResponse(CurrentUserQuery currentUserQuery)
		{
			return Matcher.Is<UserResponse>(p => p.Matches(user.Id, currentUserQuery, user));
		}
	}
}
