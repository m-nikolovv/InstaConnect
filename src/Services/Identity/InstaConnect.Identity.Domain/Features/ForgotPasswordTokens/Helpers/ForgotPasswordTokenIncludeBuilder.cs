namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenIncludeBuilder
{
	private readonly ICollection<IdentityIncludeDescriptor> _descriptors;
	private readonly IForgotPasswordTokenIncludeDescriptorFactory _descriptorsFactory;

	public ForgotPasswordTokenIncludeBuilder(
		ICollection<IdentityIncludeDescriptor> descriptors,
		IForgotPasswordTokenIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}
	public ForgotPasswordTokenIncludeBuilder WithUser()
	{
		_descriptors.Add(_descriptorsFactory.CreateUser());

		return this;
	}

	public ForgotPasswordTokenIncludeBuilder WithUser(UserInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateUser());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public ForgotPasswordTokenInclude Build()
	{
		return new(_descriptors);
	}
}
