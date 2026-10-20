using InstaConnect.Chats.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Base;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Users.Assertions;

public static class UserValidationExceptionAssertions
{
	extension(UserAddedEventHandler handler)
	{
		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			UserAddedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.Id,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
			UserAddedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.Name,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
			UserAddedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.FirstName,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
			UserAddedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.LastName,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForEmailAsync(
			UserAddedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.Email,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForProfileImageAsync(
			UserAddedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.ProfileImageUrl!,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCreatedAtUtcAsync(
			UserAddedEventRequest request,
			IDateTimeOffsetMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.CreatedAtUtc,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(
			UserAddedEventRequest request,
			IDateTimeOffsetMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.UpdatedAtUtc,
				messageTransformer,
				cancellationToken);
		}
	}

	extension(UserUpdatedEventHandler handler)
	{
		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			UserUpdatedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.Id,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
			UserUpdatedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.Name,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
			UserUpdatedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.FirstName,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
			UserUpdatedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.LastName,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForEmailAsync(
			UserUpdatedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.Email,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForProfileImageAsync(
			UserUpdatedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.ProfileImageUrl!,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(
			UserUpdatedEventRequest request,
			IDateTimeOffsetMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.UpdatedAtUtc,
				messageTransformer,
				cancellationToken);
		}
	}

	extension(UserDeletedEventHandler handler)
	{
		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			UserDeletedEventRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.User.Id,
				messageTransformer,
				cancellationToken);
		}
	}
}
