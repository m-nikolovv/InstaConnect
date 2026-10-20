namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikesPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
