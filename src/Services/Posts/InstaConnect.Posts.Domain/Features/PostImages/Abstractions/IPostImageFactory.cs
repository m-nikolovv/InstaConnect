namespace InstaConnect.Posts.Domain.Features.PostImages.Abstractions;

public interface IPostImageFactory
{
	public ICollection<PostImage> CreateRange(PostId id, ICollection<Url> urls);
}
