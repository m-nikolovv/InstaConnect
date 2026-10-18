using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Posts.Presentation.Features.Posts.Utilities;

public static class PostRouteFactory
{
	public static string GetDefault()
	{
		const string Route = "api/v1/posts";

		return Route;
	}

	public static string GetForUserDefault(string userId)
	{
		const string Format = "api/v1/users/{0}/posts";

		return Format.FormatCurrentCulture(userId);
	}

	public static string GetId(string id)
	{
		const string Format = "{0}/{1}";

		return Format.FormatCurrentCulture(
			GetDefault(),
			id);
	}

	public static string GetRoute(GetAllPostsApiRequest request)
	{
		const string Format = "{0}?userName={1}&title={2}&sortOrder={3}&sortTerm={4}&page={5}&pageSize={6}";

		return Format.FormatCurrentCulture(
			GetDefault(),
			request.UserName,
			request.Title,
			request.SortOrder,
			request.SortTerm,
			request.Page,
			request.PageSize);
	}

	public static string GetRoute(GetAllPostsForUserApiRequest request)
	{
		const string Format = "{0}?title={1}&sortOrder={2}&sortTerm={3}&page={4}&pageSize={5}";

		return Format.FormatCurrentCulture(
			GetForUserDefault(request.UserId),
			request.Title,
			request.SortOrder,
			request.SortTerm,
			request.Page,
			request.PageSize);
	}

	public static string GetRoute(GetPostByIdApiRequest request)
	{
		return GetId(request.Id);
	}

	public static string GetRoute(AddPostApiRequest request)
	{
		return GetDefault();
	}

	public static string GetRoute(UpdatePostApiRequest request)
	{
		return GetId(request.Id);
	}

	public static string GetRoute(DeletePostApiRequest request)
	{
		return GetId(request.Id);
	}
}
