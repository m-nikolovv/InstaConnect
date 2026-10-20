namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikesSortingQuery(
	CommonSortOrder Order,
	PostCommentLikesSortTerm Term) : ISortingQuery<PostCommentLikesSortTerm>;
