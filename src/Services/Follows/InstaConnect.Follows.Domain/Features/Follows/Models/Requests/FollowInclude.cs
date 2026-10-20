namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
	: Include<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>(Descriptors);
