using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;

[ApiController]
[ApiVersion(PostRoutes.Version1)]
[Route(PostRoutes.UserResource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class UserPostController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public UserPostController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/posts
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetAllPostsForUserApiResponse>> GetAllAsync(
		GetAllPostsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllPostsForUserQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetAllPostsForUserApiResponse>(queryResponse);

		return Ok(response);
	}
}
