using InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Utilities;

public static class UserClaimRouteFactory
{
	public static string GetDefault(string id)
	{
		const string Format = "api/v1/users/{0}/claims";

		return Format.FormatCurrentCulture(id);
	}

	public static string GetId(string id, ApplicationClaims claim)
	{
		const string Format = "{0}/{1}";

		return Format.FormatCurrentCulture(
			GetDefault(id),
			claim);
	}

	public static string GetRoute(GetAllUserClaimsApiRequest request)
	{
		const string Format = "{0}?sortOrder={1}&sortTerm={2}&page={3}&pageSize={4}";

		return Format.FormatCurrentCulture(
			GetDefault(request.Id),
			request.SortOrder,
			request.SortTerm,
			request.Page,
			request.PageSize);
	}

	public static string GetRoute(AddUserClaimApiRequest request)
	{
		return GetDefault(request.Id);
	}

	public static string GetRoute(DeleteUserClaimApiRequest request)
	{
		return GetId(request.Id, request.Claim);
	}
}
