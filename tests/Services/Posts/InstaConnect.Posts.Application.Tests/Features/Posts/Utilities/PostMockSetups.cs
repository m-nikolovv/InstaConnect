using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostMockSetups
{
	extension(IPostQueryService service)
	{
		public void SetupGetAllAsync(
		GetAllPostsQueryRequest request,
		ICollection<Post> posts,
		CancellationToken cancellationToken)
		{
			service.SetupGetAllAsync(request.IsGetAllPostsQuery(), posts.ToResponse(request), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			service.SetupGetAllForUserAsync(request.IsGetAllPostsForUserQuery(), posts.ToResponse(request, user), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetPostByIdQueryRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			service.SetupGetByIdAsync(request.IsGetPostByIdQuery(), post.ToResponse(request), cancellationToken);
		}
	}

	extension(IPostCommandService service)
	{
		public void SetupAddAsync(
		AddPostCommandRequest request,
		Post post,
		CancellationToken cancellationToken)
		{
			service.SetupAddAsync(request.IsAddPostCommand(), post.ToResponse(request), cancellationToken);
		}

		public void SetupUpdateAsync(
			UpdatePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			service.SetupUpdateAsync(request.IsUpdatePostCommand(), post.ToResponse(request), cancellationToken);
		}
	}
}
