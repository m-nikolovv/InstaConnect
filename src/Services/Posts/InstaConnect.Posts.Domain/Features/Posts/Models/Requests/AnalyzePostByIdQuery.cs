namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record AnalyzePostByIdQuery(
	PostId Id,
	CurrentUserQuery CurrentUser) : ICurrentUserableQuery;
