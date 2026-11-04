namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostImageServices()
		{
			const string CollectionName = "post_images";

			serviceCollection.AddCollection(
				CollectionName,
				new CreateIndexModel<PostImage>(Builders<PostImage>.IndexKeys.Ascending(c => c.Id.Id.Id)),
				new CreateIndexModel<PostImage>(Builders<PostImage>.IndexKeys.Ascending(c => c.Id.Id)));

			BsonClassMap.TryRegisterClassMap<PostImage>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.Url);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.Post);

				cm.MapCreator(c => new PostImage(
					c.Id,
					c.Url,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
