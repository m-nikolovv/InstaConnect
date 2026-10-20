using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowsSortingQuery(
	CommonSortOrder Order,
	FollowsSortTerm Term) : ISortingQuery<FollowsSortTerm>;
