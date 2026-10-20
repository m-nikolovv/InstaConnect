using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;
using InstaConnect.Posts.Presentation.Features.PostCommentImages.Models.Responses;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Mappings;

internal class PostCommentPresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllPostCommentsApiRequest, GetAllPostCommentsQueryRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.UserName,
				src.CurrentUserId,
				src.SortOrder,
				src.SortTerm,
				src.Page,
				src.PageSize));

		config.NewConfig<GetAllPostCommentsQueryResponse, GetAllPostCommentsApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostCommentCollectionApiResponse>(config)));

		config.NewConfig<GetAllPostCommentsForUserApiRequest, GetAllPostCommentsForUserQueryRequest>()
			.ConstructUsing(src => new(
					src.UserId,
					src.CurrentUserId,
					src.SortOrder,
					src.SortTerm,
					src.Page,
					src.PageSize));

		config.NewConfig<GetAllPostCommentsForUserQueryResponse, GetAllPostCommentsForUserApiResponse>()
		   .ConstructUsing(src => new(src.Response.Adapt<PostCommentCollectionApiResponse>(config)));

		config.NewConfig<GetPostCommentByIdApiRequest, GetPostCommentByIdQueryRequest>()
			.ConstructUsing(src => new(src.Id,
									   src.CommentId,
									   src.CurrentUserId));

		config.NewConfig<GetPostCommentByIdQueryResponse, GetPostCommentByIdApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostCommentApiResponse>(config)));

		config.NewConfig<AddPostCommentApiRequest, AddPostCommentCommandRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.Form.Content,
				src.UserId,
				src.Form.Images));

		config.NewConfig<AddPostCommentCommandResponse, AddPostCommentApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostCommentIdApiResponse>(config)));

		config.NewConfig<UpdatePostCommentApiRequest, UpdatePostCommentCommandRequest>()
			.ConstructUsing(src => new(
									   src.Id,
									   src.CommentId,
									   src.UserId,
									   src.Body.Content));

		config.NewConfig<UpdatePostCommentCommandResponse, UpdatePostCommentApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<PostCommentIdApiResponse>(config)));

		config.NewConfig<DeletePostCommentApiRequest, DeletePostCommentCommandRequest>()
			.ConstructUsing(src => new(src.Id,
									   src.CommentId,
									   src.UserId));

		config.NewConfig<PostCommentQueryResponse, PostCommentApiResponse>()
			.ConstructUsing(src => new(
				src.Id,
				src.CommentId,
				src.UserId,
				src.Content,
				src.Summary,
				src.User.Adapt<UserApiResponse>(config),
				src.Post.Adapt<PostApiResponse>(config),
				src.PostCommentImages.Adapt<ICollection<PostCommentImageApiResponse>>(config),
				src.IsLikedByCurrentUser,
				src.CreatedAtUtc,
				src.UpdatedAtUtc));

		config.NewConfig<PostCommentCollectionQueryResponse, PostCommentCollectionApiResponse>()
			.ConstructUsing(src => new(
				  src.Post.Adapt<PostApiResponse>(config),
				  src.User.Adapt<UserApiResponse>(config),
				  src.PostComments.Adapt<ICollection<PostCommentApiResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));

		config.NewConfig<PostCommentIdCommandResponse, PostCommentIdApiResponse>()
			.ConstructUsing(src => new(
				src.Id,
				src.CommentId));
	}
}
