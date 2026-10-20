namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;

internal class GetCurrentUserByIdQueryHandler : IQueryHandler<GetCurrentUserByIdQueryRequest, GetCurrentUserByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserQueryService _service;

	public GetCurrentUserByIdQueryHandler(
		IApplicationMapper mapper,
		IUserQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetCurrentUserByIdQueryResponse> Handle(
		GetCurrentUserByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetUserByIdQuery>(request);
		var serviceResponse = await _service.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetCurrentUserByIdQueryResponse>(serviceResponse);

		return response;
	}
}
