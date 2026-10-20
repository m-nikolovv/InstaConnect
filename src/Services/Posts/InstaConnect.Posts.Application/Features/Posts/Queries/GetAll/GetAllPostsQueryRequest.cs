namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public record GetAllPostsQueryRequest(
	string UserName,
	string Title,
	string CurrentUserId,
	CommonSortOrder SortOrder,
	PostsSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllPostsQueryResponse>, ISortableQueryRequest<PostsSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
