using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Helpers;

internal class UserApiClient : IUserApiClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public UserApiClient(HttpClient httpClient, IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllUsersApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllUsersApiResponse> GetAllAsync(
		GetAllUsersApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetAllUsersApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllUsersApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetAllResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetUserByIdApiResponse> GetByIdAsync(
		GetUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetUserByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetCurrentByIdUnauthorizedProblemDetailsAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetCurrentByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetCurrentByIdProblemDetailsAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetCurrentByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetCurrentUserByIdApiResponse> GetCurrentByIdAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetCurrentByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetCurrentUserByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetCurrentByIdUnauthorizedStatusCodeAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetCurrentByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetCurrentByIdStatusCodeAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetCurrentByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetDetailsByIdUnauthorizedProblemDetailsAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetDetailsByIdForbiddenProblemDetailsAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetDetailsByIdForbiddenResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetDetailsByIdProblemDetailsAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetDetailsByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetUserDetailsByIdApiResponse> GetDetailsByIdAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetDetailsByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetUserDetailsByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetDetailsByIdUnauthorizedStatusCodeAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetDetailsByIdForbiddenStatusCodeAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetDetailsByIdForbiddenResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetDetailsByIdStatusCodeAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetDetailsByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> GetCurrentDetailsByIdUnauthorizedProblemDetailsAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetCurrentDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetCurrentDetailsByIdProblemDetailsAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetCurrentDetailsByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetCurrentUserDetailsByIdApiResponse> GetCurrentDetailsByIdAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetCurrentDetailsByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<GetCurrentUserDetailsByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetCurrentDetailsByIdUnauthorizedStatusCodeAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetCurrentDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetCurrentDetailsByIdStatusCodeAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.GetCurrentDetailsByIdResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddUserApiResponse> AddAsync(
		AddUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<AddUserApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> UpdateCurrentUnauthorizedProblemDetailsAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.UpdateCurrentUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> UpdateCurrentProblemDetailsAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.UpdateCurrentResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<UpdateCurrentUserApiResponse> UpdateCurrentAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.UpdateCurrentResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetFromJsonAsync<UpdateCurrentUserApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> UpdateCurrentUnauthorizedStatusCodeAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.UpdateCurrentUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> UpdateCurrentStatusCodeAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.UpdateCurrentResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteForbiddenProblemDetailsAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteForbiddenResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteForbiddenStatusCodeAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteForbiddenResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<ApplicationProblemDetails> DeleteCurrentUnauthorizedProblemDetailsAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteCurrentUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteCurrentProblemDetailsAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteCurrentResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteCurrentAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		await _httpClient.DeleteCurrentResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteCurrentUnauthorizedStatusCodeAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteCurrentUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteCurrentStatusCodeAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await _httpClient.DeleteCurrentResponseMessageAsync(request, _baseAccessTokenGenerator, cancellationToken);

		return response.GetStatusCode();
	}
}
