namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

internal class SortEnumAscendingTermTransformer<T, TValue> : ISortEnumTermTransformer<T>
	where T : IEntity
{
	private readonly Func<T, TValue> _term;

	public SortEnumAscendingTermTransformer(Func<T, TValue> term)
	{
		_term = term;
	}

	public IEnumerable<T> Transform(IEnumerable<T> values)
	{
		return values.OrderBy(_term).ThenBy(a => a.CreatedAtUtc).AsEnumerable();
	}
}
