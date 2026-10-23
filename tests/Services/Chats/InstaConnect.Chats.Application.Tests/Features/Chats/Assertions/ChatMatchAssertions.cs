using InstaConnect.Chats.Events.Features.Chats.Models;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatMatchAssertions
{
	extension(AddChatCommandResponse response)
	{
		public void ShouldSatisfy(AddChatCommandRequest request, Chat chat)
		{
			response.ShouldSatisfy(p => p.Matches(request, chat));
		}
	}

	extension(GetChatByIdQueryResponse response)
	{
		public void ShouldSatisfy(GetChatByIdQueryRequest request, Chat chat)
		{
			response.ShouldSatisfy(p => p.Matches(request, chat));
		}

		public void ShouldSatisfyInverted(GetChatByIdQueryRequest request, Chat chat)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, chat));
		}
	}

	extension(GetAllChatsQueryResponse response)
	{
		public void ShouldSatisfy(
		GetAllChatsQueryRequest request,
		User participantOne,
		ICollection<Chat> chats)
		{
			response.ShouldSatisfy(p => p.Matches(request, participantOne, chats));
		}

		public void ShouldSatisfy(
			GetAllChatsQueryRequest request,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, participantOne, chats, termTransformer));
		}

		public void ShouldSatisfyInverted(
		GetAllChatsQueryRequest request,
		User participantTwo,
		ICollection<Chat> chats)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, participantTwo, chats));
		}

		public void ShouldSatisfyInverted(
			GetAllChatsQueryRequest request,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, participantTwo, chats, termTransformer));
		}
	}

	extension(Chat chat)
	{
		public void ShouldSatisfy(AddChatCommandRequest request)
		{
			chat.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ChatAddedEventRequest r)
	{
		public void ShouldSatisfy(AddChatCommandRequest request, Chat entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
