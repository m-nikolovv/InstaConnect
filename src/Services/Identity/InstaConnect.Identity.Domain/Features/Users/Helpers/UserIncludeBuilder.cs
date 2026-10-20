namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

public class UserIncludeBuilder
{
	private readonly ICollection<IdentityIncludeDescriptor> _descriptors;
	private readonly IUserIncludeDescriptorFactory _descriptorsFactory;

	public UserIncludeBuilder(
		ICollection<IdentityIncludeDescriptor> descriptors,
		IUserIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}
	public UserIncludeBuilder WithUserClaims()
	{
		_descriptors.Add(_descriptorsFactory.CreateUserClaims());

		return this;
	}

	public UserIncludeBuilder WithUserClaims(UserClaimInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateUserClaims());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}
	public UserIncludeBuilder WithRefreshTokens()
	{
		_descriptors.Add(_descriptorsFactory.CreateRefreshTokens());

		return this;
	}

	public UserIncludeBuilder WithRefreshTokens(RefreshTokenInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateRefreshTokens());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserIncludeBuilder WithForgotPasswordTokens()
	{
		_descriptors.Add(_descriptorsFactory.CreateForgotPasswordTokens());

		return this;
	}

	public UserIncludeBuilder WithForgotPasswordTokens(ForgotPasswordTokenInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateForgotPasswordTokens());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserIncludeBuilder WithEmailConfirmationTokens()
	{
		_descriptors.Add(_descriptorsFactory.CreateEmailConfirmationTokens());

		return this;
	}

	public UserIncludeBuilder WithEmailConfirmationTokens(EmailConfirmationTokenInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateEmailConfirmationTokens());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserInclude Build()
	{
		return new(_descriptors);
	}
}
