//namespace Cedar.WebPortal.Data
//{
//    using System;
//    using System.Configuration;
//    using System.Data.Entity;
//    using System.Data.Entity.Infrastructure;
//    using System.Data.Entity.ModelConfiguration;
//    using System.Data.SqlClient;
//    using System.IO;
//
//    public class CustomDatabaseInitializer<T> : IDatabaseInitializer<T>
//        where T : DbContext
//    {
//
//        #region Constants and Fields
//
//        private const string DatabasePath = "DatabasePath";
//
//        #endregion
//
//        #region Implemented Interfaces
//
//        #region IDatabaseInitializer<T>
//
//        public void InitializeDatabase(T context)
//        {
//            if (!context.Database.Exists())
//            {
//                string databaseScript = this.DatabaseScript();
//
//                string tablesScript = this.TablesScript(context);
//
//                databaseScript = databaseScript.Replace(
//                    "@" + DatabasePath, ConfigurationManager.AppSettings[DatabasePath]);
//
//                this.ExecuteQueryByScript(context, databaseScript);
//                context.Database.ExecuteSqlCommand(tablesScript);
//
//                this.InitializeData(context);
//            }
//            if (!context.Database.CompatibleWithModel(false))
//            {
//                throw new ModelValidationException();
//            }
//        }
//
//        #endregion
//
//        #endregion
//
//        #region Methods
//
//        private string DatabaseScript()
//        {
//            string combinePath = Path.Combine(ConfigurationManager.AppSettings[DatabasePath], "Script\\");
//            return File.ReadAllText(combinePath + "InstallDatabase.sql") +
//                   File.ReadAllText(combinePath + "InstallCommon.sql") +
//                   File.ReadAllText(combinePath + "InstallMembership.sql") +
//                   File.ReadAllText(combinePath + "InstallRoles.sql");
//        }
//
//        private void ExecuteQueryByScript(T context, string script)
//        {
//            using (
//                var connection =
//                    new SqlConnection(context.Database.Connection.ConnectionString.Replace("Cedar", "master")))
//            {
//                string[] commands = (script).Split(
//                    new[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
//                connection.Open();
//                SqlCommand sqlCommand = connection.CreateCommand();
//                foreach (string command in commands)
//                {
//                    sqlCommand.CommandText = command;
//                    sqlCommand.ExecuteNonQuery();
//                }
//                connection.Close();
//            }
//        }
//
//        private void InitializeData(T context)
//        {
//            context.Database.ExecuteSqlCommand(
//                @"insert into location (LocationId, province) values('" + Guid.NewGuid() + "', N'استان1')");
//            context.Database.ExecuteSqlCommand(
//                @"insert into location (LocationId, province) values('" + Guid.NewGuid() + "', N'استان2')");
//            context.Database.ExecuteSqlCommand(
//                @"insert into location (LocationId, province) values('" + Guid.NewGuid() + "', N'استان3')");
//
//            
//        }
//
//        private string TablesScript(T context)
//        {
//            IObjectContextAdapter adapter = context;
//            string tablesScript = adapter.ObjectContext.CreateDatabaseScript();
//            tablesScript = tablesScript.Replace("[varbinary](max)", "[varbinary](max) FILESTREAM");
//            tablesScript = tablesScript.Replace(
//                "[AttachmentId] [uniqueidentifier] not null",
//                "[AttachmentId] [uniqueidentifier] not null ROWGUIDCOL default NEWSEQUENTIALID()");
//            return tablesScript;
//        }
//
//        #endregion
//    }
//}