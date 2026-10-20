namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

public class UserClaimIncludeBuilder
{
	private readonly ICollection<IdentityIncludeDescriptor> _descriptors;
	private readonly IUserClaimIncludeDescriptorFactory _descriptorsFactory;

	public UserClaimIncludeBuilder(
		ICollection<IdentityIncludeDescriptor> descriptors,
		IUserClaimIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}
	public UserClaimIncludeBuilder WithUser()
	{
		_descriptors.Add(_descriptorsFactory.CreateUser());

		return this;
	}

	public UserClaimIncludeBuilder WithUser(UserInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateUser());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserClaimInclude Build()
	{
		return new(_descriptors);
	}
}
