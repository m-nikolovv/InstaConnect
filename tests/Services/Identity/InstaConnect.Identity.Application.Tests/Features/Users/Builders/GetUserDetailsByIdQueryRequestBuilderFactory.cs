namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetUserDetailsByIdQueryRequestBuilderFactory
{
	public GetUserDetailsByIdQueryRequestBuilder Create(User user, UserId currentId)
	{
		return new(user, currentId);
	}
}
