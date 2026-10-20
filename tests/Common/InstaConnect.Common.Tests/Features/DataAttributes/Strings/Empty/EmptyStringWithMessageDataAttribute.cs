namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
	protected EmptyStringWithMessageDataAttribute() : base(
		new EmptyStringTransformer(),
		new EmptyStringMessageTransformer())
	{
	}
}
