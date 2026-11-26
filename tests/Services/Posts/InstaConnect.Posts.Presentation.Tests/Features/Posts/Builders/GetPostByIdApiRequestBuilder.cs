namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetPostByIdApiRequestBuilder
{
	private string _id;
	private string _currentUserId;

	public GetPostByIdApiRequestBuilder(Post post)
	{
		_id = post.Id.Id;
		_currentUserId = post.UserId.Id;
	}

	public GetPostByIdApiRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetPostByIdApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetPostByIdApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetPostByIdApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetPostByIdApiRequest Build()
	{
		return new(_id, _currentUserId);
	}
}
