namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class AnalyzePostByIdQueryBuilder
{
	private string _id;
	private string _currentUserId;

	public AnalyzePostByIdQueryBuilder(Post post)
	{
		_id = post.Id.Id;
		_currentUserId = post.UserId.Id;
	}

	public AnalyzePostByIdQueryBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public AnalyzePostByIdQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public AnalyzePostByIdQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public AnalyzePostByIdQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public AnalyzePostByIdQuery Build()
	{
		return new(
			new(_id),
			new(
				new(_currentUserId)));
	}
}
