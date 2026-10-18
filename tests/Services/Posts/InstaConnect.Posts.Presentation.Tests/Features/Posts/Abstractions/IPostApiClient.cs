using System.Net;

using InstaConnect.Common.Presentation.Features.Exceptions.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Abstractions;

public interface IPostApiClient
{
	public Task<GetAllPostsApiResponse> GetAllAsync(GetAllPostsApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(GetAllPostsApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllPostsApiRequest request, CancellationToken cancellationToken);
	public Task<GetAllPostsForUserApiResponse> GetAllForUserAsync(GetAllPostsForUserApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> GetAllForUserProblemDetailsAsync(GetAllPostsForUserApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> GetAllForUserStatusCodeAsync(GetAllPostsForUserApiRequest request, CancellationToken cancellationToken);
	public Task<GetPostByIdApiResponse> GetByIdAsync(GetPostByIdApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(GetPostByIdApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> GetByIdStatusCodeAsync(GetPostByIdApiRequest request, CancellationToken cancellationToken);
	public Task<AddPostApiResponse> AddAsync(AddPostApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(AddPostApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> AddProblemDetailsAsync(AddPostApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(AddPostApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> AddStatusCodeAsync(AddPostApiRequest request, CancellationToken cancellationToken);
	public Task<UpdatePostApiResponse> UpdateAsync(UpdatePostApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> UpdateUnauthorizedProblemDetailsAsync(UpdatePostApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> UpdateProblemDetailsAsync(UpdatePostApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> UpdateUnauthorizedStatusCodeAsync(UpdatePostApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> UpdateStatusCodeAsync(UpdatePostApiRequest request, CancellationToken cancellationToken);
	public Task DeleteAsync(DeletePostApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(DeletePostApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(DeletePostApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(DeletePostApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> DeleteStatusCodeAsync(DeletePostApiRequest request, CancellationToken cancellationToken);
}
