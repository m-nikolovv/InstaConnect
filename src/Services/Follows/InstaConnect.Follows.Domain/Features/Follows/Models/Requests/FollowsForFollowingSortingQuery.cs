using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowsForFollowingSortingQuery(
	CommonSortOrder Order,
	FollowsForFollowingSortTerm Term) : ISortingQuery<FollowsForFollowingSortTerm>;
