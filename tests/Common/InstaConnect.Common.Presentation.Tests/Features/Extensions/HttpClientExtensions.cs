using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Common.Domain.Features.AccessTokens.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Features.Exceptions.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;

namespace InstaConnect.Common.Presentation.Tests.Features.Extensions;

public static class HttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		public HttpClient WithAuthorization(string userId, IBaseAccessTokenGenerator baseAccessTokenGenerator)
		{
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
				JwtBearerDefaults.AuthenticationScheme,
				baseAccessTokenGenerator.Generate([new(DefaultClaims.Id, userId)]).Value);

			return httpClient;
		}

		public HttpClient WithAdminAuthorization(string userId, IBaseAccessTokenGenerator baseAccessTokenGenerator)
		{
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
				JwtBearerDefaults.AuthenticationScheme,
				baseAccessTokenGenerator.Generate([new(DefaultClaims.Id, userId), new(ApplicationClaims.Admin.GetName(), ApplicationClaims.Admin.GetName())]).Value);

			return httpClient;
		}

		public HttpClient WithCookies(params Cookie[] cookies)
		{
			const string CookieHeader = "Cookie";
			const string Format = "{0}={1}";

			var cookieHeader = cookies.Select(cookie => Format.FormatCurrentCulture(cookie.Name, cookie.Value)).JoinWithSemicolon();

			httpClient.DefaultRequestHeaders.Remove(CookieHeader);
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation(CookieHeader, cookieHeader);

			return httpClient;
		}
	}

	extension(HttpResponseMessage httpResponseMessage)
	{
		public async Task<T> GetFromJsonAsync<T>(CancellationToken cancellationToken)
		{
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
				Converters = { new JsonStringEnumConverter() }
			};

			return (await httpResponseMessage.Content.ReadFromJsonAsync<T>(options, cancellationToken))!;
		}

		public async Task<ApplicationProblemDetails> GetProblemDetailsFromJsonAsync(CancellationToken cancellationToken)
		{
			return await httpResponseMessage.GetFromJsonAsync<ApplicationProblemDetails>(cancellationToken);
		}

		public HttpStatusCode GetStatusCode()
		{
			return httpResponseMessage.StatusCode;
		}

		public SetCookieHeaderValue GetCookie(string key)
		{
			const string SetCookieHeader = "Set-Cookie";

			return httpResponseMessage.Headers
				.GetValues(SetCookieHeader)
				.Select(header => SetCookieHeaderValue.Parse(header))
				.Single(cookie => cookie.Name == key);
		}
	}
}
