namespace InstaConnect.Common.Infrastructure.Features.Events.Utilities;

public static class CommonEventKeySelectorMessages
{
	public static string GetKey(params string[] values)
	{
		return values.JoinWithColon();
	}
}
