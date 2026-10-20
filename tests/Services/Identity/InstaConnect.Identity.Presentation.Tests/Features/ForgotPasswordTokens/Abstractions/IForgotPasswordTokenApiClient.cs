namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenApiClient
{
	public Task AddAsync(AddForgotPasswordTokenApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> AddProblemDetailsAsync(AddForgotPasswordTokenApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> AddStatusCodeAsync(AddForgotPasswordTokenApiRequest request, CancellationToken cancellationToken);

	public Task VerifyAsync(VerifyForgotPasswordTokenApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> VerifyProblemDetailsAsync(VerifyForgotPasswordTokenApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> VerifyStatusCodeAsync(VerifyForgotPasswordTokenApiRequest request, CancellationToken cancellationToken);
}
