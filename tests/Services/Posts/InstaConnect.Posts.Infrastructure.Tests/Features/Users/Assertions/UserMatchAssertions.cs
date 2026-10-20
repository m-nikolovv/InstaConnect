using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(User user)
	{
		public void ShouldSatisfy(UserId id, User u)
		{
			user.ShouldSatisfy(p => p.Matches(id, u));
		}

		public void ShouldSatisfy(Name name, User u)
		{
			user.ShouldSatisfy(p => p.Matches(name, u));
		}

		public void ShouldSatisfy(Email email, User u)
		{
			user.ShouldSatisfy(p => p.Matches(email, u));
		}

		public void ShouldSatisfy(UserAddedEventRequest request)
		{
			user.ShouldSatisfy(u => u.Matches(request));
		}

		public void ShouldSatisfy(UserUpdatedEventRequest request)
		{
			user.ShouldSatisfy(u => u.Matches(request));
		}
	}

	extension(UserResponse response)
	{
		public void ShouldSatisfy(UserId id, CurrentUserQuery currentUserQuery, User user)
		{
			response.ShouldSatisfy(p => p.Matches(id, currentUserQuery, user));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(UserId id, User? user)
		{
			response.ShouldSatisfy(p => p.Matches(id, user));
		}

		public void ShouldSatisfy(Name name, User? user)
		{
			response.ShouldSatisfy(p => p.Matches(name, user));
		}

		public void ShouldSatisfy(Email email, User? user)
		{
			response.ShouldSatisfy(p => p.Matches(email, user));
		}
	}

	extension(UserAddedEventRequest r)
	{
		public void ShouldSatisfy(UserAddedEventRequest request)
		{
			r.ShouldSatisfy(r => r.Matches(request));
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public void ShouldSatisfy(UserUpdatedEventRequest request)
		{
			r.ShouldSatisfy(r => r.Matches(request));
		}

	}

	extension(UserDeletedEventRequest r)
	{
		public void ShouldSatisfy(UserDeletedEventRequest request)
		{
			r.ShouldSatisfy(r => r.Matches(request));
		}
	}
}
