namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class AddPostCommandRequestBuilderFactory
{
	public AddPostCommandRequestBuilder Create(User user, int numberOfImages)
	{
		return new(user, numberOfImages);
	}
}
