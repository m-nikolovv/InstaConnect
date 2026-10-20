namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class SortEnumDataAttribute<TEnum> : EnumDataAttribute<TEnum>
	where TEnum : Enum
{
	protected SortEnumDataAttribute(TEnum value) : base(new SortEnumTransformer<TEnum>(value))
	{
	}
}
