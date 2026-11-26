namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetCurrentUserByIdApiRequestBuilderFactory
{
	public GetCurrentUserByIdApiRequestBuilder Create(User user, UserId currentId)
	{
		return new(user, currentId);
	}
}
