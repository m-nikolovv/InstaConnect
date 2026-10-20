namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

public class PostCommentLikeIncludeBuilder
{
	private readonly ICollection<PostsIncludeDescriptor> _descriptors;
	private readonly IPostCommentLikeIncludeDescriptorFactory _descriptorsFactory;

	internal PostCommentLikeIncludeBuilder(
		ICollection<PostsIncludeDescriptor> descriptors,
		IPostCommentLikeIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}

	public PostCommentLikeIncludeBuilder WithUser()
	{
		_descriptors.Add(_descriptorsFactory.CreateUser());

		return this;
	}

	public PostCommentLikeIncludeBuilder WithUser(UserInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateUser());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public PostCommentLikeIncludeBuilder WithPostComment()
	{
		_descriptors.Add(_descriptorsFactory.CreatePostComment());

		return this;
	}

	public PostCommentLikeIncludeBuilder WithPostComment(PostCommentInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreatePostComment());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public PostCommentLikeInclude Build()
	{
		return new(_descriptors);
	}
}
