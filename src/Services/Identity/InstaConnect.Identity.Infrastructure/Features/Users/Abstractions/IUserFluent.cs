using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUserFluent : IMongoDbFluent<User>
{
	public IUserFluent Match(UsersFilterQuery filter);
	public IUserFluent Match(UserId filter);
	public IUserFluent Match(Name filter);
	public IUserFluent Match(Email filter);
	public IUserResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IUserFluent ApplyIncludes(UserInclude include);
}
