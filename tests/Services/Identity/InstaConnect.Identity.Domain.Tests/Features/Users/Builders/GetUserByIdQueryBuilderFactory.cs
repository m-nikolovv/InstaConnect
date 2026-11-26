namespace InstaConnect.Identity.Domain.Tests.Features.Users.Builders;

public class GetUserByIdQueryBuilderFactory
{
	public GetUserByIdQueryBuilder Create(User user, UserId currentUserId)
	{
		return new(user, currentUserId);
	}
}
