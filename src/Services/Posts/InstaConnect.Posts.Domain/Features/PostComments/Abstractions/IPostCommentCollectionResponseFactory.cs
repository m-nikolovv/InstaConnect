namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentCollectionResponseFactory
{
	public PostCommentCollectionResponse Create(
		PostResponse? post,
		ICollection<PostCommentResponse> postComments,
		long totalCount,
		PostCommentsPaginationQuery pagination);

	public PostCommentCollectionResponse CreateForUser(
		UserResponse? user,
		ICollection<PostCommentResponse> postComments,
		long totalCount,
		PostCommentsPaginationQuery pagination);
}
