namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

public record GetAllPostLikesQueryRequest(
	string Id,
	string UserName,
	string CurrentUserId,
	CommonSortOrder SortOrder,
	PostLikesSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllPostLikesQueryResponse>, ISortableQueryRequest<PostLikesSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
