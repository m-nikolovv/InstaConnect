using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;

[ApiController]
[ApiVersion(PostRoutes.Version1)]
[Route(PostRoutes.Resource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class PostController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public PostController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// GET: api/posts
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetAllPostsApiResponse>> GetAllAsync(
		GetAllPostsApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllPostsQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetAllPostsApiResponse>(queryResponse);

		return Ok(response);
	}

	// GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpGet(PostRoutes.Id)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetPostByIdApiResponse>> GetByIdAsync(
		GetPostByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetPostByIdQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetPostByIdApiResponse>(queryResponse);

		return Ok(response);
	}

	// POST: api/posts
	[HttpPost]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<AddPostApiResponse>> AddAsync(
		AddPostApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<AddPostCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<AddPostApiResponse>(commandResponse);

		return Ok(response);
	}

	// PUT: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpPut(PostRoutes.Id)]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<UpdatePostApiResponse>> UpdateAsync(
		UpdatePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<UpdatePostCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<UpdatePostApiResponse>(commandResponse);

		return Ok(response);
	}

	//DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpDelete(PostRoutes.Id)]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult> DeleteAsync(
		DeletePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<DeletePostCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}
}
