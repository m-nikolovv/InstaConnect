using InstaConnect.Chats.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;

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
