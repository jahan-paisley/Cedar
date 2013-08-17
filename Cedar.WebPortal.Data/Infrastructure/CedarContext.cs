namespace Cedar.WebPortal.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Data.Migrations;

    public class CedarContext : DbContext, ICedarContext
    {
        #region Constants and Fields

        private const string AssemblyName = "Cedar.WebPortal.Domain";

        private const string ComplexesNamespace = "Cedar.WebPortal.Domain.ComplexTypes";

        private const string DomainNamespace = "Cedar.WebPortal.Domain.Entities";

        #endregion

        #region Constructors and Destructors

        public CedarContext()
            : base("CedarContext")
        {
        }

        #endregion

        #region Implemented Interfaces

        #region ICedarContext

        public void Commit()
        {
            try
            {
                this.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (DbValidationError validationError in
                    dbEx.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors))
                {
                    Trace.TraceInformation(
                        "Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }
        }

        public void Delete(object obj)
        {
            base.Set(obj.GetType()).Remove(obj);
        }

        public void Delete<T>(object id) where T : class, new()
        {
            var entity = new T();
            entity.SetProperty("Id", id);
            base.Set<T>().Remove(entity);
        }

        public void Delete<T>(Func<T, bool> func) where T : class
        {
            IEnumerable<T> enumerable = this.Query<T>().Where(func);
            this.Set<T>().RemoveRange(enumerable);
        }

        public T Get<T>(object id) where T : class
        {
            return this.Set<T>().Find(id);
        }

        public T GetQuery<T>(string name, Dictionary<string, object> parameters) where T : class
        {
            DbContextTransaction transaction = base.Database.BeginTransaction();
            DbRawSqlQuery<T> query = base.Database.SqlQuery<T>(name, parameters.Values.ToArray());
            transaction.Commit();
            return query.FirstOrDefault();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return this.Set<T>();
        }

        public void Save<T>(T obj) where T : class
        {
            base.Set(obj.GetType()).Add(obj);
        }

        public void Update<T>(T obj) where T : class
        {
            base.Set<T>().Attach(obj);
            base.Entry(obj).State = EntityState.Modified;
        }

        #endregion

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Assembly domainAssembly =
                AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(o => o.GetName().Name == AssemblyName);
            if (domainAssembly != null)
            {
                Type[] exportedTypes = domainAssembly.GetExportedTypes();
                IEnumerable<Type> domainClasses = exportedTypes.Where(o => o.Namespace == DomainNamespace);
                IEnumerable<Type> complexClasses = exportedTypes.Where(o => o.Namespace == ComplexesNamespace);
                domainClasses.ToList().ForEach(
                    o =>
                    {
                        MethodInfo entityMethodInfo =
                            modelBuilder.GetType().GetMethod("Entity").MakeGenericMethod(o.GetTypeInfo());
                        entityMethodInfo.Invoke(modelBuilder, null);
                    });

                modelBuilder.Properties()
                   .Where(prop => prop.Name.EndsWith("Id") && 
                       prop.PropertyType == typeof(Guid))
                   .Configure(config => config.IsKey().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));

                complexClasses.ToList().ForEach(
                    o =>
                    {
                        MethodInfo complexTypeMethodInfo =
                            modelBuilder.GetType().GetMethod("ComplexType").MakeGenericMethod(o.GetTypeInfo());
                        complexTypeMethodInfo.Invoke(modelBuilder, null);
                    });

            }
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CedarContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}