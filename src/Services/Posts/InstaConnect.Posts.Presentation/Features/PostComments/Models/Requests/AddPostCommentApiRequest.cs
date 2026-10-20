using InstaConnect.Posts.Presentation.Features.PostComments.Models.Forms;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record AddPostCommentApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string UserId,
	[FromForm(Name = "")] AddPostCommentApiForm Form
);
