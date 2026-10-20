using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;

[ApiController]
[ApiVersion(PostCommentLikeRoutes.Version1)]
[Route(PostCommentLikeRoutes.UserResource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class UserPostCommentLikeController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public UserPostCommentLikeController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/post-comment-likes
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetAllPostCommentLikesForUserApiResponse>> GetAllAsync(
		GetAllPostCommentLikesForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllPostCommentLikesForUserQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetAllPostCommentLikesForUserApiResponse>(queryResponse);

		return Ok(response);
	}
}
