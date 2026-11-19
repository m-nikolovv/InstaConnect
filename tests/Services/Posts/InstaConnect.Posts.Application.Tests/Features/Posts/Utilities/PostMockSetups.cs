using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

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

		public void SetupGetAllAsync(
			GetAllPostsQuery query,
			PostCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			User user,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			service.SetupGetAllForUserAsync(request.IsGetAllPostsForUserQuery(), posts.ToResponse(request, user), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostsForUserQuery query,
			PostCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllForUserAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetPostByIdQueryRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			service.SetupGetByIdAsync(request.IsGetPostByIdQuery(), post.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetPostByIdQuery query,
			PostResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
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

		public void SetupAddAsync(
			AddPostCommand command,
			PostId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}

		public void SetupUpdateAsync(
			UpdatePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			service.SetupUpdateAsync(request.IsUpdatePostCommand(), post.ToResponse(request), cancellationToken);
		}

		public void SetupUpdateAsync(
			UpdatePostCommand command,
			PostId id,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
