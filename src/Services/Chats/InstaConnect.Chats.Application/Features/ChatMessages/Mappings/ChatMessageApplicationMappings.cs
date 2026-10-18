using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

using Mapster;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Mappings;

public class ChatMessageApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllChatMessagesQueryRequest, GetAllChatMessagesQuery>()
			.ConstructUsing(src => new(
									   new(
										   new(
											   new(src.CurrentUserId),
											   new(src.ParticipantTwoId))),
										new(
											src.SortOrder,
											src.SortTerm),
										new(
											src.Page,
											src.PageSize),
										new(
											new(src.CurrentUserId))));

		config.NewConfig<ChatMessageCollectionResponse, GetAllChatMessagesQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<ChatMessageCollectionQueryResponse>(config)));

		config.NewConfig<GetChatMessageByIdQueryRequest, GetChatMessageByIdQuery>()
			.ConstructUsing(src => new(
									   new(
										   new(
											   new(src.CurrentUserId),
											   new(src.ParticipantTwoId)),
										   src.MessageId),
									   new(
										   new(src.CurrentUserId))));

		config.NewConfig<ChatMessageResponse, GetChatMessageByIdQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<ChatMessageQueryResponse>(config)));

		config.NewConfig<AddChatMessageCommandRequest, AddChatMessageCommand>()
			.ConstructUsing(src => new(
									   new(
											   new(src.ParticipantOneId),
											   new(src.ParticipantTwoId)),
									   src.Content,
									   src.Images));

		config.NewConfig<ChatMessageId, AddChatMessageCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<ChatMessageIdCommandResponse>(config)));

		config.NewConfig<UpdateChatMessageCommandRequest, UpdateChatMessageCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(
											   new(src.ParticipantOneId),
											   new(src.ParticipantTwoId)),
										   src.MessageId),
									   src.Content));

		config.NewConfig<ChatMessageId, UpdateChatMessageCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<ChatMessageIdCommandResponse>(config)));

		config.NewConfig<DeleteChatMessageCommandRequest, DeleteChatMessageCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(
											   new(src.ParticipantOneId),
											   new(src.ParticipantTwoId)),
										   src.MessageId)));

		config.NewConfig<ChatMessageId, ChatMessageIdCommandResponse>()
			.ConstructUsing(src => new(
				src.Id.ParticipantOneId.Id,
				src.Id.ParticipantTwoId.Id,
				src.MessageId));

		config.NewConfig<ChatMessageResponse, ChatMessageQueryResponse>()
			.ConstructUsing(src => new(
				src.Id.Id.ParticipantOneId.Id,
				src.Id.Id.ParticipantTwoId.Id,
				src.Id.MessageId,
				src.SenderId.Id,
				src.Content,
				src.Summary.Value,
				src.Chat.Adapt<ChatQueryResponse>(config),
				src.Sender.Adapt<UserQueryResponse>(config),
				src.ChatMessageImages.Adapt<ICollection<ChatMessageImageQueryResponse>>(config),
				src.CreatedAtUtc,
				src.UpdatedAtUtc));

		config.NewConfig<ChatMessageCollectionResponse, ChatMessageCollectionQueryResponse>()
			.ConstructUsing(src => new(
				src.Chat.Adapt<ChatQueryResponse>(config),
				src.Sender.Adapt<UserQueryResponse>(config),
				src.ChatMessages.Adapt<ICollection<ChatMessageQueryResponse>>(config),
				src.Page,
				src.PageSize,
				src.TotalCount,
				src.HasNextPage,
				src.HasPreviousPage));
	}
}
