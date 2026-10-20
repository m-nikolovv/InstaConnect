using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Builders;

public class UsersFilterQueryBuilder
{
	private string _name;
	private string _firstName;
	private string _lastName;

	public UsersFilterQueryBuilder(User user)
	{
		_name = DataFaker.GetPrefixString(user.Name.Value);
		_firstName = DataFaker.GetPrefixString(user.FirstName);
		_lastName = DataFaker.GetPrefixString(user.LastName);
	}

	public UsersFilterQueryBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public UsersFilterQueryBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public UsersFilterQueryBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public UsersFilterQuery Build()
	{
		return new(_firstName, _lastName, new(_name));
	}
}
