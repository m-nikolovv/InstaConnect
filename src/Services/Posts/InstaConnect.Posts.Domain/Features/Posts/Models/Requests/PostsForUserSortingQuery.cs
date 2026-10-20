namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostsForUserSortingQuery(
	CommonSortOrder Order,
	PostsForUserSortTerm Term) : ISortingQuery<PostsForUserSortTerm>;
