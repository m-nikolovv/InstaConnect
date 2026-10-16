namespace InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

public record PostImageResponse(
	PostImageId Id,
	Url Url,
	DateTimeOffset CreatedAtUtc) : IEntityResponse;
