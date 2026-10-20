namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostsSortingQuery(
	CommonSortOrder Order,
	PostsSortTerm Term) : ISortingQuery<PostsSortTerm>;
