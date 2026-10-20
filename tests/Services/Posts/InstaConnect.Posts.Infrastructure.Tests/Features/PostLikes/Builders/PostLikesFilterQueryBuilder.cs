namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Builders;

public class PostLikesFilterQueryBuilder
{
	private string _id;
	private string _userName;

	public PostLikesFilterQueryBuilder(PostLike postLike)
	{
		_id = postLike.Id.Id.Id;
		_userName = DataFaker.GetPrefixString(postLike.User!.Name.Value);
	}

	public PostLikesFilterQueryBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public PostLikesFilterQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public PostLikesFilterQueryBuilder WithUserName(IStringTransformer transformer)
	{
		_userName = transformer.Transform(_userName);

		return this;
	}

	public PostLikesFilterQuery Build()
	{
		return new(new(_id), new(_userName));
	}
}
