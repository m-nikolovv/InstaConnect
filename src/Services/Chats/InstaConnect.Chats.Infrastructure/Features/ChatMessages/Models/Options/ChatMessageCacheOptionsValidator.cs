using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Models.Options;

public class ChatMessageCacheOptionsValidator : AbstractValidator<ChatMessageCacheOptions>
{
	public ChatMessageCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
