namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

internal class GetPostCommentByIdQueryHandler : IQueryHandler<GetPostCommentByIdQueryRequest, GetPostCommentByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentQueryService _commentService;

	public GetPostCommentByIdQueryHandler(
		IApplicationMapper mapper,
		IPostCommentQueryService commentService)
	{
		_mapper = mapper;
		_commentService = commentService;
	}

	public async Task<GetPostCommentByIdQueryResponse> Handle(
		GetPostCommentByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetPostCommentByIdQuery>(request);
		var postComment = await _commentService.GetByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetPostCommentByIdQueryResponse>(postComment);

		return response;
	}
}
