namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;

public class PostCommentsForUserFilterQueryBuilder
{
	private string _userId;

	public PostCommentsForUserFilterQueryBuilder(PostComment postComment)
	{
		_userId = postComment.UserId.Id;
	}

	public PostCommentsForUserFilterQueryBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public PostCommentsForUserFilterQueryBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public PostCommentsForUserFilterQuery Build()
	{
		return new(new(_userId));
	}
}
