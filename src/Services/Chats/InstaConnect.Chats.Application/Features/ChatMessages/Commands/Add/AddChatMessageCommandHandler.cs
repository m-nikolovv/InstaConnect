namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;

internal class AddChatMessageCommandHandler : ICommandHandler<AddChatMessageCommandRequest, AddChatMessageCommandResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IChatMessageCommandService _messageService;

	public AddChatMessageCommandHandler(
		IApplicationMapper mapper,
		IChatMessageCommandService messageService)
	{
		_mapper = mapper;
		_messageService = messageService;
	}

	public async Task<AddChatMessageCommandResponse> Handle(AddChatMessageCommandRequest request, CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AddChatMessageCommand>(request);
		var chatMessage = await _messageService.AddAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AddChatMessageCommandResponse>(chatMessage);

		return response;
	}
}
