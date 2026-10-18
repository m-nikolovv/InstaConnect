using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.AnalyzeById;

internal class AnalyzePostByIdQueryHandler : IQueryHandler<AnalyzePostByIdQueryRequest, AnalyzePostByIdQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostQueryService _service;

	public AnalyzePostByIdQueryHandler(IApplicationMapper mapper, IPostQueryService service)
	{
		_mapper = mapper;
		_service = service;
	}

	public async Task<AnalyzePostByIdQueryResponse> Handle(
		AnalyzePostByIdQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<AnalyzePostByIdQuery>(request);
		var serviceResponse = await _service.AnalyzeByIdAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<AnalyzePostByIdQueryResponse>(serviceResponse);

		return response;
	}
}
