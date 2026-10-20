namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQueryRequest, GetAllPostsQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostQueryService _service;

	public GetAllPostsQueryHandler(IApplicationMapper mapper, IPostQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetAllPostsQueryResponse> Handle(
		GetAllPostsQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllPostsQuery>(request);
		var collection = await _service.GetAllAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllPostsQueryResponse>(collection);

		return response;
	}
}
