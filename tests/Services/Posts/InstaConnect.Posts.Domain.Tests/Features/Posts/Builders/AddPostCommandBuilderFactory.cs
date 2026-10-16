namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class AddPostCommandBuilderFactory
{
	public AddPostCommandBuilder Create(User user, int numberOfImages)
	{
		return new(user, numberOfImages);
	}
}
