namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentResponseFluentFactory : IPostCommentResponseFluentFactory
{
	public IPostCommentResponseFluent Create(IAggregateFluent<PostCommentResponse> fluent)
	{
		return new PostCommentResponseFluent(fluent);
	}
}
