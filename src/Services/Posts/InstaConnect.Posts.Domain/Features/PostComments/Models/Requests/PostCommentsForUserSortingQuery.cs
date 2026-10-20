namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentsForUserSortingQuery(
	CommonSortOrder Order,
	PostCommentsForUserSortTerm Term) : ISortingQuery<PostCommentsForUserSortTerm>;
