namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyIntWithMessageDataAttribute : IntWithMessageDataAttribute
{
	protected EmptyIntWithMessageDataAttribute() : base(new EmptyIntTransformer(), new EmptyIntMessageTransformer())
	{
	}
}
