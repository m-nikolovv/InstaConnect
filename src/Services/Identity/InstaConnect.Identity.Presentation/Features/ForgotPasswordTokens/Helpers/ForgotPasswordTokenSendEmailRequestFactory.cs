using InstaConnect.Common.Domain.Features.Emails.Models;
using InstaConnect.Common.Presentation.Features.Common.Models;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenSendEmailRequestFactory : IForgotPasswordTokenSendEmailRequestFactory
{
	private readonly MainOptions _mainOptions;
	private readonly IForgotPasswordTokenTemplateFactory _templateFactory;

	public ForgotPasswordTokenSendEmailRequestFactory(
		IOptions<MainOptions> mainOptions,
		IForgotPasswordTokenTemplateFactory templateFactory)
	{
		_mainOptions = mainOptions.Value;
		_templateFactory = templateFactory;
	}

	public async Task<SendEmailRequest> GetAsync(ForgotPasswordToken forgotPasswordToken, CancellationToken cancellationToken)
	{
		const string Subject = "Reset your InstaConnect password";
		const string Format = "{0}/{1}";

		var route = ForgotPasswordTokenRouteFactory.GetDefaultIdVerify(forgotPasswordToken.Id.Id.Id, forgotPasswordToken.Id.Value);
		var link = Format.FormatCurrentCulture(_mainOptions.BaseUrl, route);
		var template = await _templateFactory.GetAddedAsync(new(link), cancellationToken);

		return new(forgotPasswordToken.User!.Email.Value, Subject, template);
	}
}
