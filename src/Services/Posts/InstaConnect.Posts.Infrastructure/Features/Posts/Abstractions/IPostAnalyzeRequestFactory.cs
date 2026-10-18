using Microsoft.Extensions.AI;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostAnalyzeRequestFactory
{
	public ChatMessage Create(PostResponse post);
}
