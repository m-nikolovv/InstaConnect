using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Application.Features.UserClaims.Queries.GetAll;

internal class GetAllUserClaimsQueryHandler : IQueryHandler<GetAllUserClaimsQueryRequest, GetAllUserClaimsQueryResponse>
{
	private readonly IApplicationMapper _mapper;
	private readonly IUserClaimQueryService _claimService;

	public GetAllUserClaimsQueryHandler(
		IApplicationMapper mapper,
		IUserClaimQueryService claimService)
	{
		_mapper = mapper;
		_claimService = claimService;
	}

	public async Task<GetAllUserClaimsQueryResponse> Handle(
		GetAllUserClaimsQueryRequest request,
		CancellationToken cancellationToken)
	{
		var serviceRequest = _mapper.Map<GetAllUserClaimsQuery>(request);
		var serviceResponse = await _claimService.GetAllAsync(serviceRequest, cancellationToken);

		var response = _mapper.Map<GetAllUserClaimsQueryResponse>(serviceResponse);

		return response;
	}
}
