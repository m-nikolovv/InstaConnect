namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

public class RefreshTokenIncludeBuilder
{
	private readonly ICollection<IdentityIncludeDescriptor> _descriptors;
	private readonly IRefreshTokenIncludeDescriptorFactory _descriptorsFactory;

	public RefreshTokenIncludeBuilder(
		ICollection<IdentityIncludeDescriptor> descriptors,
		IRefreshTokenIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}
	public RefreshTokenIncludeBuilder WithUser()
	{
		_descriptors.Add(_descriptorsFactory.CreateUser());

		return this;
	}

	public RefreshTokenIncludeBuilder WithUser(UserInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateUser());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public RefreshTokenInclude Build()
	{
		return new(_descriptors);
	}
}
