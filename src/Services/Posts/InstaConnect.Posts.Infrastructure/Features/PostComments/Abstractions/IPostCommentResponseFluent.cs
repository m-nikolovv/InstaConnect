namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentResponseFluent : IMongoDbResponseFluent<PostCommentResponse>
{
	public IPostCommentResponseFluent Sort(PostCommentsSortingQuery query);
	public IPostCommentResponseFluent Sort(PostCommentsForUserSortingQuery query);
	public IPostCommentResponseFluent Paginate(PostCommentsPaginationQuery query);
}
