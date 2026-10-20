using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace InstaConnect.Common.Domain.Features.Common.Helpers;

internal sealed class ConfigurationOptionsFactory<TOptions> : OptionsFactory<TOptions>
	where TOptions : class, IApplicationOptions
{
	private readonly string _sectionName;
	private readonly IConfiguration _configuration;

	public ConfigurationOptionsFactory(
		string sectionName,
		IConfiguration configuration,
		IEnumerable<IConfigureOptions<TOptions>> setups,
		IEnumerable<IPostConfigureOptions<TOptions>> postConfigures,
		IEnumerable<IValidateOptions<TOptions>> validations)
		: base(setups, postConfigures, validations)
	{
		_sectionName = sectionName;
		_configuration = configuration;
	}

	protected override TOptions CreateInstance(string name)
	{
		return _configuration.GetOptions<TOptions>(_sectionName);
	}
}
