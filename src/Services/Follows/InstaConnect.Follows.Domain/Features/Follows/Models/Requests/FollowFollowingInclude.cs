namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowFollowingInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
	: Include<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>(Descriptors);
