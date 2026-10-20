using InstaConnect.Chats.Application.Features.ChatMessageImages.Models;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Responses;

namespace InstaConnect.Chats.Application.Features.ChatMessageImages.Mappings;

internal class ChatMessageImageApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<ChatMessageImageResponse, ChatMessageImageQueryResponse>()
			.ConstructUsing(src => new(
				src.Id.Id.Id.ParticipantOneId.Id,
				src.Id.Id.Id.ParticipantTwoId.Id,
				src.Id.Id.MessageId,
				src.Id.ImageId,
				src.Url.Value,
				src.CreatedAtUtc));
	}
}
