namespace InstaConnect.Identity.Domain.Tests.Features.Users.Builders;

public class GetAllUsersQueryBuilderFactory
{
	public GetAllUsersQueryBuilder Create(User user, UserId currentUserId)
	{
		return new(user, currentUserId);
	}
}
