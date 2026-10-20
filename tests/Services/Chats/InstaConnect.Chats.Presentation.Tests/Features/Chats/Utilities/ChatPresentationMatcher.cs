using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatPresentationMatcher
{
	extension(GetAllChatsApiRequest request)
	{
		public GetAllChatsQueryRequest IsGetAllChatsQueryRequest()
		{
			return Matcher.Is<GetAllChatsQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetChatByIdApiRequest request)
	{
		public GetChatByIdQueryRequest IsGetChatByIdQueryRequest()
		{
			return Matcher.Is<GetChatByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(AddChatApiRequest request)
	{
		public AddChatCommandRequest IsAddChatCommandRequest()
		{
			return Matcher.Is<AddChatCommandRequest>(p => p.Matches(request));
		}
	}
}
