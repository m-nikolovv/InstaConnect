using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

public record AddPostCommentCommandRequest(string Id, string Content, string UserId, ICollection<IFormFile> Images) : ICommandRequest<AddPostCommentCommandResponse>;
