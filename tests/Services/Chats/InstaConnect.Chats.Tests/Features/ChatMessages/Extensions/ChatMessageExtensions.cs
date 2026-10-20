namespace InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

public static class ChatMessageExtensions
{
	extension(ChatMessage chatMessage)
	{
		public string GetSummary()
		{
			return chatMessage.GetSummary(chatMessage.Content);
		}

		public string GetSummary(string content)
		{
			return chatMessage.GetSummary(content, [.. chatMessage.ChatMessageImages.Select(ci => ci.Url.Value)]);
		}

		public string GetSummary(string content, ICollection<string> images)
		{
			const string Format = "Chat message summary for {0}: {1} {2}: {3} {4}: {5} {6}: {7} {8}: {9}";

			return Format.FormatCurrentCulture(
				nameof(chatMessage.Id.Id.ParticipantOneId), chatMessage.Id.Id.ParticipantOneId.Id,
				nameof(chatMessage.Id.Id.ParticipantTwoId), chatMessage.Id.Id.ParticipantTwoId.Id,
				nameof(chatMessage.Id.MessageId), chatMessage.Id.MessageId,
				nameof(chatMessage.Content), content,
				nameof(chatMessage.ChatMessageImages), images.JoinWithSemicolon());
		}
	}
}
