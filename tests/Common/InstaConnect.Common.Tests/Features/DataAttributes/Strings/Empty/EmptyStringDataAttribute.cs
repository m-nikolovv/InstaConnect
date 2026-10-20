namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyStringDataAttribute : StringDataAttribute
{
	protected EmptyStringDataAttribute() : base(new EmptyStringTransformer())
	{

	}
}
