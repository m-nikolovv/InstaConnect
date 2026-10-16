namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Forms;

public record AddPostApiForm(
	string Title,
	string Content,
	ICollection<IFormFile>? Images
)
{
	public ICollection<IFormFile> Images { get; } = Images ?? [];
}
