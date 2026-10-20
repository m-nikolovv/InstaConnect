using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Helpers;

internal class PostLikeApiClient : IPostLikeApiClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public PostLikeApiClient(
		HttpClient httpClient,
		IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllPostLikesApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllPostLikesApiResponse> GetAllAsync(
		GetAllPostLikesApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetAllPostLikesApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllPostLikesApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetAllForUserProblemDetailsAsync(
		GetAllPostLikesForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllForUserResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllPostLikesForUserApiResponse> GetAllForUserAsync(
		GetAllPostLikesForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllForUserResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetAllPostLikesForUserApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllForUserStatusCodeAsync(
		GetAllPostLikesForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllForUserResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetPostLikeByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetPostLikeByIdApiResponse> GetByIdAsync(
		GetPostLikeByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetPostLikeByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetPostLikeByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddPostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddPostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddPostLikeApiResponse> AddAsync(
		AddPostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<AddPostLikeApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddPostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddPostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeletePostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeletePostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeletePostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeletePostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeletePostLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}
}
