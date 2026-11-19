namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetUserByIdApiRequestBuilderFactory
{
	public GetUserByIdApiRequestBuilder Create(User user, UserId currentId)
	{
		return new(user, currentId);
	}
}
