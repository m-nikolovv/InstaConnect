namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowPageTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
	public FollowPageTooSmallDataAttribute()
		: base(FollowConfigurations.PageMinValue)
	{
	}
}

