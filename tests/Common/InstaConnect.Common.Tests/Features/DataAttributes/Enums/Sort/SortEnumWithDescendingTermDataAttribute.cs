namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class SortEnumWithDescendingTermDataAttribute<TEnum, T, TValue> : SortEnumDataAttribute<TEnum>
	where TEnum : Enum
	where T : IEntity
{
	public ISortEnumTermTransformer<T> TermTransformer { get; }

	protected SortEnumWithDescendingTermDataAttribute(TEnum value, Func<T, TValue> term)
		: base(value)
	{
		TermTransformer = new SortEnumDescendingTermTransformer<T, TValue>(term);
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer, TermTransformer };
	}
}
