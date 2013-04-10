using System;
using System.Configuration;
using System.Data.SqlServerCe;
using System.IO;
using Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DataAccess
{
    public class DatabaseSessionFactory
    {
        private ISessionFactory sessionFactory;
        private static readonly object lockObject = new object();
        private static string connectionString;

        public ISession Create()
        {
            if (sessionFactory == null)
            {
                lock (lockObject)
                {
                    if (sessionFactory == null)
                    {
                        connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
                        sessionFactory = createSessionFactory();
                    }
                }
            }

            ISession session = sessionFactory.OpenSession();
            session.FlushMode = FlushMode.Never;
            return session;
        }

        ISessionFactory createSessionFactory()
        {
            CreateDatabase();

            return  Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<IEntity>()))
                .BuildSessionFactory();
        }

        private static void CreateDatabase()
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "FastEasyPizza.sdf")))
            {
                var engine = new SqlCeEngine(connectionString);
                engine.CreateDatabase();
            }
        }
    }
}
