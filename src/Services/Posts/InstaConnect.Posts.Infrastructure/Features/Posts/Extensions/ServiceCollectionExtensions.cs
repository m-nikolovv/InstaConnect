namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostServices()
		{
			const string CollectionName = "posts";

			serviceCollection.AddImplementationsOf<IPostsSortTermer>(PostsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IPostsForUserSortTermer>(PostsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IPostIncluder>(PostsInfrastructureReference.Assembly);

			serviceCollection.AddCollection(
				CollectionName,
				new CreateIndexModel<Post>(Builders<Post>.IndexKeys.Ascending(c => c.Id.Id)),
				new CreateIndexModel<Post>(Builders<Post>.IndexKeys.Ascending(c => c.UserId.Id).Ascending(c => c.CreatedAtUtc)),
				new CreateIndexModel<Post>(Builders<Post>.IndexKeys.Ascending(c => c.UserId)),
				new CreateIndexModel<Post>(Builders<Post>.IndexKeys.Ascending(c => c.CreatedAtUtc)));

			BsonClassMap.TryRegisterClassMap<Post>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.UserId);
				cm.MapMember(c => c.Title);
				cm.MapMember(c => c.Content);
				cm.MapMember(c => c.Summary);
				cm.MapMember(c => c.CreatedAtUtc);
				cm.MapMember(c => c.UpdatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);
				cm.MapMemberWithoutSerialization(c => c.PostLikes);
				cm.MapMemberWithoutSerialization(c => c.PostComments);
				cm.MapMemberWithoutSerialization(c => c.PostImages);

				cm.MapCreator(c => new Post(
					c.Id,
					c.Title,
					c.Content,
					c.Summary,
					c.UserId,
					c.CreatedAtUtc,
					c.UpdatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
