namespace InstaConnect.Follows.Domain.Features.Users.Models.Requests;

public record FollowerInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
	: Include<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>(Descriptors);
