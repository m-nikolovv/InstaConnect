namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetPostByIdQueryRequestBuilder
{
	private string _id;
	private string _currentUserId;

	public GetPostByIdQueryRequestBuilder(Post post)
	{
		_id = post.Id.Id;
		_currentUserId = post.UserId.Id;
	}

	public GetPostByIdQueryRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostByIdQueryRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostByIdQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetPostByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostByIdQueryRequest Build()
	{
		return new(_id, _currentUserId);
	}
}
