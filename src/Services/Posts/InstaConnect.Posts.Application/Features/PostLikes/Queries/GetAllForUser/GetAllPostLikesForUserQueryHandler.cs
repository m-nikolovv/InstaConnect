namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;

internal class GetAllPostLikesForUserQueryHandler : IQueryHandler<GetAllPostLikesForUserQueryRequest, GetAllPostLikesForUserQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostLikeQueryService _likeService;

	public GetAllPostLikesForUserQueryHandler(
		IApplicationMapper mapper,
		IPostLikeQueryService likeService)
	{
		_mapper = mapper;
		_likeService = likeService;
	}

	public async Task<GetAllPostLikesForUserQueryResponse> Handle(
		GetAllPostLikesForUserQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllPostLikesForUserQuery>(request);
		var serviceResponse = await _likeService.GetAllForUserAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllPostLikesForUserQueryResponse>(serviceResponse);

		return response;
	}
}
