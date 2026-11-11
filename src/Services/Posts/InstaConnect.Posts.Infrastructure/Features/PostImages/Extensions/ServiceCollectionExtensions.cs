using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Models.Options;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostImageServices()
		{
			const string CollectionName = "post_images";

			serviceCollection.AddValidatedOptions<PostImageCacheOptions>(PostImageCacheOptions.SectionName);

			serviceCollection.AddCollection<PostImage>(CollectionName);

			serviceCollection.AddScoped<IPostImageCommandRepository, PostImageCommandRepository>()
							 .Decorate<IPostImageCommandRepository, CachedPostImageCommandRepository>();

			BsonClassMap.TryRegisterClassMap<PostImage>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.Url);
				cm.MapDateTimeMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.Post);

				cm.MapCreator(c => new PostImage(
					c.Id,
					c.Url,
					c.CreatedAtUtc));

				cm.IgnoreExtraElements();
			});

			return serviceCollection;
		}
	}
}
