namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class GetPostByIdQueryBuilder
{
	private string _id;
	private string _currentUserId;

	public GetPostByIdQueryBuilder(Post post)
	{
		_id = post.Id.Id;
		_currentUserId = post.UserId.Id;
	}

	public GetPostByIdQueryBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostByIdQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostByIdQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetPostByIdQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostByIdQuery Build()
	{
		return new(
			new(_id),
			new(
				new(_currentUserId)));
	}
}
