using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Models.Options;

public class PostCommentCacheOptionsValidator : AbstractValidator<PostCommentCacheOptions>
{
	public PostCommentCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
