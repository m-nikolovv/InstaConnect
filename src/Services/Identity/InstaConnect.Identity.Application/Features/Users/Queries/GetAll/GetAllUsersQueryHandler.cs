namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

internal class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserQueryService _service;

	public GetAllUsersQueryHandler(
		IApplicationMapper mapper,
		IUserQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetAllUsersQueryResponse> Handle(
		GetAllUsersQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllUsersQuery>(request);
		var serviceResponse = await _service.GetAllAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllUsersQueryResponse>(serviceResponse);

		return response;
	}
}
