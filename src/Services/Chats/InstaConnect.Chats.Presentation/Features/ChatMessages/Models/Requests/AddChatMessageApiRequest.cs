using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Forms;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record AddChatMessageApiRequest(
	[UserIdFromClaim] string ParticipantOneId,
	[FromRoute] string ParticipantTwoId,
	[FromForm(Name = "")] AddChatMessageApiForm Form
);
