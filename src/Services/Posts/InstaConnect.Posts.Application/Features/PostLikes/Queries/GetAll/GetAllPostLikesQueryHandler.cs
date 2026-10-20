namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

internal class GetAllPostLikesQueryHandler : IQueryHandler<GetAllPostLikesQueryRequest, GetAllPostLikesQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostLikeQueryService _likeService;

	public GetAllPostLikesQueryHandler(
		IApplicationMapper mapper,
		IPostLikeQueryService likeService)
	{
		_mapper = mapper;
		_likeService = likeService;
	}

	public async Task<GetAllPostLikesQueryResponse> Handle(
		GetAllPostLikesQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllPostLikesQuery>(request);
		var serviceResponse = await _likeService.GetAllAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllPostLikesQueryResponse>(serviceResponse);

		return response;
	}
}
