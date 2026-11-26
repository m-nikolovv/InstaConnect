namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdApiRequestBuilder
{
	private string _id;
	private string _userId;
	private string _currentUserId;

	public GetPostLikeByIdApiRequestBuilder(PostLike postLike, UserId currentUserId)
	{
		_id = postLike.Id.Id.Id;
		_userId = postLike.Id.UserId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetPostLikeByIdApiRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostLikeByIdApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostLikeByIdApiRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetPostLikeByIdApiRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetPostLikeByIdApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetPostLikeByIdApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostLikeByIdApiRequest Build()
	{
		return new(_id, _userId, _currentUserId);
	}
}
