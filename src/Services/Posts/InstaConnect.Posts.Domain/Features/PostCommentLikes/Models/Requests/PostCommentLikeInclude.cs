namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikeInclude(ICollection<PostsIncludeDescriptor> Descriptors)
	: Include<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>(Descriptors);
