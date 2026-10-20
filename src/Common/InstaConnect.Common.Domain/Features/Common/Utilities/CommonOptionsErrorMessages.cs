namespace InstaConnect.Common.Domain.Features.Common.Utilities;

public static class CommonOptionsErrorMessages
{
	public static string GetInvalid(string sectionName, IReadOnlyCollection<string> errorMessages)
	{
		const string Format = "{0} is invalid: {1}";

		return Format.FormatCurrentCulture(sectionName, errorMessages.JoinWithSpace());
	}
}
