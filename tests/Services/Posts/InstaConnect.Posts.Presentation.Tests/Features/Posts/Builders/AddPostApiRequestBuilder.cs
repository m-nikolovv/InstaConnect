using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class AddPostApiRequestBuilder
{
	private string _userId;
	private string _title;
	private string _content;
	private ICollection<IFormFile> _images;

	public AddPostApiRequestBuilder(User user)
	{
		_userId = user.Id.Id;
		_title = PostDataFaker.GetTitle();
		_content = PostDataFaker.GetContent();
		_images = PostImageDataFaker.GetImages();
	}

	public AddPostApiRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public AddPostApiRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public AddPostApiRequestBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public AddPostApiRequestBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public AddPostApiRequestBuilder WithImages(IFormFileCollectionTransformer transformer)
	{
		_images = transformer.Transform(_images);

		return this;
	}

	public AddPostApiRequest Build()
	{
		return new(_userId, new(_title, _content, _images));
	}
}
