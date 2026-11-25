using InstaConnect.Identity.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(User p)
	{
		public bool Matches(
			UserId id,
			User user)
		{
			return p.Matches(user);
		}

		public bool Matches(
			Name name,
			User user)
		{
			return p.Matches(user);
		}

		public bool Matches(
			Email email,
			User user)
		{
			return p.Matches(user);
		}

		public bool MatchesFilter(UsersFilterQuery query)
		{
			return p.Name.Value.StartsWithOrdinalIgnoreCase(query.Name.Value) &&
				   p.FirstName.StartsWithOrdinalIgnoreCase(query.FirstName) &&
				   p.LastName.StartsWithOrdinalIgnoreCase(query.LastName);
		}
	}

	extension(UserResponse? response)
	{
		public bool Matches(
			UserId id,
			CurrentUserQuery currentUserQuery,
			User user)
		{
			return response.MatchesFull(user);
		}
	}

	extension(ICollection<UserResponse> response)
	{
		public bool MatchesFull(
			UsersPaginationQuery paginationQuery,
			Func<UserResponse, User, bool> matches,
			Func<User, bool> matchesFilter,
			ICollection<User> users)
		{
			return response.MatchesCollectionAndNotEmpty(paginationQuery,
											  users,
											  response => response.Id,
											  user => user.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesFull(
			UsersPaginationQuery paginationQuery,
			Func<UserResponse, User, bool> matches,
			Func<User, bool> matchesFilter,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													users,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool Matches(
			UsersFilterQuery filterQuery,
			UsersSortingQuery sortingQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<User> users)
		{
			return response.MatchesFull(
					   paginationQuery,
					   (response, user) => response.MatchesFull(user),
					   user => user.MatchesFilter(filterQuery),
					   users);
		}

		public bool Matches(
			UsersFilterQuery filterQuery,
			UsersSortingQuery sortingQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			return response.MatchesFull(
					   paginationQuery,
					   (response, user) => response.MatchesFull(user),
					   user => user.MatchesFilter(filterQuery),
					   users,
					   termTransformer);
		}
	}

	extension(long response)
	{
		public bool Matches(
			UsersFilterQuery filterQuery,
			ICollection<User> users)
		{
			return response == users.Count(user => user.MatchesFilter(filterQuery));
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
}
