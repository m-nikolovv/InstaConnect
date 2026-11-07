namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class CreateIndexModelExtensions
{
	extension<T>(CreateIndexModel<T> model)
	{
		public CreateIndexModel<T> Unique()
		{
			model.Options.Unique = true;

			return model;
		}

		public CreateIndexModel<T> ExpireAfter(TimeSpan expireAfter)
		{
			model.Options.ExpireAfter = expireAfter;

			return model;
		}
	}
}
