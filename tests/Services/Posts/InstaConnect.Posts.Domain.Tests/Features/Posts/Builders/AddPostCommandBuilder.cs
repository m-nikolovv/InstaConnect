using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class AddPostCommandBuilder
{
	private string _userId;
	private string _title;
	private string _content;
	private ICollection<IFormFile> _images;

	public AddPostCommandBuilder(User user, int numberOfImages)
	{
		_userId = user.Id.Id;
		_title = PostDataFaker.GetTitle();
		_content = PostDataFaker.GetContent();
		_images = PostImageDataFaker.GetImages(numberOfImages);
	}

	public AddPostCommandBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public AddPostCommandBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public AddPostCommandBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public AddPostCommandBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public AddPostCommandBuilder WithImages(IFormFileCollectionTransformer transformer)
	{
		_images = transformer.Transform(_images);

		return this;
	}

	public AddPostCommand Build()
	{
		return new(
			new(_userId),
			_title,
			_content,
			_images);
	}
}
