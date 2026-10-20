namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

internal class GetFollowByIdQueryHandler : IQueryHandler<GetFollowByIdQueryRequest, GetFollowByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IFollowQueryService _service;

	public GetFollowByIdQueryHandler(
		IApplicationMapper mapper,
		IFollowQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetFollowByIdQueryResponse> Handle(
		GetFollowByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetFollowByIdQuery>(request);
		var serviceResponse = await _service.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetFollowByIdQueryResponse>(serviceResponse);

		return response;
	}
}
