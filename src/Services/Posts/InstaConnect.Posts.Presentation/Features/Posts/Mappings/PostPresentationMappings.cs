using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.Posts.Mappings;

internal class PostPresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllPostsApiRequest, GetAllPostsQueryRequest>()
			.ConstructUsing(src => new(
					src.UserName,
					src.Title,
					src.CurrentUserId,
					src.SortOrder,
					src.SortTerm,
					src.Page,
					src.PageSize));

		config.NewConfig<GetAllPostsQueryResponse, GetAllPostsApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostCollectionApiResponse>(config)));

		config.NewConfig<GetAllPostsForUserApiRequest, GetAllPostsForUserQueryRequest>()
			.ConstructUsing(src => new(
					src.UserId,
					src.CurrentUserId,
					src.Title,
					src.SortOrder,
					src.SortTerm,
					src.Page,
					src.PageSize));

		config.NewConfig<GetAllPostsForUserQueryResponse, GetAllPostsForUserApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostCollectionApiResponse>(config)));

		config.NewConfig<GetPostByIdApiRequest, GetPostByIdQueryRequest>()
			.ConstructUsing(src => new(src.Id, src.CurrentUserId));

		config.NewConfig<GetPostByIdQueryResponse, GetPostByIdApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostApiResponse>(config)));

		config.NewConfig<AddPostApiRequest, AddPostCommandRequest>()
			.ConstructUsing(src => new(
				src.UserId,
				src.Form.Title,
				src.Form.Content,
				src.Form.Images ?? new List<IFormFile>()));

		config.NewConfig<AddPostCommandResponse, AddPostApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostIdApiResponse>(config)));

		config.NewConfig<UpdatePostApiRequest, UpdatePostCommandRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.UserId,
				src.Body.Title,
				src.Body.Content));

		config.NewConfig<UpdatePostCommandResponse, UpdatePostApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostIdApiResponse>(config)));

		config.NewConfig<PostIdCommandResponse, PostIdApiResponse>()
			.ConstructUsing(src => new(src.Id));

		config.NewConfig<PostQueryResponse, PostApiResponse>()
			.ConstructUsing(src => new(
					src.Id,
					src.UserId,
					src.Title,
					src.Content,
					src.User.Adapt<UserApiResponse>(config),
					src.IsLikedByCurrentUser,
					src.CreatedAtUtc,
					src.UpdatedAtUtc));

		config.NewConfig<PostCollectionQueryResponse, PostCollectionApiResponse>()
			.ConstructUsing(src => new(
				  src.User.Adapt<UserApiResponse>(config),
				  src.Posts.Adapt<ICollection<PostApiResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));
	}
}
