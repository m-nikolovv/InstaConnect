namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;

public static class RefreshTokenRouteFactory
{
	public static string GetDefaultName(string name)
	{
		const string Format = "api/v1/users/{0}/refresh-tokens";

		return Format.FormatCurrentCulture(name);
	}

	public static string GetDefaultCurrent()
	{
		const string Route = "api/v1/users/current/refresh-tokens";

		return Route;
	}

	public static string GetCurrent()
	{
		const string Format = "{0}/current";

		return Format.FormatCurrentCulture(GetDefaultCurrent());
	}

	public static string GetCurrentRotate()
	{
		const string Format = "{0}/rotate";

		return Format.FormatCurrentCulture(GetCurrent());
	}

	public static string GetRoute(IssueRefreshTokenApiRequest request)
	{
		return GetDefaultName(request.Name);
	}

	public static string GetRoute(RotateRefreshTokenApiRequest request)
	{
		return GetCurrentRotate();
	}

	public static string GetRoute(DeleteCurrentRefreshTokenApiRequest request)
	{
		return GetCurrent();
	}
}
