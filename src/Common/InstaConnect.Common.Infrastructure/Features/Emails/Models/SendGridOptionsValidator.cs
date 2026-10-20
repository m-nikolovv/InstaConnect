namespace InstaConnect.Common.Infrastructure.Features.Emails.Models;

public class SendGridOptionsValidator : AbstractValidator<SendGridOptions>
{
	public SendGridOptionsValidator()
	{
		RuleFor(o => o.Sender)
			.NotEmptyWithMessage();

		RuleFor(o => o.ApiKey)
			.NotEmptyWithMessage();
	}
}
