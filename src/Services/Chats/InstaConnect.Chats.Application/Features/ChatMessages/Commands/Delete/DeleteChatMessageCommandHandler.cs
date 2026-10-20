namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;

internal class DeleteChatMessageCommandHandler : ICommandHandler<DeleteChatMessageCommandRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IChatMessageCommandService _messageService;

	public DeleteChatMessageCommandHandler(
		IApplicationMapper mapper,
		IChatMessageCommandService messageService)
	{
		_mapper = mapper;
		_messageService = messageService;
	}

	public async Task Handle(
		DeleteChatMessageCommandRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<DeleteChatMessageCommand>(request);
		await _messageService.DeleteAsync(serviceRequest, cancellationToken);
	}
}
