using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Models.Options;

public class PostLikeCacheOptionsValidator : AbstractValidator<PostLikeCacheOptions>
{
	public PostLikeCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
