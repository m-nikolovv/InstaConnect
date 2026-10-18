namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class AnalyzePostByIdApiRequestBuilder
{
	private string _id;
	private string _currentUserId;

	public AnalyzePostByIdApiRequestBuilder(Post post)
	{
		_id = post.Id.Id;
		_currentUserId = post.UserId.Id;
	}

	public AnalyzePostByIdApiRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AnalyzePostByIdApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AnalyzePostByIdApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public AnalyzePostByIdApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public AnalyzePostByIdApiRequest Build()
	{
		return new(_id, _currentUserId);
	}
}
