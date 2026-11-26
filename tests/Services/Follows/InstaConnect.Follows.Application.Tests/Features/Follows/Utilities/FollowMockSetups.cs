using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IFollowQueryService likeService)
	{
		public void SetupGetAllAsync(
		GetAllFollowsQueryRequest request,
		User follower,
		ICollection<Follow> follows,
		CancellationToken cancellationToken)
		{
			likeService.SetupGetAllAsync(request.IsGetAllFollowsQuery(), follows.ToResponse(request, follower), cancellationToken);
		}

		public void SetupGetAllAsync(
			GetAllFollowsQuery query,
			FollowCollectionResponse response,
			CancellationToken cancellationToken)
		{
			likeService
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetAllForFollowingAsync(
			GetAllFollowsForFollowingQueryRequest request,
			User following,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			likeService.SetupGetAllForFollowingAsync(request.IsGetAllFollowsForFollowingQuery(), follows.ToResponse(request, following), cancellationToken);
		}

		public void SetupGetAllForFollowingAsync(
			GetAllFollowsForFollowingQuery query,
			FollowCollectionResponse response,
			CancellationToken cancellationToken)
		{
			likeService
				.GetAllForFollowingAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetFollowByIdQueryRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			likeService.SetupGetByIdAsync(request.IsGetFollowByIdQuery(), follow.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetFollowByIdQuery query,
			FollowResponse response,
			CancellationToken cancellationToken)
		{
			likeService
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IFollowCommandService likeService)
	{
		public void SetupAddAsync(
		AddFollowCommandRequest request,
		Follow follow,
		CancellationToken cancellationToken)
		{
			likeService.SetupAddAsync(request.IsAddFollowCommand(), follow.ToResponse(request), cancellationToken);
		}

		public void SetupAddAsync(
			AddFollowCommand command,
			FollowId id,
			CancellationToken cancellationToken)
		{
			likeService
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
