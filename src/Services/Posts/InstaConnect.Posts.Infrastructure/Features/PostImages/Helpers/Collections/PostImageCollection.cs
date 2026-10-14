using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Collections;

internal class PostImageCollection : MongoDbCollection<PostImage>, IPostImageCollection
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
}
