namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;

internal class UpdateChatMessageCommandHandler : ICommandHandler<UpdateChatMessageCommandRequest, UpdateChatMessageCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IChatMessageCommandService _messageService;

	public UpdateChatMessageCommandHandler(
		IApplicationMapper mapper,
		IChatMessageCommandService messageService)
	{
		_mapper = mapper;
		_messageService = messageService;
	}

	public async Task<UpdateChatMessageCommandResponse> Handle(UpdateChatMessageCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<UpdateChatMessageCommand>(request);
		var serviceResponse = await _messageService.UpdateAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<UpdateChatMessageCommandResponse>(serviceResponse);

		return response;
	}
}
