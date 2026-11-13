using InstaConnect.Common.Domain.Features.Emails.Abstractions;
using InstaConnect.Common.Domain.Features.Emails.Models;
using InstaConnect.Common.Infrastructure.Features.Emails.Models;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace InstaConnect.Common.Infrastructure.Features.Emails.Helpers;

internal class EmailSender : IEmailSender
{
	private readonly ISendGridClient _sendGridClient;
	private readonly SendGridOptions _sendGridOptions;

	public EmailSender(ISendGridClient sendGridClient, SendGridOptions sendGridOptions)
	{
		_sendGridClient = sendGridClient;
		_sendGridOptions = sendGridOptions;
	}

	public async Task SendAsync(SendEmailRequest request, CancellationToken cancellationToken)
	{
		var message = MailHelper.CreateSingleEmail(
			new EmailAddress(_sendGridOptions.Sender),
			new EmailAddress(request.Receiver),
			request.Subject,
			plainTextContent: null,
			request.Template);

		await _sendGridClient.SendEmailAsync(message, cancellationToken);
	}
}
