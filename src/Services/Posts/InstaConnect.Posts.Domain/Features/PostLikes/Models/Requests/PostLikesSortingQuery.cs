namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikesSortingQuery(
	CommonSortOrder Order,
	PostLikesSortTerm Term) : ISortingQuery<PostLikesSortTerm>;
