namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

internal class PostCommentFactory : IPostCommentFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IDateTimeProvider _dateTimeProvider;

	public PostCommentFactory(
		IGuidProvider guidProvider,
		IDateTimeProvider dateTimeProvider)
	{
		_guidProvider = guidProvider;
		_dateTimeProvider = dateTimeProvider;
	}

	public PostComment Create(PostId id, UserId userId, string content)
	{
		var commentId = _guidProvider.NewStringGuid();
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var postComment = new PostComment(
			new(id, commentId),
			content,
			new(string.Empty),
			userId,
			utcNow,
			utcNow);

		return postComment;
	}
}
