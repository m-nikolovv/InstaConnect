namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostResponseFluent : IMongoDbResponseFluent<PostResponse>
{
	public IPostResponseFluent ApplySorting(PostsSortingQuery query);
	public IPostResponseFluent ApplySorting(PostsForUserSortingQuery query);
	public IPostResponseFluent ApplyPagination(PostsPaginationQuery query);
}
