using System.Linq.Expressions;

using FluentAssertions;

namespace InstaConnect.Common.Tests.Features.Assertions;

public static class MatchAssertions
{
	extension<T>(T obj)
	{
		public void ShouldSatisfy(Expression<Func<T, bool>> predicate)
		{
			obj.Should().Match(predicate);
		}

		public void ShouldBeNull()
		{
			obj.Should().BeNull();
		}

		public void ShouldBe(T value)
		{
			obj.Should().Be(value);
		}
	}

	extension(bool obj)
	{
		public void ShouldBeTrue()
		{
			obj.Should().Be(true);
		}

		public void ShouldBeFalse()
		{
			obj.Should().Be(false);
		}
	}

	extension<T>(IEnumerable<T> obj)
	{
		public void ShouldContain(Expression<Func<T, bool>> predicate)
		{
			obj.Should().Contain(predicate);
		}

		public void ShouldBeEmpty()
		{
			obj.Should().BeEmpty();
		}
	}
}
