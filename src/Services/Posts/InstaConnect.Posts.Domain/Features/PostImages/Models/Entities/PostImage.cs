using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

namespace InstaConnect.Posts.Domain.Features.PostImages.Models.Entities;

public class PostImage : IEntityWithId<PostImageId>
{
	private PostImage()
	{
		Id = new(new(string.Empty), string.Empty);
		Url = new(string.Empty);
	}

	public PostImage(
		PostImageId id,
		Url url,
		DateTimeOffset createdAtUtc)
	{
		Id = id;
		Url = url;
		CreatedAtUtc = createdAtUtc;
	}

	public PostImageId Id { get; }

	public Url Url { get; }

	public Post? Post { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public PostImage AddPost(Post? post)
	{
		Post = post;

		return this;
	}
}
