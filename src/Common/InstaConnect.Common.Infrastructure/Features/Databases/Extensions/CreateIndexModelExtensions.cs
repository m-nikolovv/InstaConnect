namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class CreateIndexModelExtensions
{
	extension<T>(CreateIndexModel<T> model)
	{
		public CreateIndexModel<T> WithUnique()
		{
			model.Options.Unique = true;

			return model;
		}

		public CreateIndexModel<T> WithExpiration()
		{
			model.Options.ExpireAfter = TimeSpan.Zero;

			return model;
		}
	}
}
