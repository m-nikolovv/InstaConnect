using NSubstitute;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class Matcher
{
	public static T Is<T>(Expression<Predicate<T>> predicate)
	{
		return Arg.Is(predicate);
	}

	public static T Any<T>()
	{
		return Arg.Any<T>();
	}
}
