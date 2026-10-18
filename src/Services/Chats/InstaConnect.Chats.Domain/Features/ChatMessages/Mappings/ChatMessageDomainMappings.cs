using Mapster;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Mappings;

internal class ChatMessageDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<ChatMessage, ChatMessageNotificationRequest>()
			.ConstructUsing(src => new(
				src.Id.Id.ParticipantOneId.Id,
				src.Id.Id.ParticipantTwoId.Id,
				src.Id.MessageId,
				src.Sender.Adapt<UserNotificationRequest>(config)!,
				src.Chat.Adapt<ChatNotificationRequest>(config)!,
				src.ChatMessageImages.Adapt<ICollection<ChatMessageImageNotificationRequest>>(config),
				src.Content,
				src.Summary.Value,
				src.CreatedAtUtc,
				src.UpdatedAtUtc));

		config.NewConfig<ChatMessage, ChatMessageAddedNotificationRequest>()
			.ConstructUsing(src => new(src.Adapt<ChatMessageNotificationRequest>(config)));

		config.NewConfig<ChatMessage, ChatMessageUpdatedNotificationRequest>()
			.ConstructUsing(src => new(src.Adapt<ChatMessageNotificationRequest>(config)));

		config.NewConfig<ChatMessage, ChatMessageDeletedNotificationRequest>()
			.ConstructUsing(src => new(src.Adapt<ChatMessageNotificationRequest>(config)));
	}
}
