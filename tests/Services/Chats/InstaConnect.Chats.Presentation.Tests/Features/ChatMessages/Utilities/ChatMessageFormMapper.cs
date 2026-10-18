using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Forms;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageFormMapper
{
	extension(AddChatMessageApiForm form)
	{
		public MultipartFormDataContent GetContent()
		{
			var multipartContent = new MultipartFormDataContent()
				.AddString(form.Content, nameof(form.Content))
				.AddFiles(form.Images, nameof(form.Images));

			return multipartContent;
		}
	}
}
