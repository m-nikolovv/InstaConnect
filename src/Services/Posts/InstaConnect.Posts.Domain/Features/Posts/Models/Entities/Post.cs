namespace InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

public class Post : IEntityWithId<PostId>
{
	private Post()
	{
		Id = new(string.Empty);
		Title = string.Empty;
		Content = string.Empty;
		UserId = new(string.Empty);
		PostLikes = [];
		PostComments = [];
		PostImages = [];
	}

	public Post(
		PostId id,
		string title,
		string content,
		UserId userId,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc)
	{
		Id = id;
		Title = title;
		Content = content;
		UserId = userId;
		PostLikes = [];
		PostComments = [];
		PostImages = [];
		CreatedAtUtc = createdAtUtc;
		UpdatedAtUtc = updatedAtUtc;
	}

	public PostId Id { get; }

	public string Title { get; private set; }

	public string Content { get; private set; }

	public UserId UserId { get; }

	public User? User { get; private set; }

	public ICollection<PostLike> PostLikes { get; private set; }

	public ICollection<PostComment> PostComments { get; private set; }

	public ICollection<PostImage> PostImages { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public DateTimeOffset UpdatedAtUtc { get; private set; }

	public bool IsNotOwnedByUser(UserId userId)
	{
		return UserId.IsNot(userId);
	}

	public void Update(string title, string content, DateTimeOffset updatedAtUtc)
	{
		Title = title;
		Content = content;
		UpdatedAtUtc = updatedAtUtc;
	}

	public Post AddUser(User? user)
	{
		User = user;

		return this;
	}

	public Post AddPostLike(PostLike postLike)
	{
		PostLikes.Add(postLike);

		return this;
	}

	public Post AddPostComment(PostComment postComment)
	{
		PostComments.Add(postComment);

		return this;
	}

	public Post AddPostImage(PostImage postImage)
	{
		PostImages.Add(postImage);

		return this;
	}

	public Post AddPostImage(ICollection<PostImage> postImages)
	{
		PostImages.AddRange(postImages);

		return this;
	}
}
