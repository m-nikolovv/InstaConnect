using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Collections;

internal class PostImageFluentFactory : IPostImageFluentFactory
{
	public IPostImageFluent Create(IAggregateFluent<PostImage> fluent)
	{
		return new PostImageFluent(fluent);
	}
}
