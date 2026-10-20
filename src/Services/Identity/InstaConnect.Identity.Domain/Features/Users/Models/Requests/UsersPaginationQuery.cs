namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UsersPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
