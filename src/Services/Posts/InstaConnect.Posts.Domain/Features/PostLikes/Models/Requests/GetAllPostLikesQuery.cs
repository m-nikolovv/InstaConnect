namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record GetAllPostLikesQuery(
	PostLikesFilterQuery Filter,
	PostLikesSortingQuery Sorting,
	PostLikesPaginationQuery Pagination,
	CurrentUserQuery CurrentUser)
	: ISortableQuery<PostLikesSortingQuery, PostLikesSortTerm>, IPaginatableQuery<PostLikesPaginationQuery>, ICurrentUserableQuery;
