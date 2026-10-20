using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Delete;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;
using InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Utilities;

using Microsoft.AspNetCore.Authorization;

namespace InstaConnect.Identity.Presentation.Features.Users.Controllers.v1;

[ApiController]
[ApiVersion(UserRoutes.Version1)]
[Route(UserRoutes.Resource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class UserController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public UserController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// GET: api/users
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<GetAllUsersApiResponse>> GetAllAsync(
		GetAllUsersApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllUsersQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);

		var response = _mapper.Map<GetAllUsersApiResponse>(queryResponse);

		return Ok(response);
	}

	// GET: api/users/current/details
	[HttpGet(UserRoutes.CurrentDetails)]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetCurrentUserDetailsByIdApiResponse>> GetCurrentDetailsByIdAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetCurrentUserDetailsByIdQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);

		var response = _mapper.Map<GetCurrentUserDetailsByIdApiResponse>(queryResponse);

		return Ok(response);
	}

	// GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/details
	[HttpGet(UserRoutes.IdDetails)]
	[Authorize(AuthorizationPolicies.Admin)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetUserDetailsByIdApiResponse>> GetDetailsByIdAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetUserDetailsByIdQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);

		var response = _mapper.Map<GetUserDetailsByIdApiResponse>(queryResponse);

		return Ok(response);
	}

	// GET: api/users/current
	[HttpGet(UserRoutes.Current)]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetCurrentUserByIdApiResponse>> GetCurrentByIdAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetCurrentUserByIdQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);

		var response = _mapper.Map<GetCurrentUserByIdApiResponse>(queryResponse);

		return Ok(response);
	}

	// GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpGet(UserRoutes.Id)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetUserByIdApiResponse>> GetByIdAsync(
		GetUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetUserByIdQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);

		var response = _mapper.Map<GetUserByIdApiResponse>(queryResponse);

		return Ok(response);
	}

	// POST: api/users
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<AddUserApiResponse>> AddAsync(
		AddUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<AddUserCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<AddUserApiResponse>(commandResponse);

		return Ok(response);
	}

	// PUT: api/users/current
	[Authorize]
	[HttpPut(UserRoutes.Current)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<UpdateCurrentUserApiResponse>> UpdateCurrentAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<UpdateCurrentUserCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<UpdateCurrentUserApiResponse>(commandResponse);

		return Ok(response);
	}

	// DELETE: api/users/current
	[Authorize]
	[HttpDelete(UserRoutes.Current)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult> DeleteCurrentAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<DeleteCurrentUserCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}

	// DELETE: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[Authorize(AuthorizationPolicies.Admin)]
	[HttpDelete(UserRoutes.Id)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult> DeleteAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<DeleteUserCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}
}
