using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;

internal class GetAllChatsQueryHandler : IQueryHandler<GetAllChatsQueryRequest, GetAllChatsQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IChatQueryService _service;

	public GetAllChatsQueryHandler(
		IApplicationMapper mapper,
		IChatQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetAllChatsQueryResponse> Handle(
		GetAllChatsQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllChatsQuery>(request);
		var serviceResponse = await _service.GetAllAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllChatsQueryResponse>(serviceResponse);

		return response;
	}
}
