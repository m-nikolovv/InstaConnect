namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikesPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
