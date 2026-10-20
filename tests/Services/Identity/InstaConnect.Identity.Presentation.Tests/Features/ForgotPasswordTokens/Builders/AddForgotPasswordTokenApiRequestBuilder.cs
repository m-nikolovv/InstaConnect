namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Builders;

public class AddForgotPasswordTokenApiRequestBuilder
{
	private string _name;

	public AddForgotPasswordTokenApiRequestBuilder(User user)
	{
		_name = user.Name.Value;
	}

	public AddForgotPasswordTokenApiRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public AddForgotPasswordTokenApiRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public AddForgotPasswordTokenApiRequest Build()
	{
		return new(_name);
	}
}
