namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Builders;

public class IssueRefreshTokenApiRequestBuilder
{
	private string _name;
	private string _password;

	public IssueRefreshTokenApiRequestBuilder(User user, string password)
	{
		_name = user.Name.Value;
		_password = password;
	}

	public IssueRefreshTokenApiRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public IssueRefreshTokenApiRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public IssueRefreshTokenApiRequestBuilder WithPassword(IStringTransformer transformer)
	{
		_password = transformer.Transform(_password);

		return this;
	}

	public IssueRefreshTokenApiRequest Build()
	{
		return new(_name, new(_password));
	}
}
