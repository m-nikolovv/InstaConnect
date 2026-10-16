using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public UserQueryResponse ToFullQueryResponse()
		{
			return new(user.Id.Id,
					   user.FirstName,
					   user.LastName,
					   user.Name.Value,
					   user.ProfileImageUrl?.Value,
					   user.CreatedAtUtc,
					   user.UpdatedAtUtc);
		}
	}
}
