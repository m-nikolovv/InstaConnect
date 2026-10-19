using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeBuilder
{
	private readonly string _id;
	private readonly Post _post;
	private readonly string _userId;
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

	public PostLike Build()
	{
		var postLike = new PostLike(
				new(
					new(_id),
					new(_userId)),
				_createdAtUtc);

		_user.AddPostLike(postLike);
		_post.AddPostLike(postLike);
		postLike.AddUser(_user);
		postLike.AddPost(_post);

		return postLike;
	}
}
