namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikeInclude(ICollection<PostsIncludeDescriptor> Descriptors)
	: Include<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>(Descriptors);
