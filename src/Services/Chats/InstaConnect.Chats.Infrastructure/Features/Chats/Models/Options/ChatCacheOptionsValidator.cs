using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Models.Options;

public class ChatCacheOptionsValidator : AbstractValidator<ChatCacheOptions>
{
	public ChatCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
