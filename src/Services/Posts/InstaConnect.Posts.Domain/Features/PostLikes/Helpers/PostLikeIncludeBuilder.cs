namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

public class PostLikeIncludeBuilder
{
	private readonly ICollection<PostsIncludeDescriptor> _descriptors;
	private readonly IPostLikeIncludeDescriptorFactory _descriptorFactory;

	public PostLikeIncludeBuilder(
		ICollection<PostsIncludeDescriptor> descriptors,
		IPostLikeIncludeDescriptorFactory descriptorFactory)
	{
		_descriptors = descriptors;
		_descriptorFactory = descriptorFactory;
	}

	public PostLikeIncludeBuilder WithUser()
	{
		_descriptors.Add(_descriptorFactory.CreateUser());

		return this;
	}

	public PostLikeIncludeBuilder WithUser(UserInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateUser());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public PostLikeIncludeBuilder WithPost()
	{
		_descriptors.Add(_descriptorFactory.CreatePost());

		return this;
	}

	public PostLikeIncludeBuilder WithPost(PostInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreatePost());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public PostLikeInclude Build()
	{
		return new(_descriptors);
	}
}
