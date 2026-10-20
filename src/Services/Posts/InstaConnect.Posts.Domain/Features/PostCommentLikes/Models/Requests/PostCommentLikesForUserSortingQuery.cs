namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikesForUserSortingQuery(
	CommonSortOrder Order,
	PostCommentLikesForUserSortTerm Term) : ISortingQuery<PostCommentLikesForUserSortTerm>;
