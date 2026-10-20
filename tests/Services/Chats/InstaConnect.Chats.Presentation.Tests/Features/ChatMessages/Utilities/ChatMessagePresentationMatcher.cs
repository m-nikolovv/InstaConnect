using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessagePresentationMatcher
{
	extension(GetAllChatMessagesApiRequest request)
	{
		public GetAllChatMessagesQueryRequest IsGetAllChatMessagesQueryRequest()
		{
			return Matcher.Is<GetAllChatMessagesQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetChatMessageByIdApiRequest request)
	{
		public GetChatMessageByIdQueryRequest IsGetChatMessageByIdQueryRequest()
		{
			return Matcher.Is<GetChatMessageByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(AddChatMessageApiRequest request)
	{
		public AddChatMessageCommandRequest IsAddChatMessageCommandRequest()
		{
			return Matcher.Is<AddChatMessageCommandRequest>(p => p.Matches(request));
		}
	}

	extension(UpdateChatMessageApiRequest request)
	{
		public UpdateChatMessageCommandRequest IsUpdateChatMessageCommandRequest()
		{
			return Matcher.Is<UpdateChatMessageCommandRequest>(p => p.Matches(request));
		}
	}

	extension(DeleteChatMessageApiRequest request)
	{
		public DeleteChatMessageCommandRequest IsDeleteChatMessageCommandRequest()
		{
			return Matcher.Is<DeleteChatMessageCommandRequest>(p => p.Matches(request));
		}
	}
}
