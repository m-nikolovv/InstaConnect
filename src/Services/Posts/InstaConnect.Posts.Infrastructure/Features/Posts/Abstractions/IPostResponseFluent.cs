namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostResponseFluent : IMongoDbResponseFluent<PostResponse>
{
	public IPostResponseFluent Sort(PostsSortingQuery query);
	public IPostResponseFluent Sort(PostsForUserSortingQuery query);
	public IPostResponseFluent Paginate(PostsPaginationQuery query);
}
