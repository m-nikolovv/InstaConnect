using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.Assertions;

using MediatR;

namespace InstaConnect.Common.Application.Tests.Features.Assertions;

public static class MockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldHaveReceivedOneSendAsync<TRequest>(
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync<TResponse>(
			IRequest<TResponse> request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request, cancellationToken);
		}
	}
}
