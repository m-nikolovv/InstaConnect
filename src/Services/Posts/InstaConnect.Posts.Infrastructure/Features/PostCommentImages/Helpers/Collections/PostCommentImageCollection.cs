using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Collections;

internal class PostCommentImageCollection : MongoDbCollection<PostCommentImage>, IPostCommentImageCollection
{
	private readonly IPostCommentImageFluentFactory _fluentFactory;

	public PostCommentImageCollection(
		ISessionHandler sessionHandler,
		IPostCommentImageFluentFactory fluentFactory,
		IMongoCollection<PostCommentImage> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IPostCommentImageFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		PostCommentImage entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<PostCommentImage> entities,
		CancellationToken cancellationToken)
	{
		await DeleteRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}
}
