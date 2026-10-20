using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Tests.Features.Assertions;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Domain.Tests.Features.Assertions;

public static class MockAssertions
{
	extension(IGuidProvider guidProvider)
	{
		public void ShouldHaveReceivedOneNewStringGuid()
		{
			guidProvider.ShouldHaveReceivedOne().NewStringGuid();
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow()
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}

		public void ShouldHaveReceivedOneGetOffsetUtcNow(int seconds)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow(seconds);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync<TEvent>(
			TEvent message,
			CancellationToken cancellationToken)
			where TEvent : class, IEventRequest
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(message, cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync<TEvent>(
			ICollection<TEvent> messages,
			CancellationToken cancellationToken)
			where TEvent : class, IEventRequest
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(messages, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroPublishAsync<TEvent>(
			ICollection<TEvent> messages,
			CancellationToken cancellationToken)
			where TEvent : class, IEventRequest
		{
			await eventPublisher.ShouldHaveReceivedZero().PublishAsync(messages, cancellationToken);
		}
	}

	extension(IImageHandler imageHandler)
	{
		public async Task ShouldHaveReceivedOneUploadAsync(
			IFormFile formFile,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOne().UploadAsync(formFile, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUploadRangeAsync(
			ICollection<IFormFile> formFiles,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOne().UploadRangeAsync(formFiles, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroUploadAsync(
			IFormFile formFile,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZero().UploadAsync(formFile, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroUploadRangeAsync(
			ICollection<IFormFile> formFiles,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZero().UploadRangeAsync(formFiles, cancellationToken);
		}
	}
}
