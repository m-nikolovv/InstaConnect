namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

internal class GetAllPostCommentLikesQueryHandler : IQueryHandler<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentLikeQueryService _commentLikeService;

	public GetAllPostCommentLikesQueryHandler(
		IApplicationMapper mapper,
		IPostCommentLikeQueryService commentLikeService)
	{
		_mapper = mapper;
		_commentLikeService = commentLikeService;
	}

	public async Task<GetAllPostCommentLikesQueryResponse> Handle(
		GetAllPostCommentLikesQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllPostCommentLikesQuery>(request);
		var serviceResponse = await _commentLikeService.GetAllAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllPostCommentLikesQueryResponse>(serviceResponse);

		return response;
	}
}
