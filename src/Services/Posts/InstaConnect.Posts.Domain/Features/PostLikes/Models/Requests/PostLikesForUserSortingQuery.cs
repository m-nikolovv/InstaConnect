namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikesForUserSortingQuery(
	CommonSortOrder Order,
	PostLikesForUserSortTerm Term) : ISortingQuery<PostLikesForUserSortTerm>;
