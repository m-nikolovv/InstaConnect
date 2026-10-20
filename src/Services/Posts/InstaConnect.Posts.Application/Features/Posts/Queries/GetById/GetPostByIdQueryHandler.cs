namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

internal class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQueryRequest, GetPostByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostQueryService _service;

	public GetPostByIdQueryHandler(IApplicationMapper mapper, IPostQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetPostByIdQueryResponse> Handle(
		GetPostByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetPostByIdQuery>(request);
		var serviceResponse = await _service.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetPostByIdQueryResponse>(serviceResponse);

		return response;
	}
}
