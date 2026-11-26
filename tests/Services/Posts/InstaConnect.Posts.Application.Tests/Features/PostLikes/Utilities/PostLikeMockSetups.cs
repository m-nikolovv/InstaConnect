using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
	extension(IPostLikeQueryService likeService)
	{
		public void SetupGetAllAsync(
		GetAllPostLikesQueryRequest request,
		Post post,
		ICollection<PostLike> postLikes,
		CancellationToken cancellationToken)
		{
			likeService.SetupGetAllAsync(request.IsGetAllPostLikesQuery(), postLikes.ToResponse(request, post), cancellationToken);
		}

		public void SetupGetAllAsync(
			GetAllPostLikesQuery query,
			PostLikeCollectionResponse response,
			CancellationToken cancellationToken)
		{
			likeService
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			User user,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			likeService.SetupGetAllForUserAsync(request.IsGetAllPostLikesForUserQuery(), postLikes.ToResponse(request, user), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostLikesForUserQuery query,
			PostLikeCollectionResponse response,
			CancellationToken cancellationToken)
		{
			likeService
				.GetAllForUserAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			likeService.SetupGetByIdAsync(request.IsGetPostLikeByIdQuery(), postLike.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetPostLikeByIdQuery query,
			PostLikeResponse response,
			CancellationToken cancellationToken)
		{
			likeService
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IPostLikeCommandService likeService)
	{
		public void SetupAddAsync(
		AddPostLikeCommandRequest request,
		PostLike postLike,
		CancellationToken cancellationToken)
		{
			likeService.SetupAddAsync(request.IsAddPostLikeCommand(), postLike.ToResponse(request), cancellationToken);
		}

		public void SetupAddAsync(
			AddPostLikeCommand command,
			PostLikeId id,
			CancellationToken cancellationToken)
		{
			likeService
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
