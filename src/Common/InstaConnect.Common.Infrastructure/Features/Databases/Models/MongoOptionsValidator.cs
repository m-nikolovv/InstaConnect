namespace InstaConnect.Common.Infrastructure.Features.Databases.Models;

public class MongoOptionsValidator : AbstractValidator<MongoOptions>
{
	public MongoOptionsValidator()
	{
		RuleFor(o => o.ConnectionString)
			.NotEmptyWithMessage();

		RuleFor(o => o.Name)
			.NotEmptyWithMessage();
	}
}
