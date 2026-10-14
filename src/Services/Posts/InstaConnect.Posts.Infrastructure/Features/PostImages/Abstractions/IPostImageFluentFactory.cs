using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

public interface IPostImageFluentFactory
{
	public IPostImageFluent Create(IAggregateFluent<PostImage> fluent);
}
