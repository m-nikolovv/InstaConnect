using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Models.Options;

public class ChatMessageImageCacheOptionsValidator : AbstractValidator<ChatMessageImageCacheOptions>
{
	public ChatMessageImageCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
