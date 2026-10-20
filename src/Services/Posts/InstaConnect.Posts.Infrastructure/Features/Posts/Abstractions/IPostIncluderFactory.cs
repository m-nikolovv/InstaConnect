namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostIncluderFactory
	: IIncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IPostIncluder, Post>;

