using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.Features.Follows.Utilities;

public static class FollowRouteFactory
{
	public static string GetDefault(string followerId)
	{
		const string Format = "api/v1/followers/{0}/follows";

		return Format.FormatCurrentCulture(followerId);
	}

	public static string GetForFollowingDefault(string followingId)
	{
		const string Format = "api/v1/followings/{0}/follows";

		return Format.FormatCurrentCulture(followingId);
	}

	public static string GetId(string followerId, string followingId)
	{
		const string Format = "{0}/{1}";

		return Format.FormatCurrentCulture(
			GetDefault(followerId),
			followingId);
	}

	public static string GetCurrentDefault()
	{
		const string Route = "api/v1/followers/current/follows";

		return Route;
	}

	public static string GetCurrentId(string followingId)
	{
		const string Format = "{0}/{1}";

		return Format.FormatCurrentCulture(GetCurrentDefault(), followingId);
	}

	public static string GetRoute(GetAllFollowsApiRequest request)
	{
		const string Format = "{0}?followingName={1}&sortOrder={2}&sortTerm={3}&page={4}&pageSize={5}";

		return Format.FormatCurrentCulture(
			GetDefault(request.FollowerId),
			request.FollowingName,
			request.SortOrder,
			request.SortTerm,
			request.Page,
			request.PageSize);
	}

	public static string GetRoute(GetAllFollowsForFollowingApiRequest request)
	{
		const string Format = "{0}?followerName={1}&sortOrder={2}&sortTerm={3}&page={4}&pageSize={5}";

		return Format.FormatCurrentCulture(
			GetForFollowingDefault(request.FollowingId),
			request.FollowerName,
			request.SortOrder,
			request.SortTerm,
			request.Page,
			request.PageSize);
	}

	public static string GetRoute(GetFollowByIdApiRequest request)
	{
		return GetId(request.FollowerId, request.FollowingId);
	}

	public static string GetRoute(AddFollowApiRequest request)
	{
		return GetCurrentDefault();
	}

	public static string GetRoute(DeleteFollowApiRequest request)
	{
		return GetCurrentId(request.FollowingId);
	}
}
