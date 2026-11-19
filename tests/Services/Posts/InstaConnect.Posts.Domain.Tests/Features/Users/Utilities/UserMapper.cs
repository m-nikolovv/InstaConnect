namespace InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public User To(AddUserCommand command)
		{
			return new(command.Id,
					   command.FirstName,
					   command.LastName,
					   command.Email,
					   command.Name,
					   command.ProfileImageUrl,
					   command.CreatedAtUtc,
					   command.UpdatedAtUtc);
		}
	}
}
