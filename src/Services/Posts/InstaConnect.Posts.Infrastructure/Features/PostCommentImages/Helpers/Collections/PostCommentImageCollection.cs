using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Collections;

internal class PostCommentImageCollection : MongoDbCollection<PostCommentImage, PostCommentImageId>, IPostCommentImageCollection
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
		if (entities.IsEmpty())
		{
			return;
		}

		await DeleteRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken)
	{
		await DeleteRangeAsync(filter, cancellationToken);
	}
}
