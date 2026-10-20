namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record GetAllPostCommentsQuery(
	PostCommentsFilterQuery Filter,
	PostCommentsSortingQuery Sorting,
	PostCommentsPaginationQuery Pagination,
	CurrentUserQuery CurrentUser)
	: ISortableQuery<PostCommentsSortingQuery, PostCommentsSortTerm>, IPaginatableQuery<PostCommentsPaginationQuery>, ICurrentUserableQuery;
