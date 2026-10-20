namespace InstaConnect.Common.Presentation.Features.Controllers.Helpers.FromCookie;

public class FromCookieValueProviderFactory : IValueProviderFactory
{
	public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
	{
		var cookies = context.ActionContext.HttpContext.Request.Cookies;

		context.ValueProviders.Add(new FromCookieValueProvider(FromCookieBindingSource.Instance, cookies));

		return Task.CompletedTask;
	}
}
