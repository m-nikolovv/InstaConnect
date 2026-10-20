namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetPostCommentLikeByIdApiRequest(
	[FromRoute] string Id,
	[FromRoute] string CommentId,
	[FromRoute] string UserId,
	[UserIdFromClaim] string CurrentUserId) : ICurrentUserableApiRequest;
