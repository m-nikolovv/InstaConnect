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

	public static int GetImageSize()
	{
		return DataFaker.GetAverageNumber(PostImageConfigurations.ImageMaxSize);
	}

	public static int GetImagesCount()
	{
		return DataFaker.GetAverageNumber(PostConfigurations.ImagesMaxCount);
	}

	public static ICollection<IFormFile> GetImages()
	{
		return [.. Enumerable.Range(default, GetImagesCount()).Select(_ => DataFaker.GetFormFile(GetImageSize()))];
	}
}
