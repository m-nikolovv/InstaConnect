namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowPageTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
	public FollowPageTooSmallWithMessageDataAttribute()
		: base(FollowConfigurations.PageMinValue)
	{
	}
}

