using System.Net.Mime;

namespace InstaConnect.Identity.Domain.Features.Users.Utilities;

public static class UserConfigurations
{
	public const int IdMinLength = 7;
	public const int IdMaxLength = 100;

	public const int EmailMinLength = 7;
	public const int EmailMaxLength = 100;

	public const int FirstNameMinLength = 7;
	public const int FirstNameMaxLength = 100;

	public const int LastNameMinLength = 7;
	public const int LastNameMaxLength = 100;

	public const int NameMinLength = 7;
	public const int NameMaxLength = 100;

	public const int PasswordMinLength = 7;
	public const int PasswordMaxLength = 100;

	public const int PageMinValue = 1;
	public const int PageMaxValue = 100;

	public const int PageSizeMinValue = 1;
	public const int PageSizeMaxValue = 100;

	public const int ProfileImageMaxSize = 5 * 1024 * 1024;

	public static readonly ICollection<string> ProfileImageContentTypes = [MediaTypeNames.Image.Jpeg, MediaTypeNames.Image.Png, MediaTypeNames.Image.Webp];
}
