namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class AddPostApiRequestBuilderFactory
{
	public AddPostApiRequestBuilder Create(User user)
	{
		return new(user);
	}
}
