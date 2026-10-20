using InstaConnect.Common.Tests.Features.DataAttributes.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Follows.Tests.Features.Follows.Builders;

public class FollowIdBuilder
{
	private string _followerId;
	private string _followingId;

	public FollowIdBuilder(FollowId id)
	{
		_followerId = id.FollowerId.Id;
		_followingId = id.FollowingId.Id;
	}

	public FollowIdBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public FollowIdBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public FollowIdBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public FollowIdBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public FollowId Build()
	{
		return new(
			new(_followerId),
			new(_followingId));
	}
}
