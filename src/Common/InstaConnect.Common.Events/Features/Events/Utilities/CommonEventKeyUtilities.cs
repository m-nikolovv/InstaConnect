namespace InstaConnect.Common.Events.Features.Events.Utilities;

public static class CommonEventKeyUtilities
{
	public static string GetKey(params string[] values)
	{
		const string Seperator = ":";

		return string.Join(Seperator, values);
	}
}
