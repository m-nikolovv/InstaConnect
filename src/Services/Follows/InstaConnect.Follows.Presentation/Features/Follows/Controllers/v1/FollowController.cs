using Asp.Versioning;

using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;
using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;
using InstaConnect.Follows.Presentation.Features.Follows.Utilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;

[ApiController]
[ApiVersion(FollowRoutes.Version1)]
[Route(FollowRoutes.Resource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class FollowController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public FollowController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// GET: api/followers/5f0f2dd0-e957-4d72-8141-767a36fc6e95/follows
	[HttpGet(FollowRoutes.Default)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetAllFollowsApiResponse>> GetAllAsync(
		GetAllFollowsApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllFollowsQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetAllFollowsApiResponse>(queryResponse);

		return Ok(response);
	}

	// GET: api/followers/5f0f2dd0-e957-4d72-8141-767a36fc6e95/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpGet(FollowRoutes.Id)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetFollowByIdApiResponse>> GetByIdAsync(
		GetFollowByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetFollowByIdQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetFollowByIdApiResponse>(queryResponse);

		return Ok(response);
	}

	// POST: api/followers/current/follows
	[HttpPost(FollowRoutes.Current)]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<AddFollowApiResponse>> AddAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<AddFollowCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<AddFollowApiResponse>(commandResponse);

		return Ok(response);
	}

	// DELETE: api/followers/current/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpDelete(FollowRoutes.CurrentId)]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult> DeleteAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<DeleteFollowCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}
}
