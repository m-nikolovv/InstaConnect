using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Features.PostLikes.Mappings;

internal class PostLikeApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllPostLikesQueryRequest, GetAllPostLikesQuery>()
			.ConstructUsing(src => new(
				new(
					new(src.Id),
					new(src.UserName)),
				new(
					src.SortOrder,
					src.SortTerm),
				new(
					src.Page,
					src.PageSize),
				new(
					new(src.CurrentUserId))));

		config.NewConfig<PostLikeCollectionResponse, GetAllPostLikesQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostLikeCollectionQueryResponse>(config)));

		config.NewConfig<GetAllPostLikesForUserQueryRequest, GetAllPostLikesForUserQuery>()
			.ConstructUsing(src => new(
				new(new(src.UserId)),
				new(
					src.SortOrder,
					src.SortTerm),
				new(
					src.Page,
					src.PageSize),
				new(
					new(src.CurrentUserId))));

		config.NewConfig<PostLikeCollectionResponse, GetAllPostLikesForUserQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostLikeCollectionQueryResponse>(config)));

		config.NewConfig<GetPostLikeByIdQueryRequest, GetPostLikeByIdQuery>()
			.ConstructUsing(src => new(
									   new(
										   new(src.Id),
										   new(src.UserId)),
									   new(
										   new(src.CurrentUserId))));

		config.NewConfig<PostLikeResponse, GetPostLikeByIdQueryResponse>()
			.ConstructUsing(src => new(
				src.Adapt<PostLikeQueryResponse>(config)));

		config.NewConfig<PostLikeResponse, PostLikeQueryResponse>()
			.ConstructUsing(src => new(
				src.Id.Id.Id,
				src.Id.UserId.Id,
				src.User.Adapt<UserQueryResponse>(config),
				src.Post.Adapt<PostQueryResponse>(config),
				src.CreatedAtUtc));

		config.NewConfig<PostLikeCollectionResponse, PostLikeCollectionQueryResponse>()
			.ConstructUsing(src => new(
				  src.Post.Adapt<PostQueryResponse>(config),
				  src.User.Adapt<UserQueryResponse>(config),
				  src.PostLikes.Adapt<ICollection<PostLikeQueryResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));

		config.NewConfig<AddPostLikeCommandRequest, AddPostLikeCommand>()
			.ConstructUsing(src => new(
									   new(src.Id),
									   new(src.UserId)));

		config.NewConfig<PostLikeId, AddPostLikeCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<PostLikeIdCommandResponse>(config)));

		config.NewConfig<DeletePostLikeCommandRequest, DeletePostLikeCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(src.Id),
										   new(src.UserId))));

		config.NewConfig<PostLikeId, PostLikeIdCommandResponse>()
			.ConstructUsing(src => new(
				src.Id.Id,
				src.UserId.Id));
	}
}
