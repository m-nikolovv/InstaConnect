namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

public class PostCommentIncludeBuilder
{
	private readonly ICollection<PostsIncludeDescriptor> _descriptors;
	private readonly IPostCommentIncludeDescriptorFactory _descriptorFactory;

	internal PostCommentIncludeBuilder(
		ICollection<PostsIncludeDescriptor> descriptors,
		IPostCommentIncludeDescriptorFactory descriptorFactory)
	{
		_descriptors = descriptors;
		_descriptorFactory = descriptorFactory;
	}

	public PostCommentIncludeBuilder WithUser()
	{
		_descriptors.Add(_descriptorFactory.CreateUser());

		return this;
	}

	public PostCommentIncludeBuilder WithUser(UserInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateUser());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public PostCommentIncludeBuilder WithPost()
	{
		_descriptors.Add(_descriptorFactory.CreatePost());

		return this;
	}

	public PostCommentIncludeBuilder WithPost(PostInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreatePost());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public PostCommentIncludeBuilder WithPostCommentLikes()
	{
		_descriptors.Add(_descriptorFactory.CreatePostCommentLikes());

		return this;
	}

	public PostCommentIncludeBuilder WithPostCommentLikes(PostCommentLikeInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreatePostCommentLikes());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public PostCommentIncludeBuilder WithPostCommentImages()
	{
		_descriptors.Add(_descriptorFactory.CreatePostCommentImages());

		return this;
	}

	public PostCommentInclude Build()
	{
		return new(_descriptors);
	}
}
