namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

internal class GetUserDetailsByIdQueryHandler : IQueryHandler<GetUserDetailsByIdQueryRequest, GetUserDetailsByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserQueryService _service;

	public GetUserDetailsByIdQueryHandler(
		IApplicationMapper mapper,
		IUserQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetUserDetailsByIdQueryResponse> Handle(
		GetUserDetailsByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetUserByIdQuery>(request);
		var serviceResponse = await _service.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetUserDetailsByIdQueryResponse>(serviceResponse);

		return response;
	}
}
