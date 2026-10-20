using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollowing;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

namespace InstaConnect.Follows.Application.Features.Follows.Mappings;

public class FollowApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllFollowsQueryRequest, GetAllFollowsQuery>()
			.ConstructUsing(src => new(
				new(
					new(src.FollowerId),
					new(src.FollowingName)),
				new(
					src.SortOrder,
					src.SortTerm),
				new(
					src.Page,
					src.PageSize),
				new(
					new(src.CurrentUserId))));

		config.NewConfig<FollowCollectionResponse, GetAllFollowsQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<FollowCollectionQueryResponse>(config)));

		config.NewConfig<GetAllFollowsForFollowingQueryRequest, GetAllFollowsForFollowingQuery>()
			.ConstructUsing(src => new(
				new(
					new(src.FollowingId),
					new(src.FollowerName)),
				new(
					src.SortOrder,
					src.SortTerm),
				new(
					src.Page,
					src.PageSize),
				new(
					new(src.CurrentUserId))));

		config.NewConfig<FollowCollectionResponse, GetAllFollowsForFollowingQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<FollowCollectionQueryResponse>(config)));

		config.NewConfig<GetFollowByIdQueryRequest, GetFollowByIdQuery>()
			.ConstructUsing(src => new(
									   new(
										   new(src.FollowerId),
										   new(src.FollowingId)),
									   new(
										   new(src.CurrentUserId))));

		config.NewConfig<FollowResponse, GetFollowByIdQueryResponse>()
			.ConstructUsing(src => new(
				src.Adapt<FollowQueryResponse>(config)));

		config.NewConfig<FollowResponse, FollowQueryResponse>()
			.ConstructUsing(src => new(
				src.Id.FollowerId.Id,
				src.Id.FollowingId.Id,
				src.Follower.Adapt<UserQueryResponse>(config),
				src.Following.Adapt<UserQueryResponse>(config),
				src.IsFollowedByCurrentUser,
				src.CreatedAtUtc));

		config.NewConfig<FollowCollectionResponse, FollowCollectionQueryResponse>()
			.ConstructUsing(src => new(
				  src.Follower.Adapt<UserQueryResponse>(config),
				  src.Following.Adapt<UserQueryResponse>(config),
				  src.Follows.Adapt<ICollection<FollowQueryResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));

		config.NewConfig<AddFollowCommandRequest, AddFollowCommand>()
			.ConstructUsing(src => new(
									   new(src.FollowerId),
									   new(src.FollowingId)));

		config.NewConfig<FollowId, AddFollowCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<FollowIdCommandResponse>(config)));

		config.NewConfig<DeleteFollowCommandRequest, DeleteFollowCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(src.FollowerId),
										   new(src.FollowingId))));

		config.NewConfig<FollowId, FollowIdCommandResponse>()
			.ConstructUsing(src => new(
				src.FollowerId.Id,
				src.FollowingId.Id));
	}
}
