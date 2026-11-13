using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Models.Options;

public class UserCacheOptionsValidator : AbstractValidator<UserCacheOptions>
{
	public UserCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
