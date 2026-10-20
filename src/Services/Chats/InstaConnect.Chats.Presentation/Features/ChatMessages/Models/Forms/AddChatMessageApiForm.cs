namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Forms;

public record AddChatMessageApiForm(
	string Content,
	ICollection<IFormFile>? Images
)
{
	public ICollection<IFormFile> Images { get; } = Images ?? [];
}
