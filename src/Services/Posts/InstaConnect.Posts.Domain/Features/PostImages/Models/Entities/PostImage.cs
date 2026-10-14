namespace InstaConnect.Posts.Domain.Features.PostImages.Models.Entities;

public class PostImage : IEntityWithId<PostImageId>
{
	private PostImage()
	{
		Id = new(new(string.Empty), string.Empty);
		Image = new(string.Empty);
	}

	public PostImage(
		PostImageId id,
		Image image,
		DateTimeOffset createdAtUtc)
	{
		Id = id;
		Image = image;
		CreatedAtUtc = createdAtUtc;
	}

	public PostImageId Id { get; }

	public Image Image { get; }

	public Post? Post { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public PostImage AddPost(Post? post)
	{
		Post = post;

		return this;
	}
}
