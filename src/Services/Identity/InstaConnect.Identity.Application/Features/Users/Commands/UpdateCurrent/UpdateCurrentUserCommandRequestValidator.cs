namespace InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;

public class UpdateCurrentUserCommandRequestValidator : AbstractValidator<UpdateCurrentUserCommandRequest>
{
	public UpdateCurrentUserCommandRequestValidator()
	{
		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(r => r.Name)
			.NotEmptyWithMessage()
			.UserNameMinLengthWithMessage()
			.UserNameMaxLengthWithMessage();

		RuleFor(r => r.FirstName)
			.NotEmptyWithMessage()
			.UserFirstNameMinLengthWithMessage()
			.UserFirstNameMaxLengthWithMessage();

		RuleFor(r => r.LastName)
			.NotEmptyWithMessage()
			.UserLastNameMinLengthWithMessage()
			.UserLastNameMaxLengthWithMessage();

		RuleFor(r => r.Email)
			.NotEmptyWithMessage()
			.UserEmailMinLengthWithMessage()
			.UserEmailMaxLengthWithMessage()
			.InvalidEmailWithMessage();

		RuleFor(r => r.ProfileImage)
			.UserProfileImageMaxSizeWithMessage()
			.UserProfileImageContentTypeWithMessage();
	}
}
