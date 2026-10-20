namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.True;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TrueBooleanDataAttribute : BooleanDataAttribute
{
	protected TrueBooleanDataAttribute() : base(new TrueBooleanTransformer())
	{

	}
}
