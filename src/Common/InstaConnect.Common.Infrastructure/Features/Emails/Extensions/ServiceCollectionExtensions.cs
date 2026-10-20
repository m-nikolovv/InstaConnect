using InstaConnect.Common.Domain.Features.Emails.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Emails.Helpers;
using InstaConnect.Common.Infrastructure.Features.Emails.Models;

using SendGrid;

namespace InstaConnect.Common.Infrastructure.Features.Emails.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddEmailSenders(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<SendGridOptions>(SendGridOptions.SectionName);

			var options = configuration.GetOptions<SendGridOptions>(SendGridOptions.SectionName);

			serviceCollection.AddSingleton<ISendGridClient>(_ => new SendGridClient(options.ApiKey));
			serviceCollection.AddScoped<IEmailSender, EmailSender>();

			return serviceCollection;
		}
	}
}
