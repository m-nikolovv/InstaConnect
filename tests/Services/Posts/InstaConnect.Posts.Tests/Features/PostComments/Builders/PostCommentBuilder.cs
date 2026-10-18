using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentBuilder
{
	private string _id;
	private readonly Post _post;
	private readonly string _content;
	private readonly string _summary;
	private string _commentId;
	private readonly string _userId;
	private readonly User _user;
	private readonly DateTimeOffset _createdAtUtc;
	private readonly DateTimeOffset _updatedAtUtc;

	public PostCommentBuilder(Post post, User user)
	{
		_id = post.Id.Id;
		_post = post;
		_commentId = PostCommentDataFaker.GetId();
		_userId = user.Id.Id;
		_user = user;
		_content = PostCommentDataFaker.GetContent();
		_summary = PostCommentDataFaker.GetSummary();
		_createdAtUtc = PostCommentDataFaker.GetCreatedAtUtc();
		_updatedAtUtc = _createdAtUtc;
	}

	public PostCommentBuilder WithId(PostCommentId id)
	{
		_id = id.Id.Id;
		_commentId = id.CommentId;

		return this;
	}

	public PostComment Build()
	{
		var postComment = new PostComment(
				new(
					new(_id),
					_commentId),
				_content,
				new(_summary),
				new(_userId),
				_createdAtUtc,
				_updatedAtUtc);

		_user.AddPostComment(postComment);
		_post.AddPostComment(postComment);
		postComment.AddUser(_user);
		postComment.AddPost(_post);

		return postComment;
	}
}
