namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;

internal class GetAllPostCommentsForUserQueryHandler : IQueryHandler<GetAllPostCommentsForUserQueryRequest, GetAllPostCommentsForUserQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostCommentQueryService _commentService;

	public GetAllPostCommentsForUserQueryHandler(
		IApplicationMapper mapper,
		IPostCommentQueryService commentService)
	{
		_mapper = mapper;
		_commentService = commentService;
	}

	public async Task<GetAllPostCommentsForUserQueryResponse> Handle(
		GetAllPostCommentsForUserQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllPostCommentsForUserQuery>(request);
		var serviceResponse = await _commentService.GetAllForUserAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllPostCommentsForUserQueryResponse>(serviceResponse);

		return response;
	}
}
