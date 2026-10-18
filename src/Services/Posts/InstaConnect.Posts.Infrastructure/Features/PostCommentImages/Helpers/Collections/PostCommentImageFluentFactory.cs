using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Collections;

internal class PostCommentImageFluentFactory : IPostCommentImageFluentFactory
{
	public IPostCommentImageFluent Create(IAggregateFluent<PostCommentImage> fluent)
	{
		return new PostCommentImageFluent(fluent);
	}
}
