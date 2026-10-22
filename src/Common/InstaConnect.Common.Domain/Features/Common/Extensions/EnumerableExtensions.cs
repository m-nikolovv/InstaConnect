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
			return enumerable.JoinWith(" ");
		}

		public string JoinWithSemicolon()
		{
			return enumerable.JoinWith(";");
		}
	}
}
