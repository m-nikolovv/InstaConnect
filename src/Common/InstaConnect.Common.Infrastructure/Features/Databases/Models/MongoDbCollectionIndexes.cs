namespace InstaConnect.Common.Infrastructure.Features.Databases.Models;

internal record MongoDbCollectionIndexes(
	Func<IMongoDatabase, CancellationToken, Task> CreateAsync);
