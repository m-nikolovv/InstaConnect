using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Utilities;

public static class PostLikeRouteFactory
{
	public static string GetDefault(string id)
	{
		const string Format = "api/v1/posts/{0}/likes";

		return Format.FormatCurrentCulture(id);
	}

	public static string GetForUserDefault(string userId)
	{
		const string Format = "api/v1/users/{0}/post-likes";

		return Format.FormatCurrentCulture(userId);
	}

	public static string GetId(string id, string userId)
	{
		const string Format = "{0}/{1}";

		return Format.FormatCurrentCulture(
			GetDefault(id),
			userId);
	}

	public static string GetCurrent(string id)
	{
		const string Format = "{0}/current";

		return Format.FormatCurrentCulture(GetDefault(id));
	}

	public static string GetRoute(GetAllPostLikesApiRequest request)
	{
		const string Format = "{0}?userName={1}&sortOrder={2}&sortTerm={3}&page={4}&pageSize={5}";

		return Format.FormatCurrentCulture(
			GetDefault(request.Id),
			request.UserName,
			request.SortOrder,
			request.SortTerm,
			request.Page,
			request.PageSize);
	}

	public static string GetRoute(GetAllPostLikesForUserApiRequest request)
	{
		const string Format = "{0}?sortOrder={1}&sortTerm={2}&page={3}&pageSize={4}";

		return Format.FormatCurrentCulture(
			GetForUserDefault(request.UserId),
			request.SortOrder,
			request.SortTerm,
			request.Page,
			request.PageSize);
	}

	public static string GetRoute(GetPostLikeByIdApiRequest request)
	{
		return GetId(request.Id, request.UserId);
	}

	public static string GetRoute(AddPostLikeApiRequest request)
	{
		return GetDefault(request.Id);
	}

	public static string GetRoute(DeletePostLikeApiRequest request)
	{
		return GetCurrent(request.Id);
	}
}
