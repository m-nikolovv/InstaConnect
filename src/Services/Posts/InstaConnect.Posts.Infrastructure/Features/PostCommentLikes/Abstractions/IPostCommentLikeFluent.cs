namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeFluent : IMongoDbFluent<PostCommentLike, PostCommentLikeId>
{
	public IPostCommentLikeFluent Match(PostCommentLikesFilterQuery filter);
	public IPostCommentLikeFluent Match(PostCommentLikesForUserFilterQuery filter);
	public IPostCommentLikeFluent Match(PostCommentLikeId filter);
	public IPostCommentLikeFluent Match(IEnumerable<PostCommentLikeId> filter);
	public IPostCommentLikeResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IPostCommentLikeResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser);
	public IPostCommentLikeResponseFluent ProjectToResponseWithoutPostComment(CurrentUserQuery currentUser);
	public IPostCommentLikeFluent Include(PostCommentLikeInclude include);
}
