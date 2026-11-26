using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Follows.Application.Features.Users.Abstractions;
using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
	extension(Follow follow)
	{
		public FollowId ToResponse(
			AddFollowCommandRequest request)
		{
			return follow.ToId();
		}

		public FollowResponse ToResponse(
			GetFollowByIdQueryRequest request)
		{
			return follow.ToFullResponse(request.CurrentUserId);
		}
	}

	extension(ICollection<Follow> follows)
	{
		internal FollowCollectionResponse ToResponseWithoutFollowing<TRequest>(
		TRequest request,
		User follower,
		Func<TRequest, Follow, bool> filter,
		Func<TRequest, Follow, FollowResponse> transform)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = follows.Count(follow => filter(request, follow));

			return new(follower?.ToFullResponse(),
					   null,
					   follows.Filter(request, follow => filter(request, follow), follow => transform(request, follow)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal FollowCollectionResponse ToResponseWithoutFollower<TRequest>(
			TRequest request,
			User following,
			Func<TRequest, Follow, bool> filter,
			Func<TRequest, Follow, FollowResponse> transform)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = follows.Count(follow => filter(request, follow));

			return new(null,
					   following.ToFullResponse(),
					   follows.Filter(request, follow => filter(request, follow), follow => transform(request, follow)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public FollowCollectionResponse ToResponse(
			GetAllFollowsQueryRequest request,
			User follower)
		{
			return follows.ToResponseWithoutFollowing(
				request,
				follower,
				(request, follow) => follow.MatchesFilter(request),
				(request, follow) => follow.ToResponseWithoutFollower(request.CurrentUserId));
		}

		public FollowCollectionResponse ToResponse(
			GetAllFollowsForFollowingQueryRequest request,
			User following)
		{
			return follows.ToResponseWithoutFollower(
				request,
				following,
				(request, follow) => follow.MatchesFilter(request),
				(request, follow) => follow.ToResponseWithoutFollowing(request.CurrentUserId));
		}
	}
}
