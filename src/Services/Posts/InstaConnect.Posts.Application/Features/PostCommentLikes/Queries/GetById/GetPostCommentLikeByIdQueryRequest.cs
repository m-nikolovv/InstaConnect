namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

public record GetPostCommentLikeByIdQueryRequest(
	string Id,
	string CommentId,
	string UserId,
	string CurrentUserId) : IQueryRequest<GetPostCommentLikeByIdQueryResponse>, ICurrentUserableQueryRequest;
