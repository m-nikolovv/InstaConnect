namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetCurrentUserDetailsByIdApiRequestBuilderFactory
{
	public GetCurrentUserDetailsByIdApiRequestBuilder Create(User user, UserId currentId)
	{
		return new(user, currentId);
	}
}
