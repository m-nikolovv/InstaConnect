namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowsForFollowingSortingQuery(
	CommonSortOrder Order,
	FollowsForFollowingSortTerm Term) : ISortingQuery<FollowsForFollowingSortTerm>;
