namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostInclude(ICollection<PostsIncludeDescriptor> Descriptors)
	: Include<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>(Descriptors);
