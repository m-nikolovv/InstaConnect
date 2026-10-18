using InstaConnect.Posts.Application.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.AnalyzeById;

public record AnalyzePostByIdQueryRequest(string Id, string CurrentUserId) : IQueryRequest<AnalyzePostByIdQueryResponse>, ICurrentUserableQueryRequest;
