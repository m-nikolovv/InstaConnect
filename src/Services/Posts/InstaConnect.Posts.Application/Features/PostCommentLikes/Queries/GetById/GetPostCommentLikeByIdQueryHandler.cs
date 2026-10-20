namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

internal class GetPostCommentLikeByIdQueryHandler : IQueryHandler<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentLikeQueryService _commentLikeService;

	public GetPostCommentLikeByIdQueryHandler(
		IApplicationMapper mapper,
		IPostCommentLikeQueryService commentLikeService)
	{
		_mapper = mapper;
		_commentLikeService = commentLikeService;
	}

	public async Task<GetPostCommentLikeByIdQueryResponse> Handle(
		GetPostCommentLikeByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetPostCommentLikeByIdQuery>(request);
		var serviceResponse = await _commentLikeService.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetPostCommentLikeByIdQueryResponse>(serviceResponse);

		return response;
	}
}
