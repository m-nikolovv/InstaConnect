namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Abstractions;

public interface IFollowApiClient
{
	public Task<AddFollowApiResponse> AddAsync(AddFollowApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> AddProblemDetailsAsync(AddFollowApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(AddFollowApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> AddStatusCodeAsync(AddFollowApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(AddFollowApiRequest request, CancellationToken cancellationToken);

	public Task DeleteAsync(DeleteFollowApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(DeleteFollowApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(DeleteFollowApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> DeleteStatusCodeAsync(DeleteFollowApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(DeleteFollowApiRequest request, CancellationToken cancellationToken);

	public Task<GetAllFollowsApiResponse> GetAllAsync(GetAllFollowsApiRequest request, CancellationToken cancellationToken);
	public Task<GetAllFollowsForFollowingApiResponse> GetAllForFollowingAsync(GetAllFollowsForFollowingApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> GetAllForFollowingProblemDetailsAsync(GetAllFollowsForFollowingApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> GetAllForFollowingStatusCodeAsync(GetAllFollowsForFollowingApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(GetAllFollowsApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllFollowsApiRequest request, CancellationToken cancellationToken);

	public Task<GetFollowByIdApiResponse> GetByIdAsync(GetFollowByIdApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(GetFollowByIdApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> GetByIdStatusCodeAsync(GetFollowByIdApiRequest request, CancellationToken cancellationToken);
}
