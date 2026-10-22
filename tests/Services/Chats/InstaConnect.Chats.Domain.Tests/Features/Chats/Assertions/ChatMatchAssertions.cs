using InstaConnect.Chats.Events.Features.Chats.Models;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;

public static class ChatMatchAssertions
{
	extension(ChatId response)
	{
		public void ShouldSatisfy(AddChatCommand command, Chat chat)
		{
			response.ShouldSatisfy(p => p.Matches(command, chat));
		}
	}

	extension(ChatResponse response)
	{
		public void ShouldSatisfy(GetChatByIdQuery query, Chat chat)
		{
			response.ShouldSatisfy(p => p.Matches(query, chat));
		}

		public void ShouldSatisfyInverted(GetChatByIdQuery query, Chat chat)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(query, chat));
		}
	}

	extension(ChatCollectionResponse response)
	{
		public void ShouldSatisfy(
			GetAllChatsQuery query,
			User participantOne,
			ICollection<Chat> chats)
		{
			response.ShouldSatisfy(p => p.Matches(query, participantOne, chats));
		}

		public void ShouldSatisfy(
			GetAllChatsQuery query,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, participantOne, chats, termTransformer));
		}

		public void ShouldSatisfyInverted(
			GetAllChatsQuery query,
			User participantTwo,
			ICollection<Chat> chats)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(query, participantTwo, chats));
		}

		public void ShouldSatisfyInverted(
			GetAllChatsQuery query,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(query, participantTwo, chats, termTransformer));
		}
	}

	extension(Chat chat)
	{
		public void ShouldSatisfy(AddChatCommand command)
		{
			chat.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(ChatAddedEventRequest r)
	{
		public void ShouldSatisfy(AddChatCommand command, Chat entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}
}
