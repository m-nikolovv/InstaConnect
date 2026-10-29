namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

public class AddPostCommentCommandRequestValidator : AbstractValidator<AddPostCommentCommandRequest>
{
	public AddPostCommentCommandRequestValidator()
	{
		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.PostIdMinLengthWithMessage()
			.PostIdMaxLengthWithMessage();

		RuleFor(r => r.UserId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(c => c.Content)
			.NotEmptyWithMessage()
			.PostTitleMinLengthWithMessage()
			.PostTitleMaxLengthWithMessage();

		RuleFor(r => r.Images)
			.PostCommentImagesMaxCountWithMessage();

		RuleForEach(r => r.Images)
			.PostCommentImageMaxSizeWithMessage()
			.PostCommentImageContentTypeWithMessage();
	}
}
