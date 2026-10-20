namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Builders;

public class AddEmailConfirmationTokenCommandRequestBuilder
{
	private string _name;

	public AddEmailConfirmationTokenCommandRequestBuilder(User user)
	{
		_name = user.Name.Value;
	}

	public AddEmailConfirmationTokenCommandRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public AddEmailConfirmationTokenCommandRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public AddEmailConfirmationTokenCommandRequest Build()
	{
		return new(_name);
	}
}
