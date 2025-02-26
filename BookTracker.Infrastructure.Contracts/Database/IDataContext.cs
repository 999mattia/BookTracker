namespace BookTracker.Infrastructure.Contracts.Database;

public interface IDataContext
{
	int SaveChanges();
}