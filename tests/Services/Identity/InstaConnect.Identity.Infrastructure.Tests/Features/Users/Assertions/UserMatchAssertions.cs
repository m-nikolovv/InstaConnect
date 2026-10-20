using InstaConnect.Identity.Domain.Features.Users.Models.Responses;
using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(User response)
	{
		public void ShouldSatisfy(UserId id, User user)
		{
			response.ShouldSatisfy(p => p.Matches(id, user));
		}

		public void ShouldSatisfy(Name name, User user)
		{
			response.ShouldSatisfy(p => p.Matches(name, user));
		}

		public void ShouldSatisfy(Email email, User user)
		{
			response.ShouldSatisfy(p => p.Matches(email, user));
		}
	}

	extension(UserResponse response)
	{
		public void ShouldSatisfy(UserId id, CurrentUserQuery currentUserQuery, User user)
		{
			response.ShouldSatisfy(p => p.Matches(id, currentUserQuery, user));
		}
	}

	extension(ICollection<UserResponse> response)
	{
		public void ShouldSatisfy(
			UsersFilterQuery filterQuery,
			UsersSortingQuery sortingQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<User> users)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, users));
		}

		public void ShouldSatisfy(
			UsersFilterQuery filterQuery,
			UsersSortingQuery sortingQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, users, termTransformer));
		}
	}

	extension(long response)
	{
		public void ShouldSatisfy(
			UsersFilterQuery filterQuery,
			ICollection<User> users)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, users));
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
}
