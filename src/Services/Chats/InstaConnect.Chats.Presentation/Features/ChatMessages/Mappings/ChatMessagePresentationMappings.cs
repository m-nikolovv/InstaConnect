using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
using InstaConnect.Chats.Application.Features.ChatMessages.Models;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;
using InstaConnect.Chats.Presentation.Features.ChatMessageImages.Models.Responses;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Responses;

using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Mappings;

internal class ChatMessagePresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllChatMessagesApiRequest, GetAllChatMessagesQueryRequest>()
			.ConstructUsing(src => new(
				src.ParticipantTwoId,
				src.CurrentUserId,
				src.SortOrder,
				src.SortTerm,
				src.Page,
				src.PageSize));

		config.NewConfig<GetAllChatMessagesQueryResponse, GetAllChatMessagesApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<ChatMessageCollectionApiResponse>(config)));

		config.NewConfig<GetChatMessageByIdApiRequest, GetChatMessageByIdQueryRequest>()
			.ConstructUsing(src => new(
				src.ParticipantTwoId,
				src.MessageId,
				src.CurrentUserId));

		config.NewConfig<GetChatMessageByIdQueryResponse, GetChatMessageByIdApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<ChatMessageApiResponse>(config)));

		config.NewConfig<AddChatMessageApiRequest, AddChatMessageCommandRequest>()
			.ConstructUsing(src => new(
				src.ParticipantOneId,
				src.ParticipantTwoId,
				src.Form.Content,
				src.Form.Images));

		config.NewConfig<AddChatMessageCommandResponse, AddChatMessageApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<ChatMessageIdApiResponse>(config)));

		config.NewConfig<UpdateChatMessageApiRequest, UpdateChatMessageCommandRequest>()
			.ConstructUsing(src => new(
				src.ParticipantOneId,
				src.ParticipantTwoId,
				src.MessageId,
				src.Body.Content));

		config.NewConfig<UpdateChatMessageCommandResponse, UpdateChatMessageApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<ChatMessageIdApiResponse>(config)));

		config.NewConfig<DeleteChatMessageApiRequest, DeleteChatMessageCommandRequest>()
			.ConstructUsing(src => new(
				src.ParticipantOneId,
				src.ParticipantTwoId,
				src.MessageId));

		config.NewConfig<ChatMessageIdCommandResponse, ChatMessageIdApiResponse>()
			.ConstructUsing(src => new(
				src.ParticipantOneId,
				src.ParticipantTwoId,
				src.MessageId));

		config.NewConfig<ChatMessageQueryResponse, ChatMessageApiResponse>()
			.ConstructUsing(src => new(
				src.ParticipantOneId,
				src.ParticipantTwoId,
				src.MessageId,
				src.SenderId,
				src.Content,
				src.Summary,
				src.Chat.Adapt<ChatApiResponse>(config),
				src.Sender.Adapt<UserApiResponse>(config),
				src.ChatMessageImages.Adapt<ICollection<ChatMessageImageApiResponse>>(config),
				src.CreatedAtUtc,
				src.UpdatedAtUtc));

		config.NewConfig<ChatMessageCollectionQueryResponse, ChatMessageCollectionApiResponse>()
			.ConstructUsing(src => new(
				  src.Chat.Adapt<ChatApiResponse>(config),
				  src.Sender.Adapt<UserApiResponse>(config),
				  src.ChatMessages.Adapt<ICollection<ChatMessageApiResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));

		config.NewConfig<HubCallerContext, TypingStartedNotificationRequest>()
			.ConstructUsing(src => new(src.UserIdentifier!));
	}
}
