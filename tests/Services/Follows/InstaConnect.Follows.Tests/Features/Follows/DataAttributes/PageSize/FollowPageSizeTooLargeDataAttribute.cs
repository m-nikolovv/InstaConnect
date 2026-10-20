namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowPageSizeTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public FollowPageSizeTooLargeDataAttribute()
		: base(FollowConfigurations.PageSizeMaxValue)
	{
	}
}

