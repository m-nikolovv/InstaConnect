namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowIncluderFactory
	: IIncluderFactory<FollowsIncludeType, FollowsDestinationType, FollowsIncludeDescriptor, IFollowIncluder, Follow>;

