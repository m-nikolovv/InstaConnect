using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Builders;

public class PostBuilder
{
	private string _id;
	private readonly string _title;
	private readonly string _content;
	private readonly string _summary;
	private readonly string _userId;
	private readonly User _user;
	private readonly DateTimeOffset _createdAtUtc;
	private readonly DateTimeOffset _updatedAtUtc;

	public PostBuilder(User user)
	{
		_id = PostDataFaker.GetId();
		_userId = user.Id.Id;
		_user = user;
		_title = PostDataFaker.GetTitle();
		_content = PostDataFaker.GetContent();
		_summary = PostDataFaker.GetSummary();
		_createdAtUtc = PostDataFaker.GetCreatedAtUtc();
		_updatedAtUtc = _createdAtUtc;
	}

	public PostBuilder WithId(PostId id)
	{
		_id = id.Id;

		return this;
	}

	public Post Build()
	{
		var post = new Post(
				new(_id),
				_title,
				_content,
				new(_summary),
				new(_userId),
				_createdAtUtc,
				_updatedAtUtc);

		post.AddUser(_user);
		_user.AddPost(post);

		return post;
	}
}
