namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowsPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
