namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.True;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class TrueBooleanWithMessageDataAttribute : BooleanWithMessageDataAttribute
{
	protected TrueBooleanWithMessageDataAttribute() : base(
		new TrueBooleanTransformer(),
		new TrueBooleanMessageTransformer())
	{
	}
}
