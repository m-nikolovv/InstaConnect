using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Application.Features.Chats.Commands.Add;

internal class AddChatCommandHandler : ICommandHandler<AddChatCommandRequest, AddChatCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IChatCommandService _service;

	public AddChatCommandHandler(
		IApplicationMapper mapper,
		IChatCommandService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<AddChatCommandResponse> Handle(AddChatCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddChatCommand>(request);
		var serviceResponse = await _service.AddAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AddChatCommandResponse>(serviceResponse);

		return response;
	}
}
