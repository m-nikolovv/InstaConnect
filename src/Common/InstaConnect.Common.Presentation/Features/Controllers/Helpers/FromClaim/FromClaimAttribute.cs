namespace InstaConnect.Common.Presentation.Features.Controllers.Helpers.FromClaim;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
public abstract class FromClaimAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
{
	protected FromClaimAttribute(string name)
	{
		Name = name;
	}

	public BindingSource BindingSource => FromClaimBindingSource.Claim;

	public string Name { get; }
}
