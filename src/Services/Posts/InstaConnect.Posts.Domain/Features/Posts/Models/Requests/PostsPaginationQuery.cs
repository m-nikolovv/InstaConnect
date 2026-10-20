namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostsPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
