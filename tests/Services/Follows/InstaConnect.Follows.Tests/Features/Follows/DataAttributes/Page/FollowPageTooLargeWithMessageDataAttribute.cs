using InstaConnect.Common.Tests.Features.DataAttributes.Ints.TooLarge;

namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowPageTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
	public FollowPageTooLargeWithMessageDataAttribute()
		: base(FollowConfigurations.PageMaxValue)
	{
	}
}

