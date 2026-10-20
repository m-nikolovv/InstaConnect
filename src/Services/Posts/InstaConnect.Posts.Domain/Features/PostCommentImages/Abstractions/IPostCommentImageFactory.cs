namespace InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;

public interface IPostCommentImageFactory
{
	public ICollection<PostCommentImage> CreateRange(PostCommentId id, ICollection<Url> urls);
}
