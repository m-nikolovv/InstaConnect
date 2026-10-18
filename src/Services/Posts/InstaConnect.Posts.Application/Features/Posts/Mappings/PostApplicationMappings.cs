using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.AnalyzeById;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

using Mapster;

namespace InstaConnect.Posts.Application.Features.Posts.Mappings;

internal class PostApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllPostsQueryRequest, GetAllPostsQuery>()
			.ConstructUsing(src => new(
				new(
					new(src.UserName),
					src.Title),
				new(
					src.SortOrder,
					src.SortTerm),
				new(
					src.Page,
					src.PageSize),
				new(
					new(src.CurrentUserId))));

		config.NewConfig<PostCollectionResponse, GetAllPostsQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostCollectionQueryResponse>(config)));

		config.NewConfig<GetAllPostsForUserQueryRequest, GetAllPostsForUserQuery>()
			.ConstructUsing(src => new(
				new(
					new(src.UserId),
					src.Title),
				new(
					src.SortOrder,
					src.SortTerm),
				new(
					src.Page,
					src.PageSize),
				new(
					new(src.CurrentUserId))));

		config.NewConfig<PostCollectionResponse, GetAllPostsForUserQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostCollectionQueryResponse>(config)));

		config.NewConfig<GetPostByIdQueryRequest, GetPostByIdQuery>()
			.ConstructUsing(src => new(
									   new(src.Id),
									   new(
										   new(src.CurrentUserId))));

		config.NewConfig<PostResponse, GetPostByIdQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostQueryResponse>(config)));

		config.NewConfig<AnalyzePostByIdQueryRequest, AnalyzePostByIdQuery>()
			.ConstructUsing(src => new(
									   new(src.Id),
									   new(
										   new(src.CurrentUserId))));

		config.NewConfig<PostAnalyzeResponse, AnalyzePostByIdQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostAnalyzeQueryResponse>(config)));

		config.NewConfig<PostCollectionResponse, PostCollectionQueryResponse>()
			.ConstructUsing(src => new(
				  src.User.Adapt<UserQueryResponse>(config),
				  src.Posts.Adapt<ICollection<PostQueryResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));

		config.NewConfig<PostResponse, PostQueryResponse>()
			.ConstructUsing(src => new(
					src.Id.Id,
					src.UserId.Id,
					src.Title,
					src.Content,
					src.User.Adapt<UserQueryResponse>(config),
					src.PostImages.Adapt<ICollection<PostImageQueryResponse>>(config),
					src.IsLikedByCurrentUser,
					src.CreatedAtUtc,
					src.UpdatedAtUtc));

		config.NewConfig<PostAnalyzeResponse, PostAnalyzeQueryResponse>()
			.ConstructUsing(src => new(
					src.Id.Id,
					src.UserId.Id,
					src.Title,
					src.Content,
					src.User.Adapt<UserQueryResponse>(config),
					src.PostImages.Adapt<ICollection<PostImageQueryResponse>>(config),
					src.IsLikedByCurrentUser,
					src.Summary,
					src.CreatedAtUtc,
					src.UpdatedAtUtc));

		config.NewConfig<AddPostCommandRequest, AddPostCommand>()
			.ConstructUsing(src => new(
				new(src.UserId),
				src.Title,
				src.Content,
				src.Images));

		config.NewConfig<PostId, AddPostCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<PostIdCommandResponse>(config)));

		config.NewConfig<UpdatePostCommandRequest, UpdatePostCommand>()
			.ConstructUsing(src => new(
				new(src.Id),
				new(src.UserId),
				src.Title,
				src.Content));

		config.NewConfig<PostId, UpdatePostCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<PostIdCommandResponse>(config)));

		config.NewConfig<DeletePostCommandRequest, DeletePostCommand>()
			.ConstructUsing(src => new(
				new(src.Id),
				new(src.UserId)));

		config.NewConfig<PostId, PostIdCommandResponse>()
			.ConstructUsing(src => new(src.Id));
	}
}
