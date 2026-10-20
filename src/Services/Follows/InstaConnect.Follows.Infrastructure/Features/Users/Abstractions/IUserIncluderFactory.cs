namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

public interface IUserIncluderFactory
	: IIncluderFactory<FollowsIncludeType, FollowsDestinationType, FollowsIncludeDescriptor, IUserIncluder, User>;
