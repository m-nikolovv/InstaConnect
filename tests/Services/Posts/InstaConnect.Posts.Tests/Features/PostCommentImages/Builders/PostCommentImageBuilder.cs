using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;

public class PostCommentImageBuilder
{
	private readonly string _id;
	private readonly string _url;
	private readonly string _imageId;
	private readonly string _commentId;
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

		_postComment.AddPostCommentImage(postCommentImage);
		postCommentImage.AddPostComment(_postComment);

		return postCommentImage;
	}
}
