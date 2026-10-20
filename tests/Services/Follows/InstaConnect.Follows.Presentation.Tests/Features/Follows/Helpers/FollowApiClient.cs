using System.Net;

using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Extensions;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Helpers;

internal class FollowApiClient : IFollowApiClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public FollowApiClient(
		HttpClient httpClient,
		IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllFollowsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllFollowsApiResponse> GetAllAsync(
		GetAllFollowsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetAllFollowsApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllFollowsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetAllForFollowingProblemDetailsAsync(
		GetAllFollowsForFollowingApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllForFollowingResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllFollowsForFollowingApiResponse> GetAllForFollowingAsync(
		GetAllFollowsForFollowingApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllForFollowingResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetAllFollowsForFollowingApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllForFollowingStatusCodeAsync(
		GetAllFollowsForFollowingApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllForFollowingResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetFollowByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetFollowByIdApiResponse> GetByIdAsync(
		GetFollowByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetFollowByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetFollowByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddFollowApiResponse> AddAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<AddFollowApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}
}
