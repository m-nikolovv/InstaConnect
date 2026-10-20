using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.ChatMessageImages.Mappings;

internal class ChatMessageImageDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<ChatMessageImage, ChatMessageImageNotificationRequest>()
			.ConstructUsing(src => new(
				src.Id.Id.Id.ParticipantOneId.Id,
				src.Id.Id.Id.ParticipantTwoId.Id,
				src.Id.Id.MessageId,
				src.Id.ImageId,
				src.Url.Value,
				src.CreatedAtUtc));
	}
}
