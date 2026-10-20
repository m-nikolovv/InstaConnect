namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;

public class PostCommentsFilterQueryBuilder
{
	private string _id;
	private string _userName;

	public PostCommentsFilterQueryBuilder(PostComment postComment)
	{
		_id = postComment.Id.Id.Id;
		_userName = DataFaker.GetPrefixString(postComment.User!.Name.Value);
	}

	public PostCommentsFilterQueryBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public PostCommentsFilterQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostCommentsFilterQueryBuilder WithUserName(IStringTransformer transformer)
	{
		_userName = transformer.Transform(_userName);

		return this;
	}

	public PostCommentsFilterQuery Build()
	{
		return new(new(_id), new(_userName));
	}
}
