namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UsersSortingQuery(
	CommonSortOrder Order,
	UsersSortTerm Term) : ISortingQuery<UsersSortTerm>;
