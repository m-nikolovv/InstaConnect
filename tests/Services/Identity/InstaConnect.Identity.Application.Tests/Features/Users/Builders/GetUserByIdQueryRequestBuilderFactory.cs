namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetUserByIdQueryRequestBuilderFactory
{
	public GetUserByIdQueryRequestBuilder Create(User user, UserId currentId)
	{
		return new(user, currentId);
	}
}
