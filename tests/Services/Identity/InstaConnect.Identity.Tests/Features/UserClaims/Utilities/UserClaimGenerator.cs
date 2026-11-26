namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimGenerator
{
	extension(UserClaim baseUserClaim)
	{
		public ICollection<UserClaim> GenerateAttached(IEnumerable<User> users)
		{
			var userClaims = baseUserClaim.Generate(users);

			foreach (var userClaim in userClaims.Where(u => u != baseUserClaim))
			{
				userClaim.User!.AddUserClaim(userClaim);
			}

			return userClaims;
		}

		public ICollection<UserClaim> Generate(IEnumerable<User> users)
		{
			return [.. users
			   .Select(user =>
					   {
						   var userClaim = new UserClaim(
							   new(user.Id, UserClaimDataFaker.GetClaim()),
							   UserClaimDataFaker.GetCreatedAtUtc());

						   if(baseUserClaim.Id == userClaim.Id)
						   {
							   return baseUserClaim;
						   }

						   userClaim.AddUser(user);

						   return userClaim;
					   })];
		}
	}
}
