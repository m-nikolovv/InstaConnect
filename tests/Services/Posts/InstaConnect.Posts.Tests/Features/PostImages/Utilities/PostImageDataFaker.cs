using InstaConnect.Posts.Domain.Features.PostImages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public static class PostImageDataFaker
{
	public static string GetImageId()
	{
		return DataFaker.GetAverageString(PostImageConfigurations.ImageIdMaxLength, PostImageConfigurations.ImageIdMinLength);
	}

	public static string GetUrl()
	{
		return DataFaker.GetUrl();
	}

	public static DateTimeOffset GetCreatedAtUtc()
	{
		return DataFaker.GetSoonDate();
	}

	public static ICollection<IFormFile> GetImages()
	{
		return [.. Enumerable.Range(default, DataFaker.GetAverageNumber(PostConfigurations.ImagesMaxCount)).Select(_ => DataFaker.GetAverageFormFile(PostImageConfigurations.ImageMaxSize))];
	}
}
