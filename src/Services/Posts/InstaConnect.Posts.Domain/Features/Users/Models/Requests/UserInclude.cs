namespace InstaConnect.Posts.Domain.Features.Users.Models.Requests;

public record UserInclude(ICollection<PostsIncludeDescriptor> Descriptors)
	: Include<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>(Descriptors);
