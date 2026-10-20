namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeResponseFluent : IMongoDbResponseFluent<PostLikeResponse>
{
	public IPostLikeResponseFluent ApplySorting(PostLikesSortingQuery query);
	public IPostLikeResponseFluent ApplySorting(PostLikesForUserSortingQuery query);
	public IPostLikeResponseFluent ApplyPagination(PostLikesPaginationQuery query);
}
