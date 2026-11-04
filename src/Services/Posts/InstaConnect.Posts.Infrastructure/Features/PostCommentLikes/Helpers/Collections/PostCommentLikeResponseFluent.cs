namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeResponseFluent :
	MongoDbResponseFluent<PostCommentLikeResponse>, IPostCommentLikeResponseFluent
{
	public PostCommentLikeResponseFluent(IAggregateFluent<PostCommentLikeResponse> fluent) : base(fluent)
	{
	}
}
