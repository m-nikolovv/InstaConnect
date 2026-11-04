namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostLikeServices()
		{
			const string CollectionName = "post_likes";

			serviceCollection.AddImplementationsOf<IPostLikesSortTermer>(PostsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IPostLikesForUserSortTermer>(PostsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IPostLikeIncluder>(PostsInfrastructureReference.Assembly);

			serviceCollection.AddCollection(
				CollectionName,
				new CreateIndexModel<PostLike>(Builders<PostLike>.IndexKeys.Ascending(c => c.Id.Id.Id).Ascending(c => c.CreatedAtUtc)),
				new CreateIndexModel<PostLike>(Builders<PostLike>.IndexKeys.Ascending(c => c.Id.UserId.Id).Ascending(c => c.CreatedAtUtc)),
				new CreateIndexModel<PostLike>(Builders<PostLike>.IndexKeys.Ascending(c => c.Id.Id)),
				new CreateIndexModel<PostLike>(Builders<PostLike>.IndexKeys.Ascending(c => c.Id.UserId)));

			BsonClassMap.TryRegisterClassMap<PostLike>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);
				cm.MapMemberWithoutSerialization(c => c.Post);

				cm.MapCreator(c => new PostLike(
					c.Id,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
