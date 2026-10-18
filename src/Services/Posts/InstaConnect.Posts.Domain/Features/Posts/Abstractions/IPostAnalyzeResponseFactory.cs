using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostAnalyzeResponseFactory
{
	public PostAnalyzeResponse Create(
		PostId id,
		UserId userId,
		string title,
		string content,
		UserResponse? user,
		ICollection<PostImageResponse> postImages,
		bool isLikedByCurrentUser,
		string summary,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc);
}
