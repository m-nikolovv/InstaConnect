using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Collections;

internal class PostImageCollection : MongoDbCollection<PostImage, PostImageId>, IPostImageCollection
{
	private readonly IPostImageFluentFactory _fluentFactory;

	public PostImageCollection(
		ISessionHandler sessionHandler,
		IPostImageFluentFactory fluentFactory,
		IMongoCollection<PostImage> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IPostImageFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		PostImage entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<PostImage> entities,
		CancellationToken cancellationToken)
	{
		await DeleteRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken)
	{
		await DeleteRangeAsync(filter, cancellationToken);
	}
}
