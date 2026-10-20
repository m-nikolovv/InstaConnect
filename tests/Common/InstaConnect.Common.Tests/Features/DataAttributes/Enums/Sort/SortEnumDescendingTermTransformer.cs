namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

internal class SortEnumDescendingTermTransformer<T, TValue> : ISortEnumTermTransformer<T>
	where T : IEntity
{
	private readonly Func<T, TValue> _term;

	public SortEnumDescendingTermTransformer(Func<T, TValue> term)
	{
		_term = term;
	}

	public IEnumerable<T> Transform(IEnumerable<T> values)
	{
		return values.OrderByDescending(_term).ThenByDescending(a => a.CreatedAtUtc).AsEnumerable();
	}
}
