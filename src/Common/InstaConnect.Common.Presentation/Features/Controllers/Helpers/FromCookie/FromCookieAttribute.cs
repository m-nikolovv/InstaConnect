namespace InstaConnect.Common.Presentation.Features.Controllers.Helpers.FromCookie;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
public abstract class FromCookieAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
{
	protected FromCookieAttribute(string name)
	{
		Name = name;
	}

	public BindingSource BindingSource => FromCookieBindingSource.Instance;

	public string Name { get; }
}
