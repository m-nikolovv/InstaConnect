using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class AddPostCommentCommandBuilder
{
	private string _id;
	private string _content;
	private string _userId;
	private ICollection<IFormFile> _images;

	public AddPostCommentCommandBuilder(Post post, User user, int numberOfImages)
	{
		_id = post.Id.Id;
		_content = PostCommentDataFaker.GetContent();
		_userId = user.Id.Id;
		_images = PostCommentImageDataFaker.GetImages(numberOfImages);
	}

	public AddPostCommentCommandBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AddPostCommentCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AddPostCommentCommandBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public AddPostCommentCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public AddPostCommentCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public AddPostCommentCommandBuilder WithImages(IFormFileCollectionTransformer transformer)
	{
		_images = transformer.Transform(_images);

		return this;
	}

	public AddPostCommentCommand Build()
	{
		return new(
			new(_id),
			_content,
			new(_userId),
			_images);
	}
}
