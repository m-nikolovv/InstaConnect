namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

public class PostComment : IEntityWithId<PostCommentId>
{
	private PostComment()
	{
		Id = new(new(string.Empty), string.Empty);
		Content = string.Empty;
		Summary = new(string.Empty);
		UserId = new(string.Empty);
		PostCommentLikes = [];
		PostCommentImages = [];
	}

	public PostComment(
		PostCommentId id,
		string content,
		Summary summary,
		UserId userId,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc)
	{
		Id = id;
		Content = content;
		Summary = summary;
		UserId = userId;
		PostCommentLikes = [];
		PostCommentImages = [];
		CreatedAtUtc = createdAtUtc;
		UpdatedAtUtc = updatedAtUtc;
	}

	public void UpdateSummary(Summary summary)
	{
		Summary = summary;
	}

	public PostCommentId Id { get; }

	public string Content { get; private set; }

	public Summary Summary { get; private set; }

	public UserId UserId { get; }

	public User? User { get; private set; }

	public Post? Post { get; private set; }

	public ICollection<PostCommentLike> PostCommentLikes { get; private set; }

	public ICollection<PostCommentImage> PostCommentImages { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public DateTimeOffset UpdatedAtUtc { get; private set; }

	public void Update(string content, DateTimeOffset updatedAtUtc)
	{
		Content = content;
		UpdatedAtUtc = updatedAtUtc;
	}

	public bool IsNotOwnedByUser(UserId userId)
	{
		return UserId.IsNot(userId);
	}

	public PostComment AddUser(User? user)
	{
		User = user;

		return this;
	}

	public PostComment AddPost(Post? post)
	{
		Post = post;

		return this;
	}

	public PostComment AddPostCommentLike(PostCommentLike postCommentLike)
	{
		PostCommentLikes.Add(postCommentLike);

		return this;
	}

	public PostComment AddPostCommentImage(PostCommentImage postCommentImage)
	{
		PostCommentImages.Add(postCommentImage);

		return this;
	}

	public PostComment AddPostCommentImages(ICollection<PostCommentImage> postCommentImages)
	{
		PostCommentImages.AddRange(postCommentImages);

		return this;
	}
}
