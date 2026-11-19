using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models.Options;

public class PostCacheOptionsValidator : AbstractValidator<PostCacheOptions>
{
	public PostCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
