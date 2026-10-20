namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.Empty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class EmptyIntDataAttribute : IntDataAttribute
{
	protected EmptyIntDataAttribute() : base(new EmptyIntTransformer())
	{
	}
}
