namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetAllPostsQuery(
	PostsFilterQuery Filter,
	PostsSortingQuery Sorting,
	PostsPaginationQuery Pagination,
	CurrentUserQuery CurrentUser)
	: ISortableQuery<PostsSortingQuery, PostsSortTerm>, IPaginatableQuery<PostsPaginationQuery>, ICurrentUserableQuery;
