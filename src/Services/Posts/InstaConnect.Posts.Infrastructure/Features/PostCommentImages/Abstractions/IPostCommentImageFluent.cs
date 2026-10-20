using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

public interface IPostCommentImageFluent : IMongoDbFluent<PostCommentImage>
{
	public IPostCommentImageFluent Match(PostCommentImageId filter);

	public IPostCommentImageFluent Match(IEnumerable<PostCommentImageId> filter);
}
