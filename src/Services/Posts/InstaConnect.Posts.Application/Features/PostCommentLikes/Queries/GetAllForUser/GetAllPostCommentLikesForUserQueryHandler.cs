namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;

internal class GetAllPostCommentLikesForUserQueryHandler : IQueryHandler<GetAllPostCommentLikesForUserQueryRequest, GetAllPostCommentLikesForUserQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentLikeQueryService _commentLikeService;

	public GetAllPostCommentLikesForUserQueryHandler(
		IApplicationMapper mapper,
		IPostCommentLikeQueryService commentLikeService)
	{
		_mapper = mapper;
		_commentLikeService = commentLikeService;
	}

	public async Task<GetAllPostCommentLikesForUserQueryResponse> Handle(
		GetAllPostCommentLikesForUserQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllPostCommentLikesForUserQuery>(request);
		var serviceResponse = await _commentLikeService.GetAllForUserAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllPostCommentLikesForUserQueryResponse>(serviceResponse);

		return response;
	}
}
