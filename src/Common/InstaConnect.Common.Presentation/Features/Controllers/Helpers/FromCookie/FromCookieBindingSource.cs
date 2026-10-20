namespace InstaConnect.Common.Presentation.Features.Controllers.Helpers.FromCookie;

public static class FromCookieBindingSource
{
	public static readonly BindingSource Instance = new(
		"Cookie",
		"BindingSource_Cookie",
		false,
		true);
}
