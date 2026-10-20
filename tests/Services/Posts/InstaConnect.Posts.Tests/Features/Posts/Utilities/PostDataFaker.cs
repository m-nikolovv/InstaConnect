namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostDataFaker
{
	public static string GetId()
	{
		return DataFaker.GetAverageString(PostConfigurations.IdMaxLength, PostConfigurations.IdMinLength);
	}

	public static string GetTitle()
	{
		return DataFaker.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);
	}

	public static string GetTitleWithPrefix(string title)
	{
		return DataFaker.GetAverageWithPrefixString(title, PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);
	}

	public static string GetContent()
	{
		return DataFaker.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength);
	}

	public static string GetSummary()
	{
		return DataFaker.GetAverageString(PostConfigurations.SummaryMaxLength, PostConfigurations.SummaryMinLength);
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

	public static PostsSortTerm GetSortTerm()
	{
		const PostsSortTerm SortTerm = PostsSortTerm.ByCreatedAt;

		return SortTerm;
	}

	public static PostsForUserSortTerm GetForUserSortTerm()
	{
		const PostsForUserSortTerm SortTerm = PostsForUserSortTerm.ByCreatedAt;

		return SortTerm;
	}
}
