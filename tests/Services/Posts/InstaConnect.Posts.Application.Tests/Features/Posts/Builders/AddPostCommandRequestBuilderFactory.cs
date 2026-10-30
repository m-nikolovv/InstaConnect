namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class AddPostCommandRequestBuilderFactory
{
	public AddPostCommandRequestBuilder Create(User user)
	{
		return new(user);
	}
}
