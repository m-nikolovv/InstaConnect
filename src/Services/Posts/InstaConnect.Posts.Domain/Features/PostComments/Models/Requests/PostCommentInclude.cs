namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentInclude(ICollection<PostsIncludeDescriptor> Descriptors)
	: Include<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>(Descriptors);
