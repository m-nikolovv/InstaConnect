using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Mappings;

internal class PostLikePresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllPostLikesApiRequest, GetAllPostLikesQueryRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.UserName,
				src.CurrentUserId,
				src.SortOrder,
				src.SortTerm,
				src.Page,
				src.PageSize));

		config.NewConfig<GetAllPostLikesQueryResponse, GetAllPostLikesApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostLikeCollectionApiResponse>(config)));

		config.NewConfig<GetAllPostLikesForUserApiRequest, GetAllPostLikesForUserQueryRequest>()
			.ConstructUsing(src => new(
					src.UserId,
					src.CurrentUserId,
					src.SortOrder,
					src.SortTerm,
					src.Page,
					src.PageSize));

		config.NewConfig<GetAllPostLikesForUserQueryResponse, GetAllPostLikesForUserApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostLikeCollectionApiResponse>(config)));

		config.NewConfig<GetPostLikeByIdApiRequest, GetPostLikeByIdQueryRequest>()
			.ConstructUsing(src => new(src.Id,
									   src.UserId,
									   src.CurrentUserId));

		config.NewConfig<GetPostLikeByIdQueryResponse, GetPostLikeByIdApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostLikeApiResponse>(config)));

		config.NewConfig<AddPostLikeApiRequest, AddPostLikeCommandRequest>()
			.ConstructUsing(src => new(src.Id,
									   src.UserId));

		config.NewConfig<AddPostLikeCommandResponse, AddPostLikeApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostLikeIdApiResponse>(config)));

		config.NewConfig<DeletePostLikeApiRequest, DeletePostLikeCommandRequest>()
			.ConstructUsing(src => new(src.Id,
									   src.UserId));

		config.NewConfig<PostLikeQueryResponse, PostLikeApiResponse>()
			.ConstructUsing(src => new(
				src.Id,
				src.UserId,
				src.User.Adapt<UserApiResponse>(config),
				src.Post.Adapt<PostApiResponse>(config),
				src.CreatedAtUtc));

		config.NewConfig<PostLikeIdApiResponse, PostLikeIdCommandResponse>()
			.ConstructUsing(src => new(
				src.Id,
				src.UserId));

		config.NewConfig<PostLikeCollectionQueryResponse, PostLikeCollectionApiResponse>()
			.ConstructUsing(src => new(
				  src.Post.Adapt<PostApiResponse>(config),
				  src.User.Adapt<UserApiResponse>(config),
				  src.PostLikes.Adapt<ICollection<PostLikeApiResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));

		config.NewConfig<PostLikeIdCommandResponse, PostLikeIdApiResponse>()
			.ConstructUsing(src => new(
				src.Id,
				src.UserId));
	}
}
