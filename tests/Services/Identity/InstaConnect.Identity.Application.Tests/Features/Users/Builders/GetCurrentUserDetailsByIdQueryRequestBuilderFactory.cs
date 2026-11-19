namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetCurrentUserDetailsByIdQueryRequestBuilderFactory
{
	public GetCurrentUserDetailsByIdQueryRequestBuilder Create(User user, UserId currentId)
	{
		return new(user, currentId);
	}
}
