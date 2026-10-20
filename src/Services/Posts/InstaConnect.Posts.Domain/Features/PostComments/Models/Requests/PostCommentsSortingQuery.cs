namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentsSortingQuery(
	CommonSortOrder Order,
	PostCommentsSortTerm Term) : ISortingQuery<PostCommentsSortTerm>;
