using System;
using System.Configuration;
using System.Data.SqlServerCe;
using System.IO;
using Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace DataAccess
{
    public interface IDatabaseSessionFactory
    {
        ISession Create();
    }

    public class DatabaseSessionFactory : IDatabaseSessionFactory
    {
        private static ISessionFactory sessionFactory;
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
           // CreateDatabase();
            
            return  Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(x => x.AutoMappings.Add(
                    AutoMap.AssemblyOf<IEntity>().UseOverridesFromAssembly(typeof(DatabaseSessionFactory).Assembly)))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(NHibernate.Cfg.Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "FastEasyPizza.sdf")))
                File.Delete(Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "FastEasyPizza.sdf"));
            
            CreateDatabase();

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config).Create(true, true);
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
