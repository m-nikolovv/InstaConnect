namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

internal class GetAllFollowsQueryHandler : IQueryHandler<GetAllFollowsQueryRequest, GetAllFollowsQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IFollowQueryService _service;

	public GetAllFollowsQueryHandler(
		IApplicationMapper mapper,
		IFollowQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetAllFollowsQueryResponse> Handle(
		GetAllFollowsQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllFollowsQuery>(request);
		var serviceResponse = await _service.GetAllAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllFollowsQueryResponse>(serviceResponse);

		return response;
	}
}
