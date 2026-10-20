using InstaConnect.Posts.Events.Features.PostImages;

namespace InstaConnect.Posts.Events.Features.Posts;

public record PostEventRequest(
		string Id,
		string UserId,
		string Title,
		string Content,
		string Summary,
		UserEventRequest User,
		ICollection<PostImageEventRequest> PostImages,
		DateTimeOffset CreatedAtUtc,
		DateTimeOffset UpdatedAtUtc);
