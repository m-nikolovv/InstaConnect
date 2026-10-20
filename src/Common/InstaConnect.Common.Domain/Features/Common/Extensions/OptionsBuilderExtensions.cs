using InstaConnect.Common.Domain.Features.Common.Helpers;

using Microsoft.Extensions.Options;

namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class OptionsBuilderExtensions
{
	extension<TOptions>(OptionsBuilder<TOptions> optionsBuilder)
		where TOptions : class, IApplicationOptions
	{
		public OptionsBuilder<TOptions> ValidateFluentValidation(string sectionName)
		{
			optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(serviceProvider => new FluentValidationOptionsValidator<TOptions>(
				sectionName,
				serviceProvider.GetServices<IValidator<TOptions>>()));

			return optionsBuilder;
		}
	}
}
