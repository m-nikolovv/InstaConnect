namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostQueryService
{
	public Task<PostCollectionResponse> GetAllAsync(GetAllPostsQuery query, CancellationToken cancellationToken);

	public Task<PostCollectionResponse> GetAllForUserAsync(GetAllPostsForUserQuery query, CancellationToken cancellationToken);

	public Task<PostResponse> GetByIdAsync(GetPostByIdQuery query, CancellationToken cancellationToken);
}
