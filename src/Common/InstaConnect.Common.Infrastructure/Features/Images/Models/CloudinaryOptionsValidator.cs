namespace InstaConnect.Common.Infrastructure.Features.Images.Models;

public class CloudinaryOptionsValidator : AbstractValidator<CloudinaryOptions>
{
	public CloudinaryOptionsValidator()
	{
		RuleFor(o => o.CloudName)
			.NotEmptyWithMessage();

		RuleFor(o => o.ApiKey)
			.NotEmptyWithMessage();

		RuleFor(o => o.ApiSecret)
			.NotEmptyWithMessage();
	}
}
