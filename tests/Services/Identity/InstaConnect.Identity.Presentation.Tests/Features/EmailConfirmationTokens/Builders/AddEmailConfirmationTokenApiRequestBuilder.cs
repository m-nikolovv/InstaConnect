namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Builders;

public class AddEmailConfirmationTokenApiRequestBuilder
{
	private string _name;

	public AddEmailConfirmationTokenApiRequestBuilder(User user)
	{
		_name = user.Name.Value;
	}

	public AddEmailConfirmationTokenApiRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public AddEmailConfirmationTokenApiRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public AddEmailConfirmationTokenApiRequest Build()
	{
		return new(_name);
	}
}
