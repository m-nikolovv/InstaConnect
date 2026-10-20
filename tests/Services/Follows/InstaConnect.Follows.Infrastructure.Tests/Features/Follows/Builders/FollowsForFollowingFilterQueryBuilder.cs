namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;

public class FollowsForFollowingFilterQueryBuilder
{
	private string _followingId;
	private string _followerName;

	public FollowsForFollowingFilterQueryBuilder(Follow follow)
	{
		_followingId = follow.Id.FollowingId.Id;
		_followerName = DataFaker.GetPrefixString(follow.Follower!.Name.Value);
	}

	public FollowsForFollowingFilterQueryBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public FollowsForFollowingFilterQueryBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public FollowsForFollowingFilterQueryBuilder WithFollowerName(IStringTransformer transformer)
	{
		_followerName = transformer.Transform(_followerName);

		return this;
	}

	public FollowsForFollowingFilterQuery Build()
	{
		return new(new(_followingId), new(_followerName));
	}
}
