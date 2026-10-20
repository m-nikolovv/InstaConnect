namespace InstaConnect.Common.Infrastructure.Features.Caches.Models;

public class RedisOptionsValidator : AbstractValidator<RedisOptions>
{
	public RedisOptionsValidator()
	{
		RuleFor(o => o.ConnectionString)
			.NotEmptyWithMessage();
	}
}
