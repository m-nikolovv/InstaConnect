using InstaConnect.Chats.Domain.Features.ChatMessageImages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageDataFaker
{
	public static string GetImageId()
	{
		return DataFaker.GetAverageString(ChatMessageImageConfigurations.ImageIdMaxLength, ChatMessageImageConfigurations.ImageIdMinLength);
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
		return DataFaker.GetAverageNumber(ChatMessageImageConfigurations.ImageMaxSize);
	}

	public static int GetImagesCount()
	{
		return DataFaker.GetAverageNumber(ChatMessageConfigurations.ImagesMaxCount);
	}

	public static ICollection<IFormFile> GetImages()
	{
		return [.. Enumerable.Range(default, GetImagesCount()).Select(_ => DataFaker.GetFormFile(GetImageSize()))];
	}
}
