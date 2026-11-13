namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeResponseFluent : IMongoDbResponseFluent<PostCommentLikeResponse>
{
	public IPostCommentLikeResponseFluent Sort(PostCommentLikesSortingQuery query);
	public IPostCommentLikeResponseFluent Sort(PostCommentLikesForUserSortingQuery query);
	public IPostCommentLikeResponseFluent Paginate(PostCommentLikesPaginationQuery query);
}
