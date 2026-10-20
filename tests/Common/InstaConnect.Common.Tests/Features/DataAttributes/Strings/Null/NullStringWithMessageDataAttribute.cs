namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Null;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
	protected NullStringWithMessageDataAttribute() : base(
		new NullStringTransformer(),
		new NullStringMessageTransformer())
	{
	}
}
