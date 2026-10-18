namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class AnalyzePostByIdQueryRequestBuilder
{
	private string _id;
	private string _currentUserId;

	public AnalyzePostByIdQueryRequestBuilder(Post post)
	{
		_id = post.Id.Id;
		_currentUserId = post.UserId.Id;
	}

	public AnalyzePostByIdQueryRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AnalyzePostByIdQueryRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AnalyzePostByIdQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public AnalyzePostByIdQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public AnalyzePostByIdQueryRequest Build()
	{
		return new(_id, _currentUserId);
	}
}
