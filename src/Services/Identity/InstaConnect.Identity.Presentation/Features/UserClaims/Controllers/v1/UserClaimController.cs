using InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;
using InstaConnect.Identity.Application.Features.UserClaims.Commands.Delete;
using InstaConnect.Identity.Application.Features.UserClaims.Queries.GetAll;
using InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Presentation.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Presentation.Features.UserClaims.Utilities;

using Microsoft.AspNetCore.Authorization;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Controllers.v1;

[ApiController]
[ApiVersion(UserClaimRoutes.Version1)]
[Route(UserClaimRoutes.Resource)]
[Authorize(AuthorizationPolicies.Admin)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class UserClaimController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public UserClaimController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/claims
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<GetAllUserClaimsApiResponse>> GetAllAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllUserClaimsQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);

		var response = _mapper.Map<GetAllUserClaimsApiResponse>(queryResponse);

		return Ok(response);
	}

	// POST: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/claims
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<AddUserClaimApiResponse>> AddAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<AddUserClaimCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<AddUserClaimApiResponse>(commandResponse);

		return Ok(response);
	}

	// DELETE: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/claims/admin
	[HttpDelete(UserClaimRoutes.Id)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult> DeleteAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<DeleteUserClaimCommandRequest>(request);
		await _sender.SendAsync(commandRequest, cancellationToken);

		return NoContent();
	}
}
