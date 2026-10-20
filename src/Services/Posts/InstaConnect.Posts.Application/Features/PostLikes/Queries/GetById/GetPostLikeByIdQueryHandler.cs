namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

internal class GetPostLikeByIdQueryHandler : IQueryHandler<GetPostLikeByIdQueryRequest, GetPostLikeByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostLikeQueryService _likeService;

	public GetPostLikeByIdQueryHandler(
		IApplicationMapper mapper,
		IPostLikeQueryService likeService)
	{
		_mapper = mapper;
		_likeService = likeService;
	}

	public async Task<GetPostLikeByIdQueryResponse> Handle(
		GetPostLikeByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetPostLikeByIdQuery>(request);
		var serviceResponse = await _likeService.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetPostLikeByIdQueryResponse>(serviceResponse);

		return response;
	}
}
