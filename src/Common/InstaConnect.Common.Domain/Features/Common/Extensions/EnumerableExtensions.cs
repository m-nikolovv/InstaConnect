namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class EnumerableExtensions
{
	extension<T>(IEnumerable<T> enumerable)
	{
		public bool IsEmpty()
		{
			return !enumerable.Any();
		}
	}

	extension(IEnumerable<string> enumerable)
	{
		public string JoinWith(string separator)
		{
			return string.Join(separator, enumerable);
		}

		public string JoinWithSpace()
		{
			const string Separator = " ";

			return enumerable.JoinWith(Separator);
		}

		public string JoinWithSemicolon()
		{
			const string Separator = "; ";

			return enumerable.JoinWith(Separator);
		}

		public string JoinWithColon()
		{
			const string Separator = ":";

			return enumerable.JoinWith(Separator);
		}

		public string JoinWithComma()
		{
			const string Separator = ", ";

			return enumerable.JoinWith(Separator);
		}
	}
}
