namespace InstaConnect.Follows.Domain.Features.Users.Models.Entities;

public class User : IEntityWithId<UserId>
{
	private User()
	{
		Id = new(string.Empty);
		FirstName = string.Empty;
		LastName = string.Empty;
		Email = new(string.Empty);
		Name = new(string.Empty);
		FollowFollowers = [];
		FollowFollowings = [];
	}

	public User(
		UserId id,
		string firstName,
		string lastName,
		Email email,
		Name name,
		Url? profileImageUrl,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Name = name;
		ProfileImageUrl = profileImageUrl;
		FollowFollowers = [];
		FollowFollowings = [];
		CreatedAtUtc = createdAtUtc;
		UpdatedAtUtc = updatedAtUtc;
	}

	public UserId Id { get; }

	public string FirstName { get; private set; }

	public string LastName { get; private set; }

	public Email Email { get; private set; }

	public Name Name { get; private set; }

	public Url? ProfileImageUrl { get; private set; }

	public ICollection<Follow> FollowFollowers { get; private set; }

	public ICollection<Follow> FollowFollowings { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public DateTimeOffset UpdatedAtUtc { get; private set; }

	public void Update(
		Email email,
		string firstName,
		string lastName,
		Name name,
		Url? profileImageUrl,
		DateTimeOffset updatedAtUtc)
	{
		Email = email;
		FirstName = firstName;
		LastName = lastName;
		Name = name;
		ProfileImageUrl = profileImageUrl;
		UpdatedAtUtc = updatedAtUtc;
	}

	public User AddFollowFollower(Follow followFollower)
	{
		FollowFollowers.Add(followFollower);

		return this;
	}

	public User AddFollowFollowers(ICollection<Follow> followFollowers)
	{
		FollowFollowers.AddRange(followFollowers);

		return this;
	}

	public User AddFollowFollowing(Follow followFollowing)
	{
		FollowFollowings.Add(followFollowing);

		return this;
	}

	public User AddFollowFollowings(ICollection<Follow> followFollowings)
	{
		FollowFollowings.AddRange(followFollowings);

		return this;
	}
}


