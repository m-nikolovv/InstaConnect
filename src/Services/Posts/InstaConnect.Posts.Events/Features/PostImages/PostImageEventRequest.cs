namespace InstaConnect.Posts.Events.Features.PostImages;

public record PostImageEventRequest(
		string Id,
		string ImageId,
		string Url,
		DateTimeOffset CreatedAtUtc);
