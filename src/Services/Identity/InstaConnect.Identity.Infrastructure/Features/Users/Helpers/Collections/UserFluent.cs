using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

internal class UserFluent : MongoDbFluent<User>, IUserFluent
{
	private readonly IUserIncluderFactory _includerFactory;
	private readonly IUserResponseFluentFactory _responseFluentFactory;

	public UserFluent(
		IAggregateFluent<User> fluent,
		IUserIncluderFactory includerFactory,
		IUserResponseFluentFactory responseFluentFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserFluent ApplyIncludes(UserInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IUserFluent Match(UsersFilterQuery filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IUserFluent Match(UserId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IUserFluent Match(Name filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IUserFluent Match(Email filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IUserResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser)
	{
		var projection = Builders<User>.Projection.Expression(
			u => new UserResponse(
				u.Id,
				u.FirstName,
				u.LastName,
				u.Email,
				u.Name,
				u.ProfileImageUrl,
				u.CreatedAtUtc,
				u.UpdatedAtUtc));
		var fluent = Project(projection);

		return _responseFluentFactory.Create(fluent);
	}
}
