namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowPageSizeTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
	public FollowPageSizeTooLargeWithMessageDataAttribute()
		: base(FollowConfigurations.PageSizeMaxValue)
	{
	}
}
