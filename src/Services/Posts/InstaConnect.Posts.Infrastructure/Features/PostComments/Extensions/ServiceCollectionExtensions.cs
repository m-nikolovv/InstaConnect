using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Models.Options;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostCommentServices()
		{
			const string CollectionName = "post_comments";

			serviceCollection.AddImplementationsOf<IPostCommentsSortTermer>(PostsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IPostCommentsForUserSortTermer>(PostsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IPostCommentIncluder>(PostsInfrastructureReference.Assembly);

			serviceCollection.AddValidatedOptions<PostCommentCacheOptions>(PostCommentCacheOptions.SectionName);

			serviceCollection.AddCollection<PostComment, PostCommentId>(CollectionName);

			serviceCollection.AddScoped<IPostCommentCommandRepository, PostCommentCommandRepository>()
							 .Decorate<IPostCommentCommandRepository, CachedPostCommentCommandRepository>();

			serviceCollection.AddScoped<IPostCommentQueryRepository, PostCommentQueryRepository>()
							 .Decorate<IPostCommentQueryRepository, CachedPostCommentQueryRepository>();

			BsonClassMap.TryRegisterClassMap<PostComment>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.UserId);
				cm.MapMember(c => c.Content);
				cm.MapMember(c => c.Summary);
				cm.MapDateTimeMember(c => c.CreatedAtUtc);
				cm.MapDateTimeMember(c => c.UpdatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);
				cm.MapMemberWithoutSerialization(c => c.Post);
				cm.MapMemberWithoutSerialization(c => c.PostCommentLikes);
				cm.MapMemberWithoutSerialization(c => c.PostCommentImages);

				cm.MapCreator(c => new PostComment(
					c.Id,
					c.Content,
					c.Summary,
					c.UserId,
					c.CreatedAtUtc,
					c.UpdatedAtUtc));

				cm.IgnoreExtraElements();
			});

			return serviceCollection;
		}
	}
}
