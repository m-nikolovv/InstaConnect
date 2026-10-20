using InstaConnect.Posts.Application.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;

public class GetAllPostCommentLikesForUserQueryRequestValidator : AbstractValidator<GetAllPostCommentLikesForUserQueryRequest>
{
	public GetAllPostCommentLikesForUserQueryRequestValidator()
	{
		RuleFor(c => c.UserId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(c => c.CurrentUserId)
			.UserIdMaxLengthWithMessage();

		RuleFor(q => q.SortOrder)
			.NotEmptyWithMessage();

		RuleFor(q => q.SortTerm)
			.NotEmptyWithMessage();

		RuleFor(q => q.Page)
			.PostLikePageMinValueWithMessage()
			.PostLikePageMaxValueWithMessage();

		RuleFor(q => q.PageSize)
			.PostCommentLikePageSizeMinValueWithMessage()
			.PostCommentLikePageSizeMaxValueWithMessage();
	}
}
