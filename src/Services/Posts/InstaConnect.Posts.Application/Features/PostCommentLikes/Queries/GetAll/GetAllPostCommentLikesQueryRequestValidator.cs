using InstaConnect.Posts.Application.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public class GetAllPostCommentLikesQueryRequestValidator : AbstractValidator<GetAllPostCommentLikesQueryRequest>
{
	public GetAllPostCommentLikesQueryRequestValidator()
	{
		RuleFor(c => c.CurrentUserId)
			.UserIdMaxLengthWithMessage();

		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.PostIdMinLengthWithMessage()
			.PostIdMaxLengthWithMessage();

		RuleFor(r => r.CommentId)
			.NotEmptyWithMessage()
			.PostIdMinLengthWithMessage()
			.PostIdMaxLengthWithMessage();

		RuleFor(c => c.UserName)
			.UserNameMaxLengthWithMessage();

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
