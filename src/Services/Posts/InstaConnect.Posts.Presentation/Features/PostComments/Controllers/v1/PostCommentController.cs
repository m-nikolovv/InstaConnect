using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostComments.Utilities;

using Microsoft.AspNetCore.Authorization;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Controllers.v1;

[ApiController]
[ApiVersion(PostCommentRoutes.Version1)]
[Route(PostCommentRoutes.Resource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class PostCommentController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public PostCommentController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetAllPostCommentsApiResponse>> GetAllAsync(
		GetAllPostCommentsApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllPostCommentsQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetAllPostCommentsApiResponse>(queryResponse);

		return Ok(response);
	}

	// GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpGet(PostCommentRoutes.Id)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetPostCommentByIdApiResponse>> GetByIdAsync(
		GetPostCommentByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetPostCommentByIdQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetPostCommentByIdApiResponse>(queryResponse);

		return Ok(response);
	}

	// POST: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments
	[HttpPost]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<AddPostCommentApiResponse>> AddAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<AddPostCommentCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<AddPostCommentApiResponse>(commandResponse);

		return Ok(response);
	}

	// PUT: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpPut(PostCommentRoutes.Id)]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<UpdatePostCommentApiResponse>> UpdateAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<UpdatePostCommentCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<UpdatePostCommentApiResponse>(commandResponse);

		return Ok(response);
	}

	// DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpDelete(PostCommentRoutes.Id)]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult> DeleteAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<DeletePostCommentCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}
}
