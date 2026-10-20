namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesQuery(
	PostCommentLikesFilterQuery Filter,
	PostCommentLikesSortingQuery Sorting,
	PostCommentLikesPaginationQuery Pagination,
	CurrentUserQuery CurrentUser)
	: ISortableQuery<PostCommentLikesSortingQuery, PostCommentLikesSortTerm>, IPaginatableQuery<PostCommentLikesPaginationQuery>, ICurrentUserableQuery;
