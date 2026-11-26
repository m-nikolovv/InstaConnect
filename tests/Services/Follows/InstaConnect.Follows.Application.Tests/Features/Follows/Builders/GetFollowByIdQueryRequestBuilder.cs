namespace InstaConnect.Follows.Application.Tests.Features.Follows.Builders;

public class GetFollowByIdQueryRequestBuilder
{
	private string _followerId;
	private string _followingId;
	private string _currentUserId;

	public GetFollowByIdQueryRequestBuilder(Follow follow, UserId currentUserId)
	{
		_followerId = follow.Id.FollowerId.Id;
		_followingId = follow.Id.FollowingId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetFollowByIdQueryRequestBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public GetFollowByIdQueryRequestBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public GetFollowByIdQueryRequestBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public GetFollowByIdQueryRequestBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public GetFollowByIdQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetFollowByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetFollowByIdQueryRequest Build()
	{
		return new(_followerId, _followingId, _currentUserId);
	}
}
