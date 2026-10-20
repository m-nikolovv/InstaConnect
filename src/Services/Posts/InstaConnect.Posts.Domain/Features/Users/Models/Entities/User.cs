namespace InstaConnect.Posts.Domain.Features.Users.Models.Entities;

public class User : IEntityWithId<UserId>
{
	private User()
	{
		Id = new(string.Empty);
		FirstName = string.Empty;
		LastName = string.Empty;
		Email = new(string.Empty);
		Name = new(string.Empty);
		Posts = [];
		PostLikes = [];
		PostComments = [];
		PostCommentLikes = [];
	}

	public User(
		UserId id,
		string firstName,
		string lastName,
		Email email,
		Name name,
		Url? profileImageUrl,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Name = name;
		ProfileImageUrl = profileImageUrl;
		Posts = [];
		PostLikes = [];
		PostComments = [];
		PostCommentLikes = [];
		CreatedAtUtc = createdAtUtc;
		UpdatedAtUtc = updatedAtUtc;
	}

	public UserId Id { get; }

	public string FirstName { get; private set; }

	public string LastName { get; private set; }

	public Email Email { get; private set; }

	public Name Name { get; private set; }

	public Url? ProfileImageUrl { get; private set; }

	public ICollection<Post> Posts { get; private set; }

	public ICollection<PostLike> PostLikes { get; private set; }

	public ICollection<PostComment> PostComments { get; private set; }

	public ICollection<PostCommentLike> PostCommentLikes { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public DateTimeOffset UpdatedAtUtc { get; private set; }

	public void Update(
		Email email,
		string firstName,
		string lastName,
		Name name,
		Url? profileImageUrl,
		DateTimeOffset updatedAtUtc)
	{
		Email = email;
		FirstName = firstName;
		LastName = lastName;
		Name = name;
		ProfileImageUrl = profileImageUrl;
		UpdatedAtUtc = updatedAtUtc;
	}

	public User AddPost(Post post)
	{
		Posts.Add(post);

		return this;
	}

	public User AddPosts(ICollection<Post> posts)
	{
		Posts.AddRange(posts);

		return this;
	}

	public User AddPostLike(PostLike postLike)
	{
		PostLikes.Add(postLike);

		return this;
	}

	public User AddPostLikes(ICollection<PostLike> postLikes)
	{
		PostLikes.AddRange(postLikes);

		return this;
	}

	public User AddPostComment(PostComment postComment)
	{
		PostComments.Add(postComment);

		return this;
	}

	public User AddPostComments(ICollection<PostComment> postComments)
	{
		PostComments.AddRange(postComments);

		return this;
	}

	public User AddPostCommentLike(PostCommentLike postCommentLike)
	{
		PostCommentLikes.Add(postCommentLike);

		return this;
	}

	public User AddPostCommentLikes(ICollection<PostCommentLike> postCommentLikes)
	{
		PostCommentLikes.AddRange(postCommentLikes);

		return this;
	}
}


