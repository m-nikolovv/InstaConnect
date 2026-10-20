namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record GetPostCommentByIdApiRequest(
	[FromRoute] string Id,
	[FromRoute] string CommentId,
	[UserIdFromClaim] string CurrentUserId) : ICurrentUserableApiRequest;
