using MongoDB.Bson.Serialization;

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
				cm.MapMember(c => c.Image);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.Post);

				cm.MapCreator(c => new PostImage(
					c.Id,
					c.Image,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
