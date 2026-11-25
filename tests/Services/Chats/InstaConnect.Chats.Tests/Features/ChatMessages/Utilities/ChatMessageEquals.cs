using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
	extension(ChatMessage entity)
	{
		public bool Matches(ChatMessage chatMessage)
		{
			return entity.Id.Matches(chatMessage.Id) &&
				   entity.SenderId.Matches(chatMessage.SenderId) &&
				   entity.Content == chatMessage.Content &&
				   entity.CreatedAtUtc == chatMessage.CreatedAtUtc &&
				   entity.UpdatedAtUtc == chatMessage.UpdatedAtUtc;
		}
	}

	extension(ICollection<ChatMessage> entities)
	{
		public bool Matches(ICollection<ChatMessage> chatMessages)
		{
			return entities.MatchesCollectionAndNotEmpty(
				chatMessages,
				e => e.Id,
				e => e.Id,
				(entity, chatMessage) => entity.Matches(chatMessage));
		}
	}

	extension(ChatMessageId p)
	{
		public bool Matches(ChatMessageId id)
		{
			return p.Matches(id.Id, id.MessageId);
		}

		public bool Matches(ChatId id, string messageId)
		{
			return p.Matches(id.ParticipantOneId.Id, id.ParticipantTwoId.Id, messageId);
		}

		public bool Matches(string participantOneId, string participantTwoId, string messageId)
		{
			return p.Id.Matches(participantOneId, participantTwoId) &&
				   p.MessageId.EqualsOrdinalIgnoreCase(messageId);
		}
	}

	extension(ChatMessageResponse? response)
	{
		public bool MatchesFull(ChatMessage? chatMessage)
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.Id) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFull(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFull(chatMessage.Chat);
		}

		public bool MatchesFullInverted(ChatMessage? chatMessage)
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(new(response.Id.Id.ParticipantTwoId, response.Id.Id.ParticipantOneId), response.Id.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFullInverted(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFullInverted(chatMessage.Chat);
		}

		public bool MatchesWithoutChat(ChatMessage? chatMessage)
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.Id) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFull(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}

		public bool MatchesWithoutChatInverted(ChatMessage? chatMessage)
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(new(response.Id.Id.ParticipantTwoId, response.Id.Id.ParticipantOneId), response.Id.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.Summary.Matches(response.Summary) &&
				   response.ChatMessageImages.MatchesFullInverted(chatMessage.ChatMessageImages) &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}
	}
}
