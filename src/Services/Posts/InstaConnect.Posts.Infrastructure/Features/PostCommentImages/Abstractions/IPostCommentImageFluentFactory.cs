using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

public interface IPostCommentImageFluentFactory
{
	public IPostCommentImageFluent Create(IAggregateFluent<PostCommentImage> fluent);
}
