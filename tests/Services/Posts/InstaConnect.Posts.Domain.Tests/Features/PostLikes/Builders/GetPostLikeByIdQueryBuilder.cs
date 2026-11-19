namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdQueryBuilder
{
	private string _id;
	private string _userId;
	private string _currentUserId;

	public GetPostLikeByIdQueryBuilder(PostLike postLike, UserId currentUserId)
	{
		_id = postLike.Id.Id.Id;
		_userId = postLike.Id.UserId.Id;
		_currentUserId = currentUserId.Id;
	}

	public GetPostLikeByIdQueryBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostLikeByIdQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostLikeByIdQueryBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetPostLikeByIdQueryBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetPostLikeByIdQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetPostLikeByIdQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostLikeByIdQuery Build()
	{
		return new(
			new(
				new(_id),
				new(_userId)),
			new(
				new(_currentUserId)));
	}
}
