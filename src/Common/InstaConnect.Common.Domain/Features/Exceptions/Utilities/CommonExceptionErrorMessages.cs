using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Common.Domain.Features.Exceptions.Utilities;

public static class CommonExceptionErrorMessages
{
	public static string GetInvalidValidation()
	{
		const string Message = "One or more validation errors occured.";

		return Message;
	}

	public static string GetSortOrderEmpty()
	{
		const string Message = "Sort order must not be empty.";

		return Message;
	}

	public static string GetSortOrderNotSupportedMessage(CommonSortOrder sortOrder)
	{
		const string Format = "SortOrder(type: {0}) is not supported";

		return Format.FormatCurrentCulture(sortOrder);
	}
}
