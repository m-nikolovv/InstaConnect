namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;

public record GetAllPostLikesForUserQueryRequest(
	string UserId,
	string CurrentUserId,
	CommonSortOrder SortOrder,
	PostLikesForUserSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllPostLikesForUserQueryResponse>, ISortableQueryRequest<PostLikesForUserSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
