using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Presentation.Features.PostLikes.Utilities;

using Microsoft.AspNetCore.Authorization;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;

[ApiController]
[ApiVersion(PostLikeRoutes.Version1)]
[Route(PostLikeRoutes.Resource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class PostLikeController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public PostLikeController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetAllPostLikesApiResponse>> GetAllAsync(
		GetAllPostLikesApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllPostLikesQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetAllPostLikesApiResponse>(queryResponse);

		return Ok(response);
	}

	// GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpGet(PostLikeRoutes.Id)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetPostLikeByIdApiResponse>> GetByIdAsync(
		GetPostLikeByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetPostLikeByIdQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetPostLikeByIdApiResponse>(queryResponse);

		return Ok(response);
	}

	// POST: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes
	[HttpPost]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<AddPostLikeApiResponse>> AddAsync(
		AddPostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<AddPostLikeCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<AddPostLikeApiResponse>(commandResponse);

		return Ok(response);
	}

	// DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes/current
	[HttpDelete(PostLikeRoutes.Current)]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult> DeleteAsync(
		DeletePostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<DeletePostLikeCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}
}
