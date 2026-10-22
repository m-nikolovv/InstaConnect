using InstaConnect.Chats.Events.Features.Chats.Models;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Tests.Features.Users.Assertions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatMatchAssertions
{
	extension(AddChatApiResponse response)
	{
		public void ShouldSatisfy(
		AddChatApiRequest request,
		Chat chat)
		{
			response.ShouldSatisfy(p => p.Matches(request, chat));
		}
	}

	extension(GetChatByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetChatByIdApiRequest request,
		Chat chat)
		{
			response.ShouldSatisfy(p => p.Matches(request, chat));
		}

		public void ShouldSatisfyInverted(
		GetChatByIdApiRequest request,
		Chat chat)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, chat));
		}
	}

	extension(GetAllChatsApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllChatsApiRequest request,
		User participantOne,
		ICollection<Chat> chats)
		{
			response.ShouldSatisfy(p => p.Matches(request, participantOne, chats));
		}

		public void ShouldSatisfy(
			GetAllChatsApiRequest request,
			User participantOne,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, participantOne, chats, termTransformer));
		}

		public void ShouldSatisfyInverted(
		GetAllChatsApiRequest request,
		User participantTwo,
		ICollection<Chat> chats)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, participantTwo, chats));
		}

		public void ShouldSatisfyInverted(
			GetAllChatsApiRequest request,
			User participantTwo,
			ICollection<Chat> chats,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, participantTwo, chats, termTransformer));
		}
	}

	extension(ActionResult<AddChatApiResponse> response)
	{
		public void ShouldSatisfy(
		AddChatApiRequest request,
		Chat chat)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, chat));
		}
	}

	extension(ActionResult<GetChatByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetChatByIdApiRequest request,
		Chat chat)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, chat));
		}

		public void ShouldSatisfyInverted(
		GetChatByIdApiRequest request,
		Chat chat)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.MatchesInverted(request, chat));
		}
	}

	extension(ActionResult<GetAllChatsApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllChatsApiRequest request,
		User participantOne,
		ICollection<Chat> chats)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, participantOne, chats));
		}

		public void ShouldSatisfy(
		GetAllChatsApiRequest request,
		User participantOne,
		ICollection<Chat> chats,
		ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, participantOne, chats, termTransformer));
		}

		public void ShouldSatisfyInverted(
		GetAllChatsApiRequest request,
		User participantTwo,
		ICollection<Chat> chats)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.MatchesInverted(request, participantTwo, chats));
		}

		public void ShouldSatisfyInverted(
		GetAllChatsApiRequest request,
		User participantTwo,
		ICollection<Chat> chats,
		ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.MatchesInverted(request, participantTwo, chats, termTransformer));
		}
	}

	extension(Chat chat)
	{
		public void ShouldSatisfy(AddChatApiRequest request)
		{
			chat.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ChatAddedEventRequest r)
	{
		public void ShouldSatisfy(AddChatApiRequest request, Chat entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
