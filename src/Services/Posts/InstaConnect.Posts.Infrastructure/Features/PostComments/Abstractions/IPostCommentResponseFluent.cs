namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentResponseFluent : IMongoDbResponseFluent<PostCommentResponse>
{
	public IPostCommentResponseFluent ApplySorting(PostCommentsSortingQuery query);
	public IPostCommentResponseFluent ApplySorting(PostCommentsForUserSortingQuery query);
	public IPostCommentResponseFluent ApplyPagination(PostCommentsPaginationQuery query);
}
