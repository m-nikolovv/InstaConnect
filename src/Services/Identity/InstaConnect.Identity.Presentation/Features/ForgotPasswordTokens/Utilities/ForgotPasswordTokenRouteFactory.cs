namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenRouteFactory
{
	public static string GetDefaultName(string name)
	{
		const string Format = "api/v1/users/{0}/forgot-password-tokens";

		return Format.FormatCurrentCulture(name);
	}

	public static string GetDefaultIdVerify(string id, string value)
	{
		const string Format = "api/v1/users/{0}/forgot-password-tokens/{1}/verify";

		return Format.FormatCurrentCulture(id, value);
	}

	public static string GetRoute(AddForgotPasswordTokenApiRequest request)
	{
		return GetDefaultName(request.Name);
	}

	public static string GetRoute(VerifyForgotPasswordTokenApiRequest request)
	{
		return GetDefaultIdVerify(request.Id, request.Value);
	}
}
