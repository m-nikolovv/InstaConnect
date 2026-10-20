using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

internal class GetChatByIdQueryHandler : IQueryHandler<GetChatByIdQueryRequest, GetChatByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IChatQueryService _service;

	public GetChatByIdQueryHandler(
		IApplicationMapper mapper,
		IChatQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetChatByIdQueryResponse> Handle(
		GetChatByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetChatByIdQuery>(request);
		var serviceResponse = await _service.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetChatByIdQueryResponse>(serviceResponse);

		return response;
	}
}
