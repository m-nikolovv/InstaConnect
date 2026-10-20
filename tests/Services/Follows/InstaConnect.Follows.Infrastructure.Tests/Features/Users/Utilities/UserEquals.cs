using InstaConnect.Follows.Application.Features.Users.Commands.Add;
using InstaConnect.Follows.Application.Features.Users.Commands.Delete;
using InstaConnect.Follows.Application.Features.Users.Commands.Update;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(User user)
	{
		public bool Matches(UserAddedEventRequest request)
		{
			return user.Matches(request.User);
		}

		public bool Matches(UserUpdatedEventRequest request)
		{
			return user.Matches(request.User);
		}

		public bool Matches(
			UserId id,
			User u)
		{
			return user.Matches(u);
		}

		public bool Matches(
			Name name,
			User u)
		{
			return user.Matches(u);
		}

		public bool Matches(
			Email email,
			User u)
		{
			return user.Matches(u);
		}
	}

	extension(UserResponse? response)
	{
		public bool MatchesFull(User? user)
		{
			return response != null &&
				   user != null &&
				   user.Id.Matches(response.Id) &&
				   user.FirstName == response.FirstName &&
				   user.LastName == response.LastName &&
				   user.Name.Matches(response.Name) &&
				   user.Email.Matches(response.Email) &&
				   user.ProfileImageUrl.Matches(response.ProfileImageUrl) &&
				   user.CreatedAtUtc == response.CreatedAtUtc &&
				   user.UpdatedAtUtc == response.UpdatedAtUtc;
		}

		public bool Matches(
			UserId id,
			CurrentUserQuery currentUserQuery,
			User user)
		{
			return response.MatchesFull(user);
		}
	}

	extension(bool response)
	{
		public bool Matches(UserId id, User? user)
		{
			return response == (user != null);
		}

		public bool Matches(Name name, User? user)
		{
			return response == (user == null);
		}

		public bool Matches(Email email, User? user)
		{
			return response == (user == null);
		}
	}

	extension(UserAddedEventRequest r)
	{
		public bool Matches(UserAddedEventRequest request)
		{
			return r.User.Matches(request.User);
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public bool Matches(UserUpdatedEventRequest request)
		{
			return r.User.Matches(request.User);
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public bool Matches(UserDeletedEventRequest request)
		{
			return r.User.Matches(request.User);
		}
	}

	extension(AddUserCommandRequest command)
	{
		public bool Matches(UserAddedEventRequest request)
		{
			return command.Id == request.User.Id &&
				   command.Email == request.User.Email &&
				   command.Name == request.User.Name &&
				   command.FirstName == request.User.FirstName &&
				   command.LastName == request.User.LastName &&
				   command.ProfileImageUrl == request.User.ProfileImageUrl &&
				   command.CreatedAtUtc == request.User.CreatedAtUtc &&
				   command.UpdatedAtUtc == request.User.UpdatedAtUtc;
		}
	}

	extension(UpdateUserCommandRequest command)
	{
		public bool Matches(UserUpdatedEventRequest request)
		{
			return command.Id == request.User.Id &&
				   command.Email == request.User.Email &&
				   command.Name == request.User.Name &&
				   command.FirstName == request.User.FirstName &&
				   command.LastName == request.User.LastName &&
				   command.ProfileImageUrl == request.User.ProfileImageUrl &&
				   command.UpdatedAtUtc == request.User.UpdatedAtUtc;
		}
	}

	extension(DeleteUserCommandRequest command)
	{
		public bool Matches(UserDeletedEventRequest request)
		{
			return command.Id == request.User.Id;
		}
	}
}
