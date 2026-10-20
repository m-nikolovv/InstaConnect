using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Follows.Domain.Features.Follows.Mappings;

internal class FollowDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<Follow, FollowAddedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<FollowEventRequest>(config)));

		config.NewConfig<Follow, FollowDeletedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<FollowEventRequest>(config)));

		config.NewConfig<Follow, FollowEventRequest>()
			.ConstructUsing(src => new(
				src.Id.FollowerId.Id,
				src.Id.FollowingId.Id,
				src.Follower.Adapt<UserEventRequest>(config)!,
				src.Following.Adapt<UserEventRequest>(config)!,
				src.CreatedAtUtc));

		config.NewConfig<Follow, FollowNotificationRequest>()
			.ConstructUsing(src => new(
				src.Id.FollowerId.Id,
				src.Id.FollowingId.Id,
				src.Follower.Adapt<UserNotificationRequest>(config)!,
				src.Following.Adapt<UserNotificationRequest>(config)!,
				src.CreatedAtUtc));

		config.NewConfig<Follow, FollowAddedNotificationRequest>()
			.ConstructUsing(src => new(src.Adapt<FollowNotificationRequest>(config)));
	}
}
