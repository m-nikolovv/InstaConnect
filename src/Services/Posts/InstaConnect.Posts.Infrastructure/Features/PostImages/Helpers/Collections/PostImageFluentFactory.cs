using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Collections;

internal class PostImageFluentFactory : IPostImageFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public PostImageFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IPostImageFluent Create(IAggregateFluent<PostImage> fluent)
	{
		return new PostImageFluent(_fluentHandlerFactory.Create<PostImage, PostImageId>(fluent));
	}
}
