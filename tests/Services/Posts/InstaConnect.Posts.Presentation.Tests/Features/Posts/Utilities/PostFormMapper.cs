using InstaConnect.Posts.Presentation.Features.Posts.Models.Forms;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostFormMapper
{
	extension(AddPostApiForm form)
	{
		public MultipartFormDataContent GetContent()
		{
			var multipartContent = new MultipartFormDataContent()
				.AddString(form.Title, nameof(form.Title))
				.AddString(form.Content, nameof(form.Content))
				.AddFiles(form.Images, nameof(form.Images));

			return multipartContent;
		}
	}
}
