namespace InstaConnect.Identity.Application.Features.Users.Queries.GetById;

internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserQueryService _service;

	public GetUserByIdQueryHandler(
		IApplicationMapper mapper,
		IUserQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetUserByIdQueryResponse> Handle(
		GetUserByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetUserByIdQuery>(request);
		var serviceResponse = await _service.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetUserByIdQueryResponse>(serviceResponse);

		return response;
	}
}
