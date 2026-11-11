namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;

public record GetCurrentUserByIdQueryRequest(string CurrentId) : IQueryRequest<GetCurrentUserByIdQueryResponse>, ICurrentUserableQueryRequest;
