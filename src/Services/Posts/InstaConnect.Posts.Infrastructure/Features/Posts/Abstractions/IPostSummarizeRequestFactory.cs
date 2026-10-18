using Microsoft.Extensions.AI;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostSummarizeRequestFactory
{
	public ChatMessage Create(Post post);
}
