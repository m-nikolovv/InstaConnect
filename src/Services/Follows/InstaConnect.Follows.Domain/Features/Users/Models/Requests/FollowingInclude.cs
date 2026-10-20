namespace InstaConnect.Follows.Domain.Features.Users.Models.Requests;

public record FollowingInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
	: Include<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>(Descriptors);
