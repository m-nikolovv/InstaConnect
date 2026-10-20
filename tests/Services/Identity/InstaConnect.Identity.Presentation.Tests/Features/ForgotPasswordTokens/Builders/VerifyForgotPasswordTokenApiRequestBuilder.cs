using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Builders;

public class VerifyForgotPasswordTokenApiRequestBuilder
{
	private string _id;
	private string _value;
	private string _password;
	private string _confirmPassword;

	public VerifyForgotPasswordTokenApiRequestBuilder(ForgotPasswordToken forgotPasswordToken)
	{
		_id = forgotPasswordToken.Id.Id.Id;
		_value = forgotPasswordToken.Id.Value;
		_password = UserDataFaker.GetPassword();
		_confirmPassword = _password;
	}

	public VerifyForgotPasswordTokenApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public VerifyForgotPasswordTokenApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public VerifyForgotPasswordTokenApiRequestBuilder WithValue(IStringTransformer transformer)
	{
		_value = transformer.Transform(_value);

		return this;
	}

	public VerifyForgotPasswordTokenApiRequestBuilder WithPassword(IStringTransformer transformer)
	{
		_password = transformer.Transform(_password);
		_confirmPassword = _password;

		return this;
	}

	public VerifyForgotPasswordTokenApiRequestBuilder WithConfirmPassword(IStringTransformer transformer)
	{
		_confirmPassword = transformer.Transform(_confirmPassword);

		return this;
	}

	public VerifyForgotPasswordTokenApiRequest Build()
	{
		return new(_id, _value, new(_password, _confirmPassword));
	}
}
