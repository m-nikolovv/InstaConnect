namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Builders;

public class PostLikesForUserFilterQueryBuilder
{
	private string _userId;

	public PostLikesForUserFilterQueryBuilder(PostLike postLike)
	{
		_userId = postLike.Id.UserId.Id;
	}

	public PostLikesForUserFilterQueryBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public PostLikesForUserFilterQueryBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public PostLikesForUserFilterQuery Build()
	{
		return new(new(_userId));
	}
}
