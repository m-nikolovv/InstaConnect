namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public record GetAllPostCommentLikesQueryRequest(
	string Id,
	string CommentId,
	string UserName,
	string CurrentUserId,
	CommonSortOrder SortOrder,
	PostCommentLikesSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllPostCommentLikesQueryResponse>, ISortableQueryRequest<PostCommentLikesSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
