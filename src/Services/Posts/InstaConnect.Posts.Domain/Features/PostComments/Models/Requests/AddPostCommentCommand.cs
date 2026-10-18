using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record AddPostCommentCommand(
	PostId Id,
	string Content,
	UserId UserId,
	ICollection<IFormFile> Images);
