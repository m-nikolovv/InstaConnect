namespace InstaConnect.Common.Infrastructure.Features.Databases.Models;

public record MongoOptions(
	string ConnectionString,
	string Name) : IApplicationOptions
{
	public const string SectionName = "MongoConfiguration";
}
