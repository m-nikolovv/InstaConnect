namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.InvalidEmail;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class InvalidEmailStringWithMessageDataAttribute : StringWithMessageDataAttribute
{
	protected InvalidEmailStringWithMessageDataAttribute()
		: base(new InvalidEmailStringTransformer(),
			   new InvalidEmailStringMessageTransformer())
	{
	}
}
