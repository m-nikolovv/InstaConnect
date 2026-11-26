namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;

public class GetFollowByIdQueryBuilder
{
	private string _followerId;
	private string _followingId;
	private string _currentUserId;

	public GetFollowByIdQueryBuilder(Follow follow, UserId currentUserId)
	{
		_followerId = follow.Id.FollowerId.Id;
		_followingId = follow.Id.FollowingId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetFollowByIdQueryBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public GetFollowByIdQueryBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public GetFollowByIdQueryBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public GetFollowByIdQueryBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public GetFollowByIdQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetFollowByIdQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetFollowByIdQuery Build()
	{
		return new(
			new(
				new(_followerId),
				new(_followingId)),
			new(
				new(_currentUserId)));
	}
}
