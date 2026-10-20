using InstaConnect.Posts.Application.Features.Users.Commands.Add;
using InstaConnect.Posts.Application.Features.Users.Commands.Delete;
using InstaConnect.Posts.Application.Features.Users.Commands.Update;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Users.Utilities;

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
}
