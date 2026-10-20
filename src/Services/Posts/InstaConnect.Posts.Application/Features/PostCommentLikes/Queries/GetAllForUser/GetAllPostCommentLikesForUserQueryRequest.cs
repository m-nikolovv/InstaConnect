namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;

public record GetAllPostCommentLikesForUserQueryRequest(
	string UserId,
	string CurrentUserId,
	CommonSortOrder SortOrder,
	PostCommentLikesForUserSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllPostCommentLikesForUserQueryResponse>, ISortableQueryRequest<PostCommentLikesForUserSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
