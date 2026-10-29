using System.Net.Mime;

namespace InstaConnect.Posts.Domain.Features.PostImages.Utilities;

public static class PostImageConfigurations
{
	public const int ImageIdMinLength = 7;

	public const int ImageIdMaxLength = 100;

	public const int ImageMaxSize = 5 * 1024 * 1024;

	public static readonly ICollection<string> ImageContentTypes = [MediaTypeNames.Image.Jpeg, MediaTypeNames.Image.Png, MediaTypeNames.Image.Webp];
}
