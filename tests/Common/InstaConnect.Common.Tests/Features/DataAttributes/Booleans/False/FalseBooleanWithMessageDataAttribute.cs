namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.False;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class FalseBooleanWithMessageDataAttribute : BooleanWithMessageDataAttribute
{
	protected FalseBooleanWithMessageDataAttribute() : base(
		new FalseBooleanTransformer(),
		new FalseBooleanMessageTransformer())
	{
	}
}
