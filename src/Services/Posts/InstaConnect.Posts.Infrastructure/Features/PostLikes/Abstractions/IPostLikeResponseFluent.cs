namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeResponseFluent : IMongoDbResponseFluent<PostLikeResponse>
{
	public IPostLikeResponseFluent Sort(PostLikesSortingQuery query);
	public IPostLikeResponseFluent Sort(PostLikesForUserSortingQuery query);
	public IPostLikeResponseFluent Paginate(PostLikesPaginationQuery query);
}
