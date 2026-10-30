using InstaConnect.Posts.Domain.Features.Posts.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Application.Features.Posts.Extensions;

internal static class RuleBuilderExtensions
{
	extension<T>(IRuleBuilder<T, string> ruleBuilder)
	{
		public IRuleBuilderOptions<T, string> PostIdMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(PostConfigurations.IdMinLength);
		}

		public IRuleBuilderOptions<T, string> PostIdMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(PostConfigurations.IdMaxLength);
		}

		public IRuleBuilderOptions<T, string> PostTitleMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(PostConfigurations.TitleMinLength);
		}

		public IRuleBuilderOptions<T, string> PostTitleMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(PostConfigurations.TitleMaxLength);
		}

		public IRuleBuilderOptions<T, string> PostContentMinLengthWithMessage()
		{
			return ruleBuilder.MinLengthWithMessage(PostConfigurations.ContentMinLength);
		}

		public IRuleBuilderOptions<T, string> PostContentMaxLengthWithMessage()
		{
			return ruleBuilder.MaxLengthWithMessage(PostConfigurations.ContentMaxLength);
		}
	}

	extension<T>(IRuleBuilder<T, int> ruleBuilder)
	{
		public IRuleBuilderOptions<T, int> PostPageMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(PostConfigurations.PageMinValue);
		}

		public IRuleBuilderOptions<T, int> PostPageMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(PostConfigurations.PageMaxValue);
		}

		public IRuleBuilderOptions<T, int> PostPageSizeMinValueWithMessage()
		{
			return ruleBuilder.MinValueWithMessage(PostConfigurations.PageSizeMinValue);
		}

		public IRuleBuilderOptions<T, int> PostPageSizeMaxValueWithMessage()
		{
			return ruleBuilder.MaxValueWithMessage(PostConfigurations.PageSizeMaxValue);
		}
	}

	extension<T>(IRuleBuilder<T, ICollection<IFormFile>> ruleBuilder)
	{
		public IRuleBuilderOptions<T, ICollection<IFormFile>> PostImagesMaxCountWithMessage()
		{
			return ruleBuilder.MaxCountWithMessage(PostConfigurations.ImagesMaxCount);
		}
	}
}
