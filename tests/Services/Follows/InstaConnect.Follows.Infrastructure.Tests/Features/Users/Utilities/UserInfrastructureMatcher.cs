using InstaConnect.Follows.Application.Features.Users.Commands.Add;
using InstaConnect.Follows.Application.Features.Users.Commands.Delete;
using InstaConnect.Follows.Application.Features.Users.Commands.Update;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;

public static class UserInfrastructureMatcher
{
	extension(UserAddedEventRequest request)
	{
		public AddUserCommandRequest IsAddUserCommandRequest()
		{
			return Matcher.Is<AddUserCommandRequest>(u => u.Matches(request));
		}
	}

	extension(UserUpdatedEventRequest request)
	{
		public UpdateUserCommandRequest IsUpdateUserCommandRequest()
		{
			return Matcher.Is<UpdateUserCommandRequest>(u => u.Matches(request));
		}
	}

	extension(UserDeletedEventRequest request)
	{
		public DeleteUserCommandRequest IsDeleteUserCommandRequest()
		{
			return Matcher.Is<DeleteUserCommandRequest>(u => u.Matches(request));
		}
	}

	extension(User user)
	{
		public UserResponse IsUserResponse(CurrentUserQuery currentUserQuery)
		{
			return Matcher.Is<UserResponse>(p => p.Matches(user.Id, currentUserQuery, user));
		}
	}
}
