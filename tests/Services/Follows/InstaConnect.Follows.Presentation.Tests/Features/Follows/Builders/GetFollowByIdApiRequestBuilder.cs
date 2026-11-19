namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Builders;

public class GetFollowByIdApiRequestBuilder
{
	private string _followerId;
	private string _followingId;
	private string _currentUserId;

	public GetFollowByIdApiRequestBuilder(Follow follow, UserId currentUserId)
	{
		_followerId = follow.Id.FollowerId.Id;
		_followingId = follow.Id.FollowingId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetFollowByIdApiRequestBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public GetFollowByIdApiRequestBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public GetFollowByIdApiRequestBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public GetFollowByIdApiRequestBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public GetFollowByIdApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetFollowByIdApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetFollowByIdApiRequest Build()
	{
		return new(_followerId, _followingId, _currentUserId);
	}
}
