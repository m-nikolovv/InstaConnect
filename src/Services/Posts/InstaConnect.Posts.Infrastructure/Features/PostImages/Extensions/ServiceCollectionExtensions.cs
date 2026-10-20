namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostImageServices()
		{
			const string CollectionName = "post_images";

			serviceCollection.AddCollection<PostImage>(CollectionName);

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
