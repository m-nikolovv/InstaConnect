using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Collections;

internal class PostCommentImageFluentFactory : IPostCommentImageFluentFactory
{
	public IPostCommentImageFluent Create(IAggregateFluent<PostCommentImage> fluent)
	{
		return new PostCommentImageFluent(fluent);
	}
}
