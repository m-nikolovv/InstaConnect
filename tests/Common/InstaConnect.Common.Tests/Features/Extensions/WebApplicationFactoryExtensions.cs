using System.Security.Claims;

using InstaConnect.Common.Domain.Features.AccessTokens.Utilities;

using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.SignalR.Client;

namespace InstaConnect.Common.Tests.Features.Extensions;

public static class WebApplicationFactoryExtensions
{
	extension<T>(WebApplicationFactory<T> webApplicationFactory)
		where T : class
	{
		public HubConnection CreateHubConnection(string userId, string url)
		{
			var token = webApplicationFactory.Services
				.GetBaseAccessTokenGenerator()
				.Generate([new Claim(DefaultClaims.Id, userId)])
				.Value;

			var hubUrl = new Uri(webApplicationFactory.Server.BaseAddress, url);

			var connection = new HubConnectionBuilder()
				.WithUrl(hubUrl, options =>
				{
					options.HttpMessageHandlerFactory = _ => webApplicationFactory.Server.CreateHandler();
					options.Transports = HttpTransportType.LongPolling;
					options.AccessTokenProvider = () => Task.FromResult<string?>(token);
				})
				.Build();

			return connection;
		}

		public HubConnection CreateUnauthorizedHubConnection(string url)
		{
			var hubUrl = new Uri(webApplicationFactory.Server.BaseAddress, url);

			var connection = new HubConnectionBuilder()
				.WithUrl(hubUrl, options =>
				{
					options.HttpMessageHandlerFactory = _ => webApplicationFactory.Server.CreateHandler();
					options.Transports = HttpTransportType.LongPolling;
				})
				.Build();

			return connection;
		}
	}
}
