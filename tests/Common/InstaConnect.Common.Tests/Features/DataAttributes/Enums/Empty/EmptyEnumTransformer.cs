namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Empty;

internal class EmptyEnumTransformer<TEnum> : IEnumTransformer<TEnum>
		where TEnum : Enum
{
	public TEnum Transform(TEnum value)
	{
		return DataFaker.GetEmptyEnum<TEnum>();
	}
}

