namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record GetAllPostLikesForUserQuery(
	PostLikesForUserFilterQuery Filter,
	PostLikesForUserSortingQuery Sorting,
	PostLikesPaginationQuery Pagination,
	CurrentUserQuery CurrentUser)
	: ISortableQuery<PostLikesForUserSortingQuery, PostLikesForUserSortTerm>, IPaginatableQuery<PostLikesPaginationQuery>, ICurrentUserableQuery;
