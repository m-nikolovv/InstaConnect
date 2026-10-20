namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenRouteFactory
{
	public static string GetDefaultName(string name)
	{
		const string Format = "api/v1/users/{0}/email-confirmation-tokens";

		return Format.FormatCurrentCulture(name);
	}

	public static string GetDefaultIdVerify(string id, string value)
	{
		const string Format = "api/v1/users/{0}/email-confirmation-tokens/{1}/verify";

		return Format.FormatCurrentCulture(id, value);
	}

	public static string GetRoute(AddEmailConfirmationTokenApiRequest request)
	{
		return GetDefaultName(request.Name);
	}

	public static string GetRoute(VerifyEmailConfirmationTokenApiRequest request)
	{
		return GetDefaultIdVerify(request.Id, request.Value);
	}
}
