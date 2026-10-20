namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record GetAllPostCommentsForUserQuery(
	PostCommentsForUserFilterQuery Filter,
	PostCommentsForUserSortingQuery Sorting,
	PostCommentsPaginationQuery Pagination,
	CurrentUserQuery CurrentUser)
	: ISortableQuery<PostCommentsForUserSortingQuery, PostCommentsForUserSortTerm>, IPaginatableQuery<PostCommentsPaginationQuery>, ICurrentUserableQuery;
