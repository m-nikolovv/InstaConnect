namespace InstaConnect.Posts.Application.Features.PostImages.Models;

public record PostImageQueryResponse(
	string Id,
	string ImageId,
	string Url,
	DateTimeOffset CreatedAtUtc);
