using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageDataFaker
{
	public static string GetImageId()
	{
		return DataFaker.GetAverageString(PostCommentImageConfigurations.ImageIdMaxLength, PostCommentImageConfigurations.ImageIdMinLength);
	}

	public static string GetUrl()
	{
		return DataFaker.GetUrl();
	}

	public static DateTimeOffset GetCreatedAtUtc()
	{
		return DataFaker.GetSoonDate();
	}

	public static ICollection<IFormFile> GetImages(int numberOfImages)
	{
		return [.. Enumerable.Range(default, numberOfImages).Select(_ => DataFaker.GetFormFile())];
	}
}
