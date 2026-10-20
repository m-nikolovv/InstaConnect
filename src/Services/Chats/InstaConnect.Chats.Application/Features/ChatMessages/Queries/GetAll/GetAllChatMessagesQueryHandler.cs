namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;

internal class GetAllChatMessagesQueryHandler : IQueryHandler<GetAllChatMessagesQueryRequest, GetAllChatMessagesQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IChatMessageQueryService _messageService;

	public GetAllChatMessagesQueryHandler(
		IApplicationMapper mapper,
		IChatMessageQueryService messageService)
	{
		_mapper = mapper;
		_messageService = messageService;
	}

	public async Task<GetAllChatMessagesQueryResponse> Handle(
		GetAllChatMessagesQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllChatMessagesQuery>(request);
		var serviceResponse = await _messageService.GetAllAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllChatMessagesQueryResponse>(serviceResponse);

		return response;
	}
}
