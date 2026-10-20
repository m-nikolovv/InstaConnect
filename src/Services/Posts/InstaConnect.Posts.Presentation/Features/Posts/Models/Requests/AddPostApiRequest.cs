using InstaConnect.Posts.Presentation.Features.Posts.Models.Forms;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record AddPostApiRequest(
	[UserIdFromClaim] string UserId,
	[FromForm(Name = "")] AddPostApiForm Form
);
