using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserApiResponse? response)
	{
		public bool MatchesFull(User? user)
		{
			return response != null &&
				   user != null &&
				   user.Id.Matches(response.Id) &&
				   user.FirstName == response.FirstName &&
				   user.LastName == response.LastName &&
				   user.Name.Matches(response.Name) &&
				   user.ProfileImageUrl.Matches(response.ProfileImageUrl) &&
				   user.CreatedAtUtc == response.CreatedAtUtc &&
				   user.UpdatedAtUtc == response.UpdatedAtUtc;
		}
	}

	extension<TQueryRequest>(TQueryRequest query) where TQueryRequest : ICurrentUserableQueryRequest
	{
		public bool MatchesCurrentUserable<TApiRequest>(
		TApiRequest request)
		where TApiRequest : ICurrentUserableApiRequest
		{
			return query.CurrentUserId == request.CurrentUserId;
		}
	}
}
