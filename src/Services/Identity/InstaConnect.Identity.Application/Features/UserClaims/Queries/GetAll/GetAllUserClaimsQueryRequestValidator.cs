using InstaConnect.Identity.Application.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Application.Features.UserClaims.Queries.GetAll;

public class GetAllUserClaimsQueryRequestValidator : AbstractValidator<GetAllUserClaimsQueryRequest>
{
	public GetAllUserClaimsQueryRequestValidator()
	{
		RuleFor(c => c.Id)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(c => c.CurrentId)
			.UserIdMaxLengthWithMessage();

		RuleFor(q => q.SortOrder)
			.NotEmptyWithMessage();

		RuleFor(q => q.SortTerm)
			.NotEmptyWithMessage();

		RuleFor(q => q.Page)
			.UserClaimPageMinValueWithMessage()
			.UserClaimPageMaxValueWithMessage();

		RuleFor(q => q.PageSize)
			.UserClaimPageSizeMinValueWithMessage()
			.UserClaimPageSizeMaxValueWithMessage();
	}
}
