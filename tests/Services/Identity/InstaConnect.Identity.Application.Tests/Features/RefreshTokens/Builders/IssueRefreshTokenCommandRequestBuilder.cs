namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Builders;

public class IssueRefreshTokenCommandRequestBuilder
{
	private string _name;
	private string _password;

	public IssueRefreshTokenCommandRequestBuilder(User user, string password)
	{
		_name = user.Name.Value;
		_password = password;
	}

	public IssueRefreshTokenCommandRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public IssueRefreshTokenCommandRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public IssueRefreshTokenCommandRequestBuilder WithPassword(IStringTransformer transformer)
	{
		_password = transformer.Transform(_password);

		return this;
	}

	public IssueRefreshTokenCommandRequest Build()
	{
		return new(_name, _password);
	}
}
