namespace InstaConnect.Identity.Application.Features.Users.Commands.Add;

public class AddUserCommandRequestValidator : AbstractValidator<AddUserCommandRequest>
{
	public AddUserCommandRequestValidator()
	{
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

		RuleFor(r => r.Password)
			.NotEmptyWithMessage()
			.UserPasswordMinLengthWithMessage()
			.UserPasswordMaxLengthWithMessage();

		RuleFor(r => r.ConfirmPassword)
			.EqualWithMessage(r => r.Password);

		RuleFor(r => r.ProfileImage)
			.UserProfileImageMaxSizeWithMessage()
			.UserProfileImageContentTypeWithMessage();
	}
}
