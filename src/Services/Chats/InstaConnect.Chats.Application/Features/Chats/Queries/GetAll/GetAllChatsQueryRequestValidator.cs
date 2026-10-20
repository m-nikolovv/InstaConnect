using InstaConnect.Chats.Application.Features.Chats.Extensions;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;

public class GetAllChatsQueryRequestValidator : AbstractValidator<GetAllChatsQueryRequest>
{
	public GetAllChatsQueryRequestValidator()
	{
		RuleFor(c => c.ParticipantTwoName)
			.UserNameMaxLengthWithMessage();

		RuleFor(c => c.CurrentUserId)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(q => q.SortOrder)
			.NotEmptyWithMessage();

		RuleFor(q => q.SortTerm)
			.NotEmptyWithMessage();

		RuleFor(q => q.Page)
			.ChatPageMinValueWithMessage()
			.ChatPageMaxValueWithMessage();

		RuleFor(q => q.PageSize)
			.ChatPageSizeMinValueWithMessage()
			.ChatPageSizeMaxValueWithMessage();
	}
}
