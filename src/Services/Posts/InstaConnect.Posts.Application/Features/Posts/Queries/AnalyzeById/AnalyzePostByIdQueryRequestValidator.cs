namespace InstaConnect.Posts.Application.Features.Posts.Queries.AnalyzeById;

public class AnalyzePostByIdQueryRequestValidator : AbstractValidator<AnalyzePostByIdQueryRequest>
{
	public AnalyzePostByIdQueryRequestValidator()
	{
		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.PostIdMinLengthWithMessage()
			.PostIdMaxLengthWithMessage();

		RuleFor(c => c.CurrentUserId)
			.UserIdMaxLengthWithMessage();
	}
}
