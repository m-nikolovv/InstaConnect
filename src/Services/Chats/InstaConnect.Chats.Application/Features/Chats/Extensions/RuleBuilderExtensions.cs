using InstaConnect.Chats.Domain.Features.Chats.Utilities;

namespace InstaConnect.Chats.Application.Features.Chats.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, int> ruleBuilder)
	{
		public IRuleBuilderOptions<T, int> ChatPageMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(ChatConfigurations.PageMinValue);
		}

		public IRuleBuilderOptions<T, int> ChatPageMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(ChatConfigurations.PageMaxValue);
		}

		public IRuleBuilderOptions<T, int> ChatPageSizeMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(ChatConfigurations.PageSizeMinValue);
		}

		public IRuleBuilderOptions<T, int> ChatPageSizeMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(ChatConfigurations.PageSizeMaxValue);
		}
	}
}
