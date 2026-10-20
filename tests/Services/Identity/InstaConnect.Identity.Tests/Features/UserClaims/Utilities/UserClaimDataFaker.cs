namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimDataFaker
{
	public static ApplicationClaims GetClaim()
	{
		const ApplicationClaims Claim = ApplicationClaims.Admin;

		return Claim;
	}

	public static DateTimeOffset GetCreatedAtUtc()
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

	public static UserClaimsSortTerm GetSortTerm()
	{
		const UserClaimsSortTerm SortTerm = UserClaimsSortTerm.ByCreatedAt;

		return SortTerm;
	}
}
