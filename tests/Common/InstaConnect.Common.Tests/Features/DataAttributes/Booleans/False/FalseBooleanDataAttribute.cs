namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.False;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class FalseBooleanDataAttribute : BooleanDataAttribute
{
	protected FalseBooleanDataAttribute() : base(new FalseBooleanTransformer())
	{

	}
}
