using InstaConnect.Posts.Domain.Features.PostCommentImages.Utilities;

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

	public static int GetImageSize()
	{
		return DataFaker.GetAverageNumber(PostCommentImageConfigurations.ImageMaxSize);
	}

	public static int GetImagesCount()
	{
		return DataFaker.GetAverageNumber(PostCommentConfigurations.ImagesMaxCount);
	}

	public static ICollection<IFormFile> GetImages()
	{
		return [.. Enumerable.Range(default, GetImagesCount()).Select(_ => DataFaker.GetFormFile(GetImageSize()))];
	}
}
