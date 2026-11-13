using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Models.Options;

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

			serviceCollection.AddValidatedOptions<PostLikeCacheOptions>(PostLikeCacheOptions.SectionName);

			serviceCollection.AddCollection<PostLike, PostLikeId>(CollectionName);

			serviceCollection.AddScoped<IPostLikeCommandRepository, PostLikeCommandRepository>()
							 .Decorate<IPostLikeCommandRepository, CachedPostLikeCommandRepository>();

			serviceCollection.AddScoped<IPostLikeQueryRepository, PostLikeQueryRepository>()
							 .Decorate<IPostLikeQueryRepository, CachedPostLikeQueryRepository>();

			BsonClassMap.TryRegisterClassMap<PostLike>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapDateTimeMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);
				cm.MapMemberWithoutSerialization(c => c.Post);

				cm.MapCreator(c => new PostLike(
					c.Id,
					c.CreatedAtUtc));

				cm.IgnoreExtraElements();
			});

			return serviceCollection;
		}
	}
}
