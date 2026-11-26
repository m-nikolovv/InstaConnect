namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdQueryRequestBuilder
{
	private string _id;
	private string _userId;
	private string _currentUserId;

	public GetPostLikeByIdQueryRequestBuilder(PostLike postLike, UserId currentUserId)
	{
		_id = postLike.Id.Id.Id;
		_userId = postLike.Id.UserId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetPostLikeByIdQueryRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostLikeByIdQueryRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostLikeByIdQueryRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetPostLikeByIdQueryRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetPostLikeByIdQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetPostLikeByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostLikeByIdQueryRequest Build()
	{
		return new(_id, _userId, _currentUserId);
	}
}
