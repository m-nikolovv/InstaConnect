namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.DifferentCase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DifferentCaseStringDataAttribute : StringDataAttribute
{
	protected DifferentCaseStringDataAttribute() : base(new DifferentCaseStringTransformer())
	{

	}
}
