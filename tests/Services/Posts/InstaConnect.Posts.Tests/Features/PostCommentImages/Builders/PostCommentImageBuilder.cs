namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;

public class PostCommentImageBuilder
{
	private string _id;
	private readonly string _url;
	private string _imageId;
	private string _commentId;
	private readonly PostComment _postComment;
	private readonly DateTimeOffset _createdAtUtc;

	public PostCommentImageBuilder(PostComment postComment)
	{
		_id = postComment.Id.Id.Id;
		_url = PostCommentImageDataFaker.GetUrl();
		_imageId = PostCommentImageDataFaker.GetImageId();
		_commentId = postComment.Id.CommentId;
		_postComment = postComment;
		_createdAtUtc = PostCommentImageDataFaker.GetCreatedAtUtc();
	}

	public PostCommentImageBuilder(PostCommentImage postCommentImage)
	{
		_id = postCommentImage.Id.Id.Id.Id;
		_url = postCommentImage.Url.Value;
		_imageId = postCommentImage.Id.ImageId;
		_commentId = postCommentImage.Id.Id.CommentId;
		_postComment = postCommentImage.PostComment!;
		_createdAtUtc = postCommentImage.CreatedAtUtc;
	}

	public PostCommentImageBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostCommentImageBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public PostCommentImageBuilder WithImageId(PostCommentImageId imageId, IStringTransformer? transformer = null)
	{
		_imageId = transformer.TryTransform(imageId.ImageId);

		return this;
	}

	public PostCommentImageBuilder WithImageId(IStringTransformer transformer)
	{
		_imageId = transformer.Transform(_imageId);

		return this;
	}

	public PostCommentImage BuildAttached()
	{
		var postCommentImage = Build();

		_postComment.AddPostCommentImage(postCommentImage);

		return postCommentImage;
	}

	public PostCommentImage Build()
	{
		var postCommentImage = new PostCommentImage(
				new(
					new(
						new(_id),
						_commentId),
					_imageId),
				new(_url),
				_createdAtUtc);

		postCommentImage.AddPostComment(_postComment);

		return postCommentImage;
	}
}
