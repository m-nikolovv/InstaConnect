namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;

internal class GetAllPostsForUserQueryHandler : IQueryHandler<GetAllPostsForUserQueryRequest, GetAllPostsForUserQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostQueryService _service;

	public GetAllPostsForUserQueryHandler(
		IApplicationMapper mapper,
		IPostQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<GetAllPostsForUserQueryResponse> Handle(
		GetAllPostsForUserQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllPostsForUserQuery>(request);
		var serviceResponse = await _service.GetAllForUserAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllPostsForUserQueryResponse>(serviceResponse);

		return response;
	}
}
