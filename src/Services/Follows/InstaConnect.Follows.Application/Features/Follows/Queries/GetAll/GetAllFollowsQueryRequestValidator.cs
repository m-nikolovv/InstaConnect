using InstaConnect.Follows.Application.Features.Follows.Extensions;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

public class GetAllFollowsQueryRequestValidator : AbstractValidator<GetAllFollowsQueryRequest>
{
	public GetAllFollowsQueryRequestValidator()
	{
		RuleFor(c => c.FollowerId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(c => c.FollowingName)
			.UserNameMaxLengthWithMessage();

		RuleFor(c => c.CurrentUserId)
			.UserIdMaxLengthWithMessage();

		RuleFor(q => q.SortOrder)
			.NotEmptyWithMessage();

		RuleFor(q => q.SortTerm)
			.NotEmptyWithMessage();

		RuleFor(q => q.Page)
			.FollowPageMinValueWithMessage()
			.FollowPageMaxValueWithMessage();

		RuleFor(q => q.PageSize)
			.FollowPageSizeMinValueWithMessage()
			.FollowPageSizeMaxValueWithMessage();
	}
}
