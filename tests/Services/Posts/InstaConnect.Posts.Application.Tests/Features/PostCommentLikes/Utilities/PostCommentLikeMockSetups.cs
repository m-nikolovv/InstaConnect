using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IPostCommentLikeQueryService commentLikeService)
	{
		public void SetupGetAllAsync(
			GetAllPostCommentLikesQueryRequest request,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			commentLikeService.SetupGetAllAsync(request.IsGetAllPostCommentLikesQuery(), postCommentLikes.ToResponse(request, postComment), cancellationToken);
		}

		public void SetupGetAllAsync(
			GetAllPostCommentLikesQuery query,
			PostCommentLikeCollectionResponse response,
			CancellationToken cancellationToken)
		{
			commentLikeService
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQueryRequest request,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			commentLikeService.SetupGetAllForUserAsync(request.IsGetAllPostCommentLikesForUserQuery(), postCommentLikes.ToResponse(request, user), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			PostCommentLikeCollectionResponse response,
			CancellationToken cancellationToken)
		{
			commentLikeService
				.GetAllForUserAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetPostCommentLikeByIdQueryRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			commentLikeService.SetupGetByIdAsync(request.IsGetPostCommentLikeByIdQuery(), postCommentLike.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			PostCommentLikeResponse response,
			CancellationToken cancellationToken)
		{
			commentLikeService
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IPostCommentLikeCommandService commentLikeService)
	{
		public void SetupAddAsync(
			AddPostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			commentLikeService.SetupAddAsync(request.IsAddPostCommentLikeCommand(), postCommentLike.ToResponse(request), cancellationToken);
		}

		public void SetupAddAsync(
			AddPostCommentLikeCommand command,
			PostCommentLikeId id,
			CancellationToken cancellationToken)
		{
			commentLikeService
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
