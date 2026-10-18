using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

internal class PostAnalyzeResponseFactory : IPostAnalyzeResponseFactory
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
		DateTimeOffset updatedAtUtc)
	{
		return new(
			id,
			userId,
			title,
			content,
			user,
			postImages,
			isLikedByCurrentUser,
			summary,
			createdAtUtc,
			updatedAtUtc);
	}
}
