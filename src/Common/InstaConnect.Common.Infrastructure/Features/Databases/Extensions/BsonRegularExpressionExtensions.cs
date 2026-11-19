using System.Text.RegularExpressions;

using MongoDB.Bson;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class BsonRegularExpressionExtensions
{
	extension(string value)
	{
		public BsonRegularExpression ToStartsWithIgnoreCaseRegex()
		{
			const string Pattern = "^{0}";

			return value.ToIgnoreCaseRegex(Pattern);
		}

		public BsonRegularExpression ToIgnoreCaseRegex(string regexTemplate)
		{
			const string IgnoreCase = "i";

			return new BsonRegularExpression(regexTemplate.FormatCurrentCulture(Regex.Escape(value)), IgnoreCase);
		}
	}
}
