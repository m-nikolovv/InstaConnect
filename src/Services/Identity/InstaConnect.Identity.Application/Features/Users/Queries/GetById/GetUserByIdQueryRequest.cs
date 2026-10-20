namespace InstaConnect.Identity.Application.Features.Users.Queries.GetById;

public record GetUserByIdQueryRequest(
	string Id,
	string CurrentId) : IQueryRequest<GetUserByIdQueryResponse>, ICurrentUserableQueryRequest;
