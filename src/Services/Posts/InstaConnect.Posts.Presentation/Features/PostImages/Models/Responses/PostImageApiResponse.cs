namespace InstaConnect.Posts.Presentation.Features.PostImages.Models.Responses;

public record PostImageApiResponse(
	string Id,
	string ImageId,
	string Url,
	DateTimeOffset CreatedAtUtc);
