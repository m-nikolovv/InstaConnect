using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenFluent : IMongoDbFluent<EmailConfirmationToken>
{
	public IEmailConfirmationTokenFluent Match(EmailConfirmationTokenId filter);
	public IEmailConfirmationTokenFluent Match(IEnumerable<EmailConfirmationTokenId> filter);
	public IEmailConfirmationTokenFluent ApplyIncludes(EmailConfirmationTokenInclude include);
}
