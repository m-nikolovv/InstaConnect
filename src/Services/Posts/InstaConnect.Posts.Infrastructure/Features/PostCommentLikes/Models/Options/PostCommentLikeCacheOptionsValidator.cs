using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Models.Options;

public class PostCommentLikeCacheOptionsValidator : AbstractValidator<PostCommentLikeCacheOptions>
{
	public PostCommentLikeCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
