using InstaConnect.Follows.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

public static class UserApplicationMatcher
{
	extension(AddUserCommandRequest request)
	{
		public AddUserCommand IsAddUserCommand()
		{
			return Matcher.Is<AddUserCommand>(u => u.Matches(request));
		}
	}

	extension(UpdateUserCommandRequest request)
	{
		public UpdateUserCommand IsUpdateUserCommand()
		{
			return Matcher.Is<UpdateUserCommand>(u => u.Matches(request));
		}
	}

	extension(DeleteUserCommandRequest request)
	{
		public DeleteUserCommand IsDeleteUserCommand()
		{
			return Matcher.Is<DeleteUserCommand>(u => u.Matches(request));
		}
	}
}
