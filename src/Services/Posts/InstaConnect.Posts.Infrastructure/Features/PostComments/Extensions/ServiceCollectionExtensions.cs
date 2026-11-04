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

			serviceCollection.AddCollection(
				CollectionName,
				new CreateIndexModel<PostComment>(Builders<PostComment>.IndexKeys.Ascending(c => c.Id.Id.Id).Ascending(c => c.CreatedAtUtc)),
				new CreateIndexModel<PostComment>(Builders<PostComment>.IndexKeys.Ascending(c => c.UserId.Id).Ascending(c => c.CreatedAtUtc)),
				new CreateIndexModel<PostComment>(Builders<PostComment>.IndexKeys.Ascending(c => c.Id.Id)),
				new CreateIndexModel<PostComment>(Builders<PostComment>.IndexKeys.Ascending(c => c.UserId)));

			BsonClassMap.TryRegisterClassMap<PostComment>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.UserId);
				cm.MapMember(c => c.Content);
				cm.MapMember(c => c.Summary);
				cm.MapMember(c => c.CreatedAtUtc);
				cm.MapMember(c => c.UpdatedAtUtc);

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

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
