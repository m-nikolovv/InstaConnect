namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

internal class GetChatMessageByIdQueryHandler : IQueryHandler<GetChatMessageByIdQueryRequest, GetChatMessageByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IChatMessageQueryService _messageService;

	public GetChatMessageByIdQueryHandler(
		IApplicationMapper mapper,
		IChatMessageQueryService messageService)
	{
		_mapper = mapper;
		_messageService = messageService;
	}

	public async Task<GetChatMessageByIdQueryResponse> Handle(
		GetChatMessageByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetChatMessageByIdQuery>(request);
		var serviceResponse = await _messageService.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetChatMessageByIdQueryResponse>(serviceResponse);

		return response;
	}
}
