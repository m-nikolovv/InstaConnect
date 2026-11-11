using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Models.Options;

public class PostCommentImageCacheOptionsValidator : AbstractValidator<PostCommentImageCacheOptions>
{
	public PostCommentImageCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
