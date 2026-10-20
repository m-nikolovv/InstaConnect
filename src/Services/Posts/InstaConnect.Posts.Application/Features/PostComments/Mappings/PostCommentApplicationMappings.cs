using InstaConnect.Posts.Application.Features.PostCommentImages.Models;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Features.PostComments.Mappings;

internal class PostCommentApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllPostCommentsQueryRequest, GetAllPostCommentsQuery>()
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

		config.NewConfig<PostCommentCollectionResponse, GetAllPostCommentsQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostCommentCollectionQueryResponse>(config)));

		config.NewConfig<GetAllPostCommentsForUserQueryRequest, GetAllPostCommentsForUserQuery>()
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

		config.NewConfig<PostCommentCollectionResponse, GetAllPostCommentsForUserQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostCommentCollectionQueryResponse>(config)));

		config.NewConfig<GetPostCommentByIdQueryRequest, GetPostCommentByIdQuery>()
			.ConstructUsing(src => new(
									   new(
										   new(src.Id),
										   src.CommentId),
									   new(
										   new(src.CurrentUserId))));

		config.NewConfig<PostCommentResponse, GetPostCommentByIdQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<PostCommentQueryResponse>(config)));

		config.NewConfig<PostCommentResponse, PostCommentQueryResponse>()
			.ConstructUsing(src => new(
				src.Id.Id.Id,
				src.Id.CommentId,
				src.UserId.Id,
				src.Content,
				src.Summary.Value,
				src.User.Adapt<UserQueryResponse>(config),
				src.Post.Adapt<PostQueryResponse>(config),
				src.PostCommentImages.Adapt<ICollection<PostCommentImageQueryResponse>>(config),
				src.IsLikedByCurrentUser,
				src.CreatedAtUtc,
				src.UpdatedAtUtc));

		config.NewConfig<PostCommentCollectionResponse, PostCommentCollectionQueryResponse>()
			.ConstructUsing(src => new(
				  src.Post.Adapt<PostQueryResponse>(config),
				  src.User.Adapt<UserQueryResponse>(config),
				  src.PostComments.Adapt<ICollection<PostCommentQueryResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));

		config.NewConfig<AddPostCommentCommandRequest, AddPostCommentCommand>()
			.ConstructUsing(src => new(
				new(src.Id),
				src.Content,
				new(src.UserId),
				src.Images));

		config.NewConfig<PostCommentId, AddPostCommentCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<PostCommentIdCommandResponse>(config)));

		config.NewConfig<UpdatePostCommentCommandRequest, UpdatePostCommentCommand>()
			.ConstructUsing(src => new(
				new(
					new(src.Id),
					src.CommentId),
				new(src.UserId),
				src.Content));

		config.NewConfig<PostCommentId, UpdatePostCommentCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<PostCommentIdCommandResponse>(config)));

		config.NewConfig<DeletePostCommentCommandRequest, DeletePostCommentCommand>()
			 .ConstructUsing(src => new(
				new(
					new(src.Id),
					src.CommentId),
				new(src.UserId)));

		config.NewConfig<PostCommentId, PostCommentIdCommandResponse>()
			.ConstructUsing(src => new(
				src.Id.Id,
				src.CommentId));
	}
}
