namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowPageTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public FollowPageTooLargeDataAttribute()
		: base(FollowConfigurations.PageMaxValue)
	{
	}
}

