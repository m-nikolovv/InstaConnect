namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeFluent : IMongoDbFluent<PostCommentLike>
{
	public IPostCommentLikeFluent Match(PostCommentLikesFilterQuery filter);
	public IPostCommentLikeFluent Match(PostCommentLikesForUserFilterQuery filter);
	public IPostCommentLikeFluent Match(PostCommentLikeId filter);
	public IPostCommentLikeResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IPostCommentLikeResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser);
	public IPostCommentLikeResponseFluent ProjectToResponseWithoutPostComment(CurrentUserQuery currentUser);
	public IPostCommentLikeFluent ApplyIncludes(PostCommentLikeInclude include);
}
