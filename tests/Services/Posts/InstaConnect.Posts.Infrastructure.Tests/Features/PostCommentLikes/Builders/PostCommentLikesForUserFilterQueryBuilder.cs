namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikesForUserFilterQueryBuilder
{
	private string _userId;

	public PostCommentLikesForUserFilterQueryBuilder(PostCommentLike postCommentLike)
	{
		_userId = postCommentLike.Id.UserId.Id;
	}

	public PostCommentLikesForUserFilterQueryBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public PostCommentLikesForUserFilterQueryBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public PostCommentLikesForUserFilterQuery Build()
	{
		return new(new(_userId));
	}
}
