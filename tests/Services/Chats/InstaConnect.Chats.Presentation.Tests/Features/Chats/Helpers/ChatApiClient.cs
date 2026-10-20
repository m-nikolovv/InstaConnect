using System.Net;

using InstaConnect.Chats.Presentation.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Extensions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Helpers;

internal class ChatApiClient : IChatApiClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public ChatApiClient(
		HttpClient httpClient,
		IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllChatsApiResponse> GetAllAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetAllChatsApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllUnauthorizedStatusCodeAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetChatByIdApiResponse> GetByIdAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetChatByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdUnauthorizedStatusCodeAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddChatApiResponse> AddAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<AddChatApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}
}
