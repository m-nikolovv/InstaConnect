namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class AddPostApiRequestBuilderFactory
{
	public AddPostApiRequestBuilder Create(User user, int numberOfImages)
	{
		return new(user, numberOfImages);
	}
}
