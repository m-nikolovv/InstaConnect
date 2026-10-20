using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;
using InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;
using InstaConnect.Chats.Presentation.Features.Chats.Utilities;

using Microsoft.AspNetCore.Authorization;

namespace InstaConnect.Chats.Presentation.Features.Chats.Controllers.v1;

[Authorize]
[ApiController]
[ApiVersion(ChatRoutes.Version1)]
[Route(ChatRoutes.Resource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class ChatController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public ChatController(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	// GET: api/participants/5f0f2dd0-e957-4d72-8141-767a36fc6e95/chats
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetAllChatsApiResponse>> GetAllAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllChatsQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetAllChatsApiResponse>(queryResponse);

		return Ok(response);
	}

	// GET: api/participants/current/chats/5f0f2dd0-e957-4d72-8141-767a36fc6e95
	[HttpGet(ChatRoutes.Id)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetChatByIdApiResponse>> GetByIdAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetChatByIdQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetChatByIdApiResponse>(queryResponse);

		return Ok(response);
	}

	// POST: api/participants/current/chats
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<AddChatApiResponse>> AddAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var commandRequest = _mapper.Map<AddChatCommandRequest>(request);
		var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
		var response = _mapper.Map<AddChatApiResponse>(commandResponse);

		return Ok(response);
	}
}
