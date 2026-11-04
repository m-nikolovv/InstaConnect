namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeResponseFluentFactory : IPostCommentLikeResponseFluentFactory
{
	public IPostCommentLikeResponseFluent Create(IAggregateFluent<PostCommentLikeResponse> fluent)
	{
		return new PostCommentLikeResponseFluent(fluent);
	}
}
