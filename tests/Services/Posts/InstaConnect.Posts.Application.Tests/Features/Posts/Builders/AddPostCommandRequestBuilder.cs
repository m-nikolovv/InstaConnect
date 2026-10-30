using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class AddPostCommandRequestBuilder
{
	private string _userId;
	private string _title;
	private string _content;
	private ICollection<IFormFile> _images;

	public AddPostCommandRequestBuilder(User user)
	{
		_userId = user.Id.Id;
		_title = PostDataFaker.GetTitle();
		_content = PostDataFaker.GetContent();
		_images = PostImageDataFaker.GetImages();
	}

	public AddPostCommandRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public AddPostCommandRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public AddPostCommandRequestBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public AddPostCommandRequestBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public AddPostCommandRequestBuilder WithImages(IFormFileCollectionTransformer transformer)
	{
		_images = transformer.Transform(_images);

		return this;
	}

	public AddPostCommandRequest Build()
	{
		return new(_userId, _title, _content, _images);
	}
}
