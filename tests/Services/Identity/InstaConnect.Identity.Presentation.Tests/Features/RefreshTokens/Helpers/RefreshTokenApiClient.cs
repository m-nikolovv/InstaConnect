using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Responses;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Helpers;

internal class RefreshTokenApiClient : IRefreshTokenApiClient
{
	private readonly HttpClient _httpClient;

	public RefreshTokenApiClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<ApplicationProblemDetails> IssueProblemDetailsAsync(
		IssueRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.IssueResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<IssueRefreshTokenApiResponse> IssueAsync(
		IssueRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.IssueResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<IssueRefreshTokenApiResponse>(cancellationToken);
	}

	public async Task<RefreshTokenCookieApiResponse?> IssueCookieResponseAsync(
		IssueRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.IssueResponseMessageAsync(request, cancellationToken);

		return response.GetRefreshTokenCookieApiResponse();
	}

	public async Task<HttpStatusCode> IssueStatusCodeAsync(
		IssueRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.IssueResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> RotateWithoutCookiesProblemDetailsAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.RotateWithoutCookiesResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> RotateProblemDetailsAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.RotateResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<RotateRefreshTokenApiResponse> RotateAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.RotateResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<RotateRefreshTokenApiResponse>(cancellationToken);
	}

	public async Task<RefreshTokenCookieApiResponse?> RotateCookieResponseAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.RotateResponseMessageAsync(request, cancellationToken);

		return response.GetRefreshTokenCookieApiResponse();
	}

	public async Task<HttpStatusCode> RotateWithoutCookiesStatusCodeAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.RotateWithoutCookiesResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> RotateStatusCodeAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.RotateResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> DeleteCurrentWithoutCookiesProblemDetailsAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteCurrentWithoutCookiesResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteCurrentProblemDetailsAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteCurrentResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteCurrentAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		await _httpClient.DeleteCurrentResponseMessageAsync(request, cancellationToken);
	}

	public async Task<RefreshTokenCookieApiResponse?> DeleteCurrentCookieResponseAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteCurrentResponseMessageAsync(request, cancellationToken);

		return response.GetRefreshTokenCookieApiResponse();
	}

	public async Task<HttpStatusCode> DeleteCurrentWithoutCookiesStatusCodeAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteCurrentWithoutCookiesResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteCurrentStatusCodeAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteCurrentResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
