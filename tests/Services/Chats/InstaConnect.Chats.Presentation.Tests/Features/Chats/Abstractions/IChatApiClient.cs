namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Abstractions;

public interface IChatApiClient
{
	public Task<AddChatApiResponse> AddAsync(AddChatApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> AddProblemDetailsAsync(AddChatApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(AddChatApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> AddStatusCodeAsync(AddChatApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(AddChatApiRequest request, CancellationToken cancellationToken);

	public Task<GetAllChatsApiResponse> GetAllAsync(GetAllChatsApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(GetAllChatsApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllChatsApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> GetAllUnauthorizedStatusCodeAsync(GetAllChatsApiRequest request, CancellationToken cancellationToken);

	public Task<GetChatByIdApiResponse> GetByIdAsync(GetChatByIdApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(GetChatByIdApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> GetByIdStatusCodeAsync(GetChatByIdApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> GetByIdUnauthorizedStatusCodeAsync(GetChatByIdApiRequest request, CancellationToken cancellationToken);
}
