using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class AddPostCommentApiRequestBuilder
{
	private string _id;
	private string _userId;
	private string _content;
	private ICollection<IFormFile> _images;

	public AddPostCommentApiRequestBuilder(Post post, User user)
	{
		_id = post.Id.Id;
		_userId = user.Id.Id;
		_content = PostCommentDataFaker.GetContent();
		_images = PostCommentImageDataFaker.GetImages();
	}

	public AddPostCommentApiRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AddPostCommentApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AddPostCommentApiRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public AddPostCommentApiRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public AddPostCommentApiRequestBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public AddPostCommentApiRequestBuilder WithImages(IFormFileCollectionTransformer transformer)
	{
		_images = transformer.Transform(_images);

		return this;
	}

	public AddPostCommentApiRequest Build()
	{
		return new(_id, _userId, new(_content, _images));
	}
}
