namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetAllUsersApiRequestBuilderFactory
{
	public GetAllUsersApiRequestBuilder Create(User user, UserId currentId)
	{
		return new(user, currentId);
	}
}
