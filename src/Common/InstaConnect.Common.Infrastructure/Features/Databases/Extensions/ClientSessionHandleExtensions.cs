namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class ClientSessionHandleExtensions
{
	extension(IClientSessionHandle? session)
	{
		public bool HasActiveTransaction()
		{
			return session != null && session.IsInTransaction;
		}

		public bool HasNoActiveTransaction()
		{
			return !session.HasActiveTransaction();
		}
	}
}
