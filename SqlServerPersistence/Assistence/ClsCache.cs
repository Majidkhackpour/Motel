using System;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using AutoMapper;
using Nito.AsyncEx;
using PacketParser.Services;

namespace SqlServerPersistence.Assistence
{
    public class ClsCache
    {
        public static string ConnectionString { get; private set; } =
            @"Data Source=.;Initial Catalog=Motel;Persist Security Info=True;";
        public static void Init(string connectionString)
        {
            ConnectionString = connectionString;
            if (!CheckConnectionString(ConnectionString)) throw new ArgumentNullException("ConnectionString Not Correct ", nameof(ConnectionString));
            var config = new MapperConfiguration(c => { c.AddProfile(new SqlProfile()); });
            Mappings.Default = new Mapper(config);
            UpdateMigration();
            AsyncContext.Run(AddDefaults.InsertDefaultDataAsync);
        }
        private static void UpdateMigration()
        {
            try
            {
                var migratorConfig = new Migrations.Configuration();
                var dbMigrator = new DbMigrator(migratorConfig);
                dbMigrator.Update();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static bool CheckConnectionString(string con)
        {
            try
            {
                var cn = new SqlConnection(con);
                cn.Open();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
    }
}
