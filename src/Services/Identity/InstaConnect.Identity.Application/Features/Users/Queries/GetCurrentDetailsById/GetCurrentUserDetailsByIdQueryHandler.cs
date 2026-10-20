namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;

internal class GetCurrentUserDetailsByIdQueryHandler : IQueryHandler<GetCurrentUserDetailsByIdQueryRequest, GetCurrentUserDetailsByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserQueryService _service;

	public GetCurrentUserDetailsByIdQueryHandler(
		IApplicationMapper mapper,
		IUserQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetCurrentUserDetailsByIdQueryResponse> Handle(
		GetCurrentUserDetailsByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetUserByIdQuery>(request);
		var serviceResponse = await _service.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetCurrentUserDetailsByIdQueryResponse>(serviceResponse);

		return response;
	}
}
