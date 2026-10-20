namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenIncludeBuilder
{
	private readonly ICollection<IdentityIncludeDescriptor> _descriptors;
	private readonly IEmailConfirmationTokenIncludeDescriptorFactory _descriptorsFactory;

	public EmailConfirmationTokenIncludeBuilder(
		ICollection<IdentityIncludeDescriptor> descriptors,
		IEmailConfirmationTokenIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}
	public EmailConfirmationTokenIncludeBuilder WithUser()
	{
		_descriptors.Add(_descriptorsFactory.CreateUser());

		return this;
	}

	public EmailConfirmationTokenIncludeBuilder WithUser(UserInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateUser());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public EmailConfirmationTokenInclude Build()
	{
		return new(_descriptors);
	}
}
