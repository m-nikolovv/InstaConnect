namespace InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

public interface IUserIncluderFactory
	: IIncluderFactory<PostsIncludeType, PostsDestinationType, PostsIncludeDescriptor, IUserIncluder, User>;
