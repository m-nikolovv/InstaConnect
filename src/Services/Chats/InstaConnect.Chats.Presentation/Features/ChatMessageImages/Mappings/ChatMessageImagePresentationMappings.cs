using InstaConnect.Chats.Application.Features.ChatMessageImages.Models;
using InstaConnect.Chats.Presentation.Features.ChatMessageImages.Models.Responses;

namespace InstaConnect.Chats.Presentation.Features.ChatMessageImages.Mappings;

internal class ChatMessageImagePresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<ChatMessageImageQueryResponse, ChatMessageImageApiResponse>()
			.ConstructUsing(src => new(
				src.ParticipantOneId,
				src.ParticipantTwoId,
				src.MessageId,
				src.ImageId,
				src.Url,
				src.CreatedAtUtc));
	}
}
