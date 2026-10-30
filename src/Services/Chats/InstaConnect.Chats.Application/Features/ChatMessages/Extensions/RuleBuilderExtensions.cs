using InstaConnect.Chats.Domain.Features.ChatMessages.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, string> ruleBuilder)
	{
		public IRuleBuilderOptions<T, string> ChatMessageIdMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(ChatMessageConfigurations.IdMinLength);
		}

		public IRuleBuilderOptions<T, string> ChatMessageIdMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(ChatMessageConfigurations.IdMaxLength);
		}

		public IRuleBuilderOptions<T, string> ChatMessageContentMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(ChatMessageConfigurations.ContentMinLength);
		}

		public IRuleBuilderOptions<T, string> ChatMessageContentMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(ChatMessageConfigurations.ContentMaxLength);
		}
	}

	extension<T>(IRuleBuilder<T, int> ruleBuilder)
	{
		public IRuleBuilderOptions<T, int> ChatMessagePageMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(ChatMessageConfigurations.PageMinValue);
		}

		public IRuleBuilderOptions<T, int> ChatMessagePageMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(ChatMessageConfigurations.PageMaxValue);
		}

		public IRuleBuilderOptions<T, int> ChatMessagePageSizeMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(ChatMessageConfigurations.PageSizeMinValue);
		}

		public IRuleBuilderOptions<T, int> ChatMessagePageSizeMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(ChatMessageConfigurations.PageSizeMaxValue);
		}
	}

	extension<T>(IRuleBuilder<T, ICollection<IFormFile>> ruleBuilder)
	{
		public IRuleBuilderOptions<T, ICollection<IFormFile>> ChatMessageImagesMaxCountWithMessage()
		{
			return ruleBuilder.MaxCountWithMessage(ChatMessageConfigurations.ImagesMaxCount);
		}
	}
}
