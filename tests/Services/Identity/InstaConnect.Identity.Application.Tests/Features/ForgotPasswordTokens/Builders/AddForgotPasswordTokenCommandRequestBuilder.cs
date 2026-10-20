namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Builders;

public class AddForgotPasswordTokenCommandRequestBuilder
{
	private string _name;

	public AddForgotPasswordTokenCommandRequestBuilder(User user)
	{
		_name = user.Name.Value;
	}

	public AddForgotPasswordTokenCommandRequestBuilder WithName(Name name, IStringTransformer? transformer = null)
	{
		_name = transformer.TryTransform(name.Value);

		return this;
	}

	public AddForgotPasswordTokenCommandRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public AddForgotPasswordTokenCommandRequest Build()
	{
		return new(_name);
	}
}
