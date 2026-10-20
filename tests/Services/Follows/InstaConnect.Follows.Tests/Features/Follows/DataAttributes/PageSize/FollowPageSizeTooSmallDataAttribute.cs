namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowPageSizeTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
	public FollowPageSizeTooSmallDataAttribute()
		: base(FollowConfigurations.PageSizeMinValue)
	{
	}
}

