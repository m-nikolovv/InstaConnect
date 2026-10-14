using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

public class PostIncludeBuilder
{
	private readonly ICollection<PostsIncludeDescriptor> _descriptors;
	private readonly IPostIncludeDescriptorFactory _descriptorFactory;

	internal PostIncludeBuilder(
		ICollection<PostsIncludeDescriptor> descriptors,
		IPostIncludeDescriptorFactory descriptorFactory)
	{
		_descriptors = descriptors;
		_descriptorFactory = descriptorFactory;
	}

	public PostIncludeBuilder WithUser()
	{
		_descriptors.Add(_descriptorFactory.CreateUser());

		return this;
	}

	public PostIncludeBuilder WithUser(UserInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateUser());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public PostIncludeBuilder WithPostLikes()
	{
		_descriptors.Add(_descriptorFactory.CreatePostLikes());

		return this;
	}
	public PostIncludeBuilder WithPostLikes(PostLikeInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreatePostLikes());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public PostIncludeBuilder WithPostComments()
	{
		_descriptors.Add(_descriptorFactory.CreatePostComments());

		return this;
	}

	public PostIncludeBuilder WithPostComments(PostCommentInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreatePostComments());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public PostIncludeBuilder WithPostImages()
	{
		_descriptors.Add(_descriptorFactory.CreatePostImages());

		return this;
	}

	public PostInclude Build()
	{
		return new(_descriptors);
	}
}
