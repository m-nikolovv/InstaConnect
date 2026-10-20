namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public record GetAllPostCommentsQueryRequest(
	string Id,
	string UserName,
	string CurrentUserId,
	CommonSortOrder SortOrder,
	PostCommentsSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllPostCommentsQueryResponse>, ISortableQueryRequest<PostCommentsSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
