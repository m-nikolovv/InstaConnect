namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

internal class GetAllPostCommentsQueryHandler : IQueryHandler<GetAllPostCommentsQueryRequest, GetAllPostCommentsQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentQueryService _commentService;

	public GetAllPostCommentsQueryHandler(
		IApplicationMapper mapper,
		IPostCommentQueryService commentService)
	{
		_mapper = mapper;
		_commentService = commentService;
	}

	public async Task<GetAllPostCommentsQueryResponse> Handle(
		GetAllPostCommentsQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllPostCommentsQuery>(request);
		var collection = await _commentService.GetAllAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllPostCommentsQueryResponse>(collection);

		return response;
	}
}
