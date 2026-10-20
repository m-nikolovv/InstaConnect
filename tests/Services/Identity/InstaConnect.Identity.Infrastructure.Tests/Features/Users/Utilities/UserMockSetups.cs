using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserCollection collection)
	{
		public void SetupAggregateFluent(
			UserId id,
			IUserFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			UserId id,
			CurrentUserQuery currentUserQuery,
			IUserFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			Name name,
			IUserFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			Email email,
			IUserFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			UsersFilterQuery filterQuery,
			UsersSortingQuery sortingQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IUserFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			UsersFilterQuery filterQuery,
			IUserFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IUserFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IUserFluent fluent)
	{
		public void SetupGetCountAsync(
			UsersFilterQuery filterQuery,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(users.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupAnyAsync(
			UserId id,
			User? user,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(user != null, cancellationToken);
		}

		public void SetupAnyAsync(
			Name name,
			User? user,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(user != null, cancellationToken);
		}

		public void SetupAnyAsync(
			Email email,
			User? user,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(user != null, cancellationToken);
		}

		public void SetupApplyIncludes(
			UserId id,
			UserInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			Name name,
			UserInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			Email email,
			UserInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(UserInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(UserId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			UserId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(id);
		}

		public void SetupMatch(Name name)
		{
			fluent.Match(name).ReturnsResponse(fluent);
		}

		public void SetupMatch(Email email)
		{
			fluent.Match(email).ReturnsResponse(fluent);
		}

		public void SetupMatch(UsersFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			UsersFilterQuery filterQuery,
			UsersSortingQuery sortingQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupProjectToFullResponse(
			UserId id,
			CurrentUserQuery currentUserQuery,
			IUserResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			UsersFilterQuery filterQuery,
			UsersSortingQuery sortingQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IUserResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			CurrentUserQuery currentUserQuery,
			IUserResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			UserId id,
			User user,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(user, cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			Name name,
			User user,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(user, cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			Email email,
			User user,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(user, cancellationToken);
		}
	}

	extension(IUserResponseFluent fluent)
	{
		public void SetupApplySorting(
			UsersFilterQuery filterQuery,
			UsersSortingQuery sortingQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplySorting(sortingQuery);
		}

		public void SetupApplySorting(UsersSortingQuery sortingQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			UsersFilterQuery filterQuery,
			UsersSortingQuery sortingQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplyPagination(paginationQuery);
		}

		public void SetupApplyPagination(UsersPaginationQuery paginationQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			UsersFilterQuery filterQuery,
			UsersSortingQuery sortingQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(users.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			UserId id,
			CurrentUserQuery currentUserQuery,
			User user,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(user.ToResponse(id, currentUserQuery), cancellationToken);
		}
	}
}
