namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentResponseFluent :
	MongoDbResponseFluent<PostCommentResponse>, IPostCommentResponseFluent
{
	public PostCommentResponseFluent(IAggregateFluent<PostCommentResponse> fluent) : base(fluent)
	{
	}
}
