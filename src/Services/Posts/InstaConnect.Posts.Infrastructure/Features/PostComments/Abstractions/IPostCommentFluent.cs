namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentFluent : IMongoDbFluent<PostComment>
{
	public IPostCommentFluent Match(PostCommentsFilterQuery filter);
	public IPostCommentFluent Match(PostCommentsForUserFilterQuery filter);
	public IPostCommentFluent Match(PostCommentId filter);
	public IPostCommentFluent ApplySorting(PostCommentsSortingQuery query);
	public IPostCommentFluent ApplySorting(PostCommentsForUserSortingQuery query);
	public IPostCommentFluent ApplyPagination(PostCommentsPaginationQuery query);
	public IPostCommentResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IPostCommentResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser);
	public IPostCommentResponseFluent ProjectToResponseWithoutPost(CurrentUserQuery currentUser);
	public IPostCommentFluent ApplyIncludes(PostCommentInclude include);
}
