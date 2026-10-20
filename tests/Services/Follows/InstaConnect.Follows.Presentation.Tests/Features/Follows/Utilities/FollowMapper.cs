using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Common.Presentation.Tests.Features.Utilities;
using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollowing;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
using InstaConnect.Follows.Presentation.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
	extension(Follow follow)
	{
		internal FollowIdCommandResponse ToIdCommandResponse(
)
		{
			return new(follow.Id.FollowerId.Id, follow.Id.FollowingId.Id);
		}

		internal FollowQueryResponse ToFullQueryResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(follow.Id.FollowerId.Id,
					   follow.Id.FollowingId.Id,
					   follow.Follower?.ToFullQueryResponse(),
					   follow.Following?.ToFullQueryResponse(),
					   follow.Id.FollowerId.Matches(request.CurrentUserId),
					   follow.CreatedAtUtc);
		}

		internal FollowQueryResponse ToQueryResponseWithoutFollower<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(follow.Id.FollowerId.Id,
					   follow.Id.FollowingId.Id,
					   null,
					   follow.Following?.ToFullQueryResponse(),
					   follow.Id.FollowerId.Matches(request.CurrentUserId),
					   follow.CreatedAtUtc);
		}

		internal FollowQueryResponse ToQueryResponseWithoutFollowing<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(follow.Id.FollowerId.Id,
					   follow.Id.FollowingId.Id,
					   follow.Follower?.ToFullQueryResponse(),
					   null,
					   follow.Id.FollowerId.Matches(request.CurrentUserId),
					   follow.CreatedAtUtc);
		}

		public AddFollowCommandResponse ToResponse(
			AddFollowApiRequest request)
		{
			return new(follow.ToIdCommandResponse());
		}

		public GetFollowByIdQueryResponse ToResponse(
			GetFollowByIdApiRequest request)
		{
			return new(follow.ToFullQueryResponse(request));
		}
	}

	extension(ICollection<Follow> follows)
	{
		internal FollowCollectionQueryResponse ToQueryResponseWithoutFollowing<TRequest>(
		TRequest request,
		User follower,
		Func<TRequest, Follow, bool> filter,
		Func<TRequest, Follow, FollowQueryResponse> transform)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = follows.Count(follow => filter(request, follow));

			return new(follower.ToFullQueryResponse(),
					   null,
					   follows.Filter(request, follow => filter(request, follow), follow => transform(request, follow)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal FollowCollectionQueryResponse ToQueryResponseWithoutFollower<TRequest>(
			TRequest request,
			User following,
			Func<TRequest, Follow, bool> filter,
			Func<TRequest, Follow, FollowQueryResponse> transform)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = follows.Count(follow => filter(request, follow));

			return new(null,
					   following.ToFullQueryResponse(),
					   follows.Filter(request, follow => filter(request, follow), follow => transform(request, follow)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllFollowsQueryResponse ToResponse(
			GetAllFollowsApiRequest request,
			User follower)
		{
			return new(follows.ToQueryResponseWithoutFollowing(
													   request,
													   follower,
													   (request, follow) => follow.MatchesFilter(request),
													   (request, follow) => follow.ToQueryResponseWithoutFollower(request)));
		}

		public GetAllFollowsForFollowingQueryResponse ToResponse(
			GetAllFollowsForFollowingApiRequest request,
			User following)
		{
			return new(follows.ToQueryResponseWithoutFollower(
													   request,
													   following,
													   (request, follow) => follow.MatchesFilter(request),
													   (request, follow) => follow.ToQueryResponseWithoutFollowing(request)));
		}
	}
}
