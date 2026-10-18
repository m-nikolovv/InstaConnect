namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Forms;

public record AddPostCommentApiForm(
	string Content,
	ICollection<IFormFile>? Images
)
{
	public ICollection<IFormFile> Images { get; } = Images ?? [];
}
