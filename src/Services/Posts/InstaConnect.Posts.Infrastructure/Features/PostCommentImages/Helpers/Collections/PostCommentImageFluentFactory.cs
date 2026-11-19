using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Collections;

internal class PostCommentImageFluentFactory : IPostCommentImageFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public PostCommentImageFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IPostCommentImageFluent Create(IAggregateFluent<PostCommentImage> fluent)
	{
		return new PostCommentImageFluent(_fluentHandlerFactory.Create<PostCommentImage, PostCommentImageId>(fluent));
	}
}
