namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostCommentLikeServices()
		{
			const string CollectionName = "post_comment_likes";

			serviceCollection.AddImplementationsOf<IPostCommentLikesSortTermer>(PostsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IPostCommentLikesForUserSortTermer>(PostsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IPostCommentLikeIncluder>(PostsInfrastructureReference.Assembly);

			serviceCollection.AddCollection<PostCommentLike>(CollectionName);

			BsonClassMap.TryRegisterClassMap<PostCommentLike>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);
				cm.MapMemberWithoutSerialization(c => c.PostComment);

				cm.MapCreator(c => new PostCommentLike(
					c.Id,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}

