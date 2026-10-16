using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostImages.Builders;

public class PostImageBuilder
{
	private readonly string _id;
	private readonly Post _post;
	private readonly string _imageId;
	private readonly string _url;
	private readonly DateTimeOffset _createdAtUtc;

	public PostImageBuilder(Post post)
	{
		_id = post.Id.Id;
		_post = post;
		_imageId = PostImageDataFaker.GetImageId();
		_url = PostImageDataFaker.GetUrl();
		_createdAtUtc = PostImageDataFaker.GetCreatedAtUtc();
	}

	public PostImage Build()
	{
		var postImage = new PostImage(
				new(
					new(_id),
					_imageId),
				new(_url),
				_createdAtUtc);

		_post.AddPostImage(postImage);
		postImage.AddPost(_post);

		return postImage;
	}
}
