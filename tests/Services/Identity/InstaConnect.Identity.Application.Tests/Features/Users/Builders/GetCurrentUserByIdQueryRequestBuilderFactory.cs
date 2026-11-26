namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetCurrentUserByIdQueryRequestBuilderFactory
{
	public GetCurrentUserByIdQueryRequestBuilder Create(User user, UserId currentId)
	{
		return new(user, currentId);
	}
}
