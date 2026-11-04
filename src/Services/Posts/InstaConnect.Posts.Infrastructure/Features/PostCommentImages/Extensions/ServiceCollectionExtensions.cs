namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostCommentImageServices()
		{
			const string CollectionName = "post_comment_images";

			serviceCollection.AddCollection<PostCommentImage>(CollectionName);

			BsonClassMap.TryRegisterClassMap<PostCommentImage>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.Url);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.PostComment);

				cm.MapCreator(c => new PostCommentImage(
					c.Id,
					c.Url,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
