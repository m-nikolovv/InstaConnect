namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentDataFaker
{
	public static string GetId()
	{
		return DataFaker.GetAverageString(PostCommentConfigurations.IdMaxLength, PostCommentConfigurations.IdMinLength);
	}

	public static string GetContent()
	{
		return DataFaker.GetAverageString(PostCommentConfigurations.ContentMaxLength, PostCommentConfigurations.ContentMinLength);
	}

	public static string GetSummary()
	{
		return DataFaker.GetAverageString(PostCommentConfigurations.SummaryMaxLength, PostCommentConfigurations.SummaryMinLength);
	}

	public static DateTimeOffset GetCreatedAtUtc()
	{
		return DataFaker.GetSoonDate();
	}

	public static DateTimeOffset GetUpdatedAtUtc()
	{
		return DataFaker.GetSoonDate();
	}

	public static int GetPage()
	{
		const int Page = 1;

		return Page;
	}

	public static int GetPageSize()
	{
		const int PageSize = 20;

		return PageSize;
	}

	public static PostCommentsSortTerm GetSortTerm()
	{
		const PostCommentsSortTerm SortTerm = PostCommentsSortTerm.ByCreatedAt;

		return SortTerm;
	}

	public static PostCommentsForUserSortTerm GetForUserSortTerm()
	{
		const PostCommentsForUserSortTerm SortTerm = PostCommentsForUserSortTerm.ByCreatedAt;

		return SortTerm;
	}
}
