using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Helpers;

internal class EmailConfirmationTokenApiClient : IEmailConfirmationTokenApiClient
{
	private readonly HttpClient _httpClient;

	public EmailConfirmationTokenApiClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task AddAsync(
		AddEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		await _httpClient.AddResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> VerifyProblemDetailsAsync(
		VerifyEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.VerifyResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task VerifyAsync(
		VerifyEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		await _httpClient.VerifyResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> VerifyStatusCodeAsync(
		VerifyEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.VerifyResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
