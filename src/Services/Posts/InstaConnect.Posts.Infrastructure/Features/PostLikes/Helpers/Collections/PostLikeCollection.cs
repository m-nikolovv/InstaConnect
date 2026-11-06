using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeCollection : MongoDbCollection<PostLike, PostLikeId>, IPostLikeCollection
{
	private readonly IPostLikeFluentFactory _fluentFactory;

	public PostLikeCollection(
		ISessionHandler sessionHandler,
		IPostLikeFluentFactory fluentFactory,
		IMongoCollection<PostLike> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IPostLikeFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		PostLike entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken)
	{
		await DeleteRangeAsync(filter, cancellationToken);
	}
}
