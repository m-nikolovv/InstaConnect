namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeBuilder
{
	private string _id;
	private readonly Post _post;
	private string _userId;
	private readonly User _user;
	private readonly DateTimeOffset _createdAtUtc;

	public PostLikeBuilder(Post post, User user)
	{
		_id = post.Id.Id;
		_post = post;
		_userId = user.Id.Id;
		_user = user;
		_createdAtUtc = PostLikeDataFaker.GetCreatedAtUtc();
	}

	public PostLikeBuilder(PostLike postLike)
	{
		_id = postLike.Id.Id.Id;
		_post = postLike.Post!;
		_userId = postLike.Id.UserId.Id;
		_user = postLike.User!;
		_createdAtUtc = postLike.CreatedAtUtc;
	}

	public PostLikeBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostLikeBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public PostLike BuildAttached()
	{
		var postLike = Build();

		_user.AddPostLike(postLike);
		_post.AddPostLike(postLike);

		return postLike;
	}

	public PostLike Build()
	{
		var postLike = new PostLike(
				new(
					new(_id),
					new(_userId)),
				_createdAtUtc);

		postLike.AddUser(_user);
		postLike.AddPost(_post);

		return postLike;
	}
}
