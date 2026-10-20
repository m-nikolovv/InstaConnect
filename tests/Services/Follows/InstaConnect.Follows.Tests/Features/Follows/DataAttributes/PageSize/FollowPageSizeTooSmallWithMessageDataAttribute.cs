namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowPageSizeTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
	public FollowPageSizeTooSmallWithMessageDataAttribute()
		: base(FollowConfigurations.PageSizeMinValue)
	{
	}
}
