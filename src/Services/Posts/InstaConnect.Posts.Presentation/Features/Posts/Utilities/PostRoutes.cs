namespace InstaConnect.Posts.Presentation.Features.Posts.Utilities;

public static class PostRoutes
{
	public const string Resource = "api/v{version:apiVersion}/posts";

	public const string UserResource = "api/v{version:apiVersion}/users/{userId}/posts";

	public const string Id = "{id}";

	public const string Version1 = "1.0";
}

