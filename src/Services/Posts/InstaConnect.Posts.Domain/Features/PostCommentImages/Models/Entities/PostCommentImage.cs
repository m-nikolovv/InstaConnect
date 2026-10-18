namespace InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Entities;

public class PostCommentImage : IEntityWithId<PostCommentImageId>
{
	private PostCommentImage()
	{
		Id = new(new(new(string.Empty), string.Empty), string.Empty);
		Url = new(string.Empty);
	}

	public PostCommentImage(
		PostCommentImageId id,
		Url url,
		DateTimeOffset createdAtUtc)
	{
		Id = id;
		Url = url;
		CreatedAtUtc = createdAtUtc;
	}

	public PostCommentImageId Id { get; }

	public Url Url { get; }

	public PostComment? PostComment { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public PostCommentImage AddPostComment(PostComment? postComment)
	{
		PostComment = postComment;

		return this;
	}
}
