using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

public interface IPostImageFluent : IMongoDbFluent<PostImage>
{
	public IPostImageFluent Match(PostImageId filter);

	public IPostImageFluent Match(IEnumerable<PostImageId> filter);
}
