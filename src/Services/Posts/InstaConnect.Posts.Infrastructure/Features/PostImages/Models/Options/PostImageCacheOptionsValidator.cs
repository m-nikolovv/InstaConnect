using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Models.Options;

public class PostImageCacheOptionsValidator : AbstractValidator<PostImageCacheOptions>
{
	public PostImageCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
