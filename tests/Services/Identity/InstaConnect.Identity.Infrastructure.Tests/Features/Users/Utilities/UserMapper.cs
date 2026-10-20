using InstaConnect.Identity.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;

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

		public UserResponse ToResponse(
			UserId id,
			CurrentUserQuery currentUserQuery)
		{
			return user.ToFullResponse();
		}
	}

	extension(ICollection<User> users)
	{
		public ICollection<UserResponse> ToResponse(
			UsersFilterQuery filterQuery,
			UsersPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return users.Filter(paginationQuery, user => user.MatchesFilter(filterQuery), user => user.ToFullResponse());
		}

		public long ToTotalCountResponse(
			UsersFilterQuery filterQuery)
		{
			return users.Count(user => user.MatchesFilter(filterQuery));
		}
	}
}
