using NHibernate;

namespace DataAccess
{
    public interface IDatabaseUnitOfWork
    {
        void Start();
        void End();
        ISession Session { get;}
    }

    public class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {
        private readonly IDatabaseSessionFactory databaseSessionFactory;
        private ITransaction transaction;
        public ISession Session { get; private set; }

        public DatabaseUnitOfWork(IDatabaseSessionFactory databaseSessionFactory)
        {
            this.databaseSessionFactory = databaseSessionFactory;
        }

        public void Start()
        {
            Session = databaseSessionFactory.Create();
            transaction = Session.BeginTransaction();
        }

        public void End()
        {
            Session.Flush();
            transaction.Commit();
            transaction.Dispose();
            Session.Close();
            Session.Dispose();
        }
    }
}