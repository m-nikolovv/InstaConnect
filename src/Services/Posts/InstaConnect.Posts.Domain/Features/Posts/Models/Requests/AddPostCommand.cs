using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record AddPostCommand(UserId UserId, string Title, string Content, ICollection<IFormFile> Images);
