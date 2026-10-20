namespace InstaConnect.Posts.Domain.Features.Users.Helpers;

public class UserIncludeBuilder
{
	private readonly ICollection<PostsIncludeDescriptor> _descriptors;
	private readonly IUserIncludeDescriptorFactory _descriptorsFactory;

	public UserIncludeBuilder(
		ICollection<PostsIncludeDescriptor> descriptors,
		IUserIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}

	public UserIncludeBuilder WithPosts()
	{
		_descriptors.Add(_descriptorsFactory.CreatePosts());

		return this;
	}

	public UserIncludeBuilder WithPosts(PostInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreatePosts());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserIncludeBuilder WithPostLikes()
	{
		_descriptors.Add(_descriptorsFactory.CreatePostLikes());

		return this;
	}

	public UserIncludeBuilder WithPostLikes(PostLikeInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreatePostLikes());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserIncludeBuilder WithPostComments()
	{
		_descriptors.Add(_descriptorsFactory.CreatePostComments());

		return this;
	}

	public UserIncludeBuilder WithPostComments(PostCommentInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreatePostComments());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserIncludeBuilder WithPostCommentLikes()
	{
		_descriptors.Add(_descriptorsFactory.CreatePostCommentLikes());

		return this;
	}

	public UserIncludeBuilder WithPostCommentLikes(PostCommentLikeInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreatePostCommentLikes());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserInclude Build()
	{
		return new(_descriptors);
	}
}
