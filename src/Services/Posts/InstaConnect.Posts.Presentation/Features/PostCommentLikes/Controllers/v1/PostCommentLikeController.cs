using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Utilities;

using Microsoft.AspNetCore.Authorization;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;

[ApiController]
[ApiVersion(PostCommentLikeRoutes.Version1)]
[Route(PostCommentLikeRoutes.Resource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class PostCommentLikeController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public PostCommentLikeController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetAllPostCommentLikesApiResponse>> GetAllAsync(
		GetAllPostCommentLikesApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllPostCommentLikesQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetAllPostCommentLikesApiResponse>(queryResponse);

		return Ok(response);
	}

	// GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpGet(PostCommentLikeRoutes.Id)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetPostCommentLikeByIdApiResponse>> GetByIdAsync(
		GetPostCommentLikeByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetPostCommentLikeByIdQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetPostCommentLikeByIdApiResponse>(queryResponse);

		return Ok(response);
	}

	// POST: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes/current
	[HttpPost]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<AddPostCommentLikeApiResponse>> AddAsync(
		AddPostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<AddPostCommentLikeCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<AddPostCommentLikeApiResponse>(commandResponse);

		return Ok(response);
	}

	// DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes/current
	[HttpDelete(PostCommentLikeRoutes.Current)]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult> DeleteAsync(
		DeletePostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<DeletePostCommentLikeCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}
}
