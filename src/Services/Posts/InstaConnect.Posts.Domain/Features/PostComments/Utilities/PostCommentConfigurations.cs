namespace InstaConnect.Posts.Domain.Features.PostComments.Utilities;

public static class PostCommentConfigurations
{
	public const int IdMinLength = 7;
	public const int IdMaxLength = 100;

	public const int ContentMinLength = 7;
	public const int ContentMaxLength = 100;

	public const int SummaryMinLength = 7;
	public const int SummaryMaxLength = 500;

	public const int PageMinValue = 1;
	public const int PageMaxValue = 100;

	public const int PageSizeMinValue = 1;
	public const int PageSizeMaxValue = 100;

	public const int ImagesMaxCount = 10;
}
