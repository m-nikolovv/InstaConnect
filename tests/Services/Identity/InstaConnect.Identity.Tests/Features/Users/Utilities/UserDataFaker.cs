using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserDataFaker
{
	public static string GetId()
	{
		return DataFaker.GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength);
	}

	public static string GetName()
	{
		return DataFaker.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
	}

	public static string GetNameWithPrefix(string name)
	{
		return DataFaker.GetAverageWithPrefixString(name, UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
	}

	public static string GetFirstName()
	{
		return DataFaker.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength);
	}

	public static string GetFirstNameWithPrefix(string firstName)
	{
		return DataFaker.GetAverageWithPrefixString(firstName, UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
	}

	public static string GetLastName()
	{
		return DataFaker.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength);
	}

	public static string GetLastNameWithPrefix(string lastName)
	{
		return DataFaker.GetAverageWithPrefixString(lastName, UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
	}

	public static string GetEmail()
	{
		return DataFaker.GetEmail(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength);
	}

	public static string GetEmailWithPrefix(string email)
	{
		return DataFaker.GetAverageWithPrefixString(email, UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
	}

	public static string GetPassword()
	{
		return DataFaker.GetAverageString(UserConfigurations.PasswordMinLength, UserConfigurations.PasswordMaxLength);
	}

	public static bool GetIsEmailConfirmed()
	{
		const bool IsEmailConfirmed = true;

		return IsEmailConfirmed;
	}

	public static IFormFile GetProfileImage()
	{
		return DataFaker.GetAverageFormFile(UserConfigurations.ProfileImageMaxSize);
	}

	public static string GetProfileImageUrl()
	{
		return DataFaker.GetUrl();
	}

	public static DateTimeOffset GetCreatedAtUtc()
	{
		return DataFaker.GetSoonDate();
	}

	public static DateTimeOffset GetUpdatedAtUtc()
	{
		return DataFaker.GetSoonDate();
	}

	public static int GetPage()
	{
		const int Page = 1;

		return Page;
	}

	public static int GetPageSize()
	{
		const int PageSize = 20;

		return PageSize;
	}

	public static UsersSortTerm GetSortTerm()
	{
		const UsersSortTerm SortTerm = UsersSortTerm.ByCreatedAt;

		return SortTerm;
	}
}
