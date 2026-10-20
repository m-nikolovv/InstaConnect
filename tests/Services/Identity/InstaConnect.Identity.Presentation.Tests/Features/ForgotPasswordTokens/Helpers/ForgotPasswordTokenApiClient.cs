using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Helpers;

internal class ForgotPasswordTokenApiClient : IForgotPasswordTokenApiClient
{
	private readonly HttpClient _httpClient;

	public ForgotPasswordTokenApiClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task AddAsync(
		AddForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		await _httpClient.AddResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> VerifyProblemDetailsAsync(
		VerifyForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.VerifyResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task VerifyAsync(
		VerifyForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		await _httpClient.VerifyResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> VerifyStatusCodeAsync(
		VerifyForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.VerifyResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
