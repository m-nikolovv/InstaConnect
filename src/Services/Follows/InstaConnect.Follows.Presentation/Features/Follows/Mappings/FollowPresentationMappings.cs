using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollowing;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;
using InstaConnect.Follows.Presentation.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Presentation.Features.Follows.Mappings;

internal class FollowPresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllFollowsApiRequest, GetAllFollowsQueryRequest>()
			.ConstructUsing(src => new(
				src.FollowerId,
				src.FollowingName,
				src.CurrentUserId,
				src.SortOrder,
				src.SortTerm,
				src.Page,
				src.PageSize));

		config.NewConfig<GetAllFollowsQueryResponse, GetAllFollowsApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<FollowCollectionApiResponse>(config)));

		config.NewConfig<GetAllFollowsForFollowingApiRequest, GetAllFollowsForFollowingQueryRequest>()
			.ConstructUsing(src => new(
				src.FollowingId,
				src.FollowerName,
				src.CurrentUserId,
				src.SortOrder,
				src.SortTerm,
				src.Page,
				src.PageSize));

		config.NewConfig<GetAllFollowsForFollowingQueryResponse, GetAllFollowsForFollowingApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<FollowCollectionApiResponse>(config)));

		config.NewConfig<GetFollowByIdApiRequest, GetFollowByIdQueryRequest>()
			.ConstructUsing(src => new(src.FollowerId,
									   src.FollowingId,
									   src.CurrentUserId));

		config.NewConfig<GetFollowByIdQueryResponse, GetFollowByIdApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<FollowApiResponse>(config)));

		config.NewConfig<AddFollowApiRequest, AddFollowCommandRequest>()
			.ConstructUsing(src => new(src.FollowerId,
									   src.Body.FollowingId));

		config.NewConfig<AddFollowCommandResponse, AddFollowApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<FollowIdApiResponse>(config)));

		config.NewConfig<DeleteFollowApiRequest, DeleteFollowCommandRequest>()
			.ConstructUsing(src => new(src.FollowerId,
									   src.FollowingId));

		config.NewConfig<FollowIdCommandResponse, FollowIdApiResponse>()
			.ConstructUsing(src => new(
				src.FollowerId,
				src.FollowingId));

		config.NewConfig<FollowQueryResponse, FollowApiResponse>()
			.ConstructUsing(src => new(
				src.FollowerId,
				src.FollowingId,
				src.Follower.Adapt<UserApiResponse>(config),
				src.Following.Adapt<UserApiResponse>(config),
				src.IsFollowedByCurrentUser,
				src.CreatedAtUtc));

		config.NewConfig<FollowCollectionQueryResponse, FollowCollectionApiResponse>()
			.ConstructUsing(src => new(
				  src.Follower.Adapt<UserApiResponse>(config),
				  src.Following.Adapt<UserApiResponse>(config),
				  src.Follows.Adapt<ICollection<FollowApiResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));
	}
}
