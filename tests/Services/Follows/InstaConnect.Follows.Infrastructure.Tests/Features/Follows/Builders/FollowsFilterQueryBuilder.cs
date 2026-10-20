namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;

public class FollowsFilterQueryBuilder
{
	private string _followerId;
	private string _followingName;

	public FollowsFilterQueryBuilder(Follow follow)
	{
		_followerId = follow.Id.FollowerId.Id;
		_followingName = DataFaker.GetPrefixString(follow.Following!.Name.Value);
	}

	public FollowsFilterQueryBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public FollowsFilterQueryBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public FollowsFilterQueryBuilder WithFollowingName(IStringTransformer transformer)
	{
		_followingName = transformer.Transform(_followingName);

		return this;
	}

	public FollowsFilterQuery Build()
	{
		return new(new(_followerId), new(_followingName));
	}
}
