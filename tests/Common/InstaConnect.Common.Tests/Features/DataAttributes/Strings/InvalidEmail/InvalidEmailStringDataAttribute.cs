namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.InvalidEmail;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class InvalidEmailStringDataAttribute : StringDataAttribute
{
	protected InvalidEmailStringDataAttribute() : base(new InvalidEmailStringTransformer())
	{
	}
}
