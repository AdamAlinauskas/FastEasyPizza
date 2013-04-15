using DataAccess;

namespace Service
{
    public interface IUnitOfWork
    {
        void Start();
        void End();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseUnitOfWork databaseUnitOfWork;

        public UnitOfWork(IDatabaseUnitOfWork databaseUnitOfWork)
        {
            this.databaseUnitOfWork = databaseUnitOfWork;
        }

        public void Start()
        {
            databaseUnitOfWork.Start();
        }

        public void End()
        {
            databaseUnitOfWork.End();
        }
    }
}