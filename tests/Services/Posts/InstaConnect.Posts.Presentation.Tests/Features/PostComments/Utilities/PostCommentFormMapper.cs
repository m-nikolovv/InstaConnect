using InstaConnect.Posts.Presentation.Features.PostComments.Models.Forms;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentFormMapper
{
	extension(AddPostCommentApiForm form)
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
