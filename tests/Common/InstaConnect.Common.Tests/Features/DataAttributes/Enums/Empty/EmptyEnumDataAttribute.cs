namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyEnumDataAttribute<TEnum> : EnumDataAttribute<TEnum>
	where TEnum : Enum
{
	protected EmptyEnumDataAttribute() : base(new EmptyEnumTransformer<TEnum>())
	{

	}
}

