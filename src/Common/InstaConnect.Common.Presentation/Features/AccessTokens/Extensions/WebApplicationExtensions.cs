namespace InstaConnect.Common.Presentation.Features.AccessTokens.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication webApplication)
	{
		public WebApplication UseAccessTokens()
		{
			webApplication.UseAuthentication();
			webApplication.UseAuthorization();

			return webApplication;
		}
	}
}
