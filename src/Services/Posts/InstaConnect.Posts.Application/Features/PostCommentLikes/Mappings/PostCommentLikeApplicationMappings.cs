using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PostCommentLikeId, PostCommentLikeIdCommandResponse>()
			.ConstructUsing(src => new(
				src.CommentId.Id.Id,
				src.CommentId.CommentId,
				src.UserId.Id));

		config.NewConfig<PostCommentLikeResponse, PostCommentLikeQueryResponse>()
			.ConstructUsing(src => new(
				src.Id.CommentId.Id.Id,
				src.Id.CommentId.CommentId,
				src.Id.UserId.Id,
				src.User.Adapt<UserQueryResponse>(config),
				src.PostComment.Adapt<PostCommentQueryResponse>(config),
				src.CreatedAtUtc));

		config.NewConfig<PostCommentLikeCollectionResponse, PostCommentLikeCollectionQueryResponse>()
			.ConstructUsing(src => new(
				  src.PostComment.Adapt<PostCommentQueryResponse>(config),
				  src.User.Adapt<UserQueryResponse>(config),
				  src.PostCommentLikes.Adapt<ICollection<PostCommentLikeQueryResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));

		config.NewConfig<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQuery>()
			.ConstructUsing(src => new(
				new(
					new(
						new(src.Id),
						src.CommentId),
					new(src.UserName)),
				new(
					src.SortOrder,
					src.SortTerm),
				new(
					src.Page,
					src.PageSize),
				new(
					new(src.CurrentUserId))));

		config.NewConfig<PostCommentLikeCollectionResponse, GetAllPostCommentLikesQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostCommentLikeCollectionQueryResponse>(config)));

		config.NewConfig<GetAllPostCommentLikesForUserQueryRequest, GetAllPostCommentLikesForUserQuery>()
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

		config.NewConfig<PostCommentLikeCollectionResponse, GetAllPostCommentLikesForUserQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostCommentLikeCollectionQueryResponse>(config)));

		config.NewConfig<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQuery>()
			.ConstructUsing(src => new(
									   new(
										   new(
											   new(src.Id),
											   src.CommentId),
										   new(src.UserId)),
									   new(
										   new(src.CurrentUserId))));

		config.NewConfig<PostCommentLikeResponse, GetPostCommentLikeByIdQueryResponse>()
			.ConstructUsing(src => new(
				src.Adapt<PostCommentLikeQueryResponse>(config)));

		config.NewConfig<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(src.Id),
										   src.CommentId),
									   new(
										   new(
											   src.UserId))));

		config.NewConfig<PostCommentLikeId, AddPostCommentLikeCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<PostCommentLikeIdCommandResponse>(config)));

		config.NewConfig<DeletePostCommentLikeCommandRequest, DeletePostCommentLikeCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(
											   new(src.Id),
											   src.CommentId),
										   new(src.UserId))));
	}
}
