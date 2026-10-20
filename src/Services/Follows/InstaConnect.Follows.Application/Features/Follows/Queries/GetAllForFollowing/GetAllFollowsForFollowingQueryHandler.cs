namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollowing;

internal class GetAllFollowsForFollowingQueryHandler : IQueryHandler<GetAllFollowsForFollowingQueryRequest, GetAllFollowsForFollowingQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IFollowQueryService _service;

	public GetAllFollowsForFollowingQueryHandler(
		IApplicationMapper mapper,
		IFollowQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetAllFollowsForFollowingQueryResponse> Handle(
		GetAllFollowsForFollowingQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllFollowsForFollowingQuery>(request);
		var serviceResponse = await _service.GetAllForFollowingAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllFollowsForFollowingQueryResponse>(serviceResponse);

		return response;
	}
}
