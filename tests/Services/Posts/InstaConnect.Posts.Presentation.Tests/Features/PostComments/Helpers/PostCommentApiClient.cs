using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Helpers;

internal class PostCommentApiClient : IPostCommentApiClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public PostCommentApiClient(
		HttpClient httpClient,
		IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllPostCommentsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllPostCommentsApiResponse> GetAllAsync(
		GetAllPostCommentsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetAllPostCommentsApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllPostCommentsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetAllForUserProblemDetailsAsync(
		GetAllPostCommentsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllForUserResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllPostCommentsForUserApiResponse> GetAllForUserAsync(
		GetAllPostCommentsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllForUserResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetAllPostCommentsForUserApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllForUserStatusCodeAsync(
		GetAllPostCommentsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllForUserResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetPostCommentByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetPostCommentByIdApiResponse> GetByIdAsync(
		GetPostCommentByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetPostCommentByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetPostCommentByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddPostCommentApiResponse> AddAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<AddPostCommentApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> UpdateUnauthorizedProblemDetailsAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.UpdateUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> UpdateProblemDetailsAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.UpdateResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<UpdatePostCommentApiResponse> UpdateAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.UpdateResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<UpdatePostCommentApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> UpdateUnauthorizedStatusCodeAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.UpdateUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> UpdateStatusCodeAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.UpdateResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}
}
