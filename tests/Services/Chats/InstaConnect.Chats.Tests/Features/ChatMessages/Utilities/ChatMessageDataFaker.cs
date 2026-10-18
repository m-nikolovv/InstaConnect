namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageDataFaker
{
	public static string GetId()
	{
		return DataFaker.GetAverageString(ChatMessageConfigurations.IdMaxLength, ChatMessageConfigurations.IdMinLength);
	}

	public static string GetContent()
	{
		return DataFaker.GetAverageString(ChatMessageConfigurations.ContentMaxLength, ChatMessageConfigurations.ContentMinLength);
	}

	public static string GetSummary()
	{
		return DataFaker.GetAverageString(ChatMessageConfigurations.SummaryMaxLength, ChatMessageConfigurations.SummaryMinLength);
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

	public static ChatMessagesSortTerm GetSortTerm()
	{
		const ChatMessagesSortTerm SortTerm = ChatMessagesSortTerm.ByCreatedAt;

		return SortTerm;
	}
}
