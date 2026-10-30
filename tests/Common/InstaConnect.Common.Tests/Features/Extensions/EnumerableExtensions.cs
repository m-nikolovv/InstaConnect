namespace InstaConnect.Common.Tests.Features.Extensions;

public static class EnumerableExtensions
{
	extension<T>(IEnumerable<T> source)
	{
		public bool AllAndNotEmpty(Func<T, bool> predicate)
		{
			return source.Any() && source.All(predicate);
		}

		public bool AllAndEmpty<TExpected>(IEnumerable<TExpected> expected, Func<T, bool> predicate)
		{
			return source.Count() == expected.Count() && source.All(predicate);
		}
	}
}
