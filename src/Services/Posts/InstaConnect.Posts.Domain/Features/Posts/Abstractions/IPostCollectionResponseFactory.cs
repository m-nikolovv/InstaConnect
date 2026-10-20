namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostCollectionResponseFactory
{
	public PostCollectionResponse Create(ICollection<PostResponse> posts, long totalCount, PostsPaginationQuery pagination);

	public PostCollectionResponse CreateForUser(UserResponse user, ICollection<PostResponse> posts, long totalCount, PostsPaginationQuery pagination);
}
