namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeIdBuilder
{
	private string _id;
	private string _userId;

	public PostLikeIdBuilder(PostLikeId id)
	{
		_id = id.Id.Id;
		_userId = id.UserId.Id;
	}

	public PostLikeIdBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public PostLikeIdBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostLikeIdBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public PostLikeIdBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public PostLikeId Build()
	{
		return new(
			new(_id),
			new(_userId));
	}
}
