namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

internal class SortEnumTransformer<TEnum> : IEnumTransformer<TEnum>
		where TEnum : Enum
{
	private readonly TEnum _value;

	public SortEnumTransformer(TEnum value)
	{
		_value = value;
	}

	public TEnum Transform(TEnum value)
	{
		return _value;
	}
}
