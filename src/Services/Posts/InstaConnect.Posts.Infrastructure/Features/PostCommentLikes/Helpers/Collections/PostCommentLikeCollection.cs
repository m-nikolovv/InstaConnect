using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeCollection : MongoDbCollection<PostCommentLike>, IPostCommentLikeCollection
{
	private readonly IPostCommentLikeFluentFactory _fluentFactory;

	public PostCommentLikeCollection(
		ISessionHandler sessionHandler,
		IPostCommentLikeFluentFactory fluentFactory,
		IMongoCollection<PostCommentLike> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IPostCommentLikeFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		PostCommentLike entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
