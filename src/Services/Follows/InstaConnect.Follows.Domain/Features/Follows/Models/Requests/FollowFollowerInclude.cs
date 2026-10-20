namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowFollowerInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
	: Include<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>(Descriptors);
