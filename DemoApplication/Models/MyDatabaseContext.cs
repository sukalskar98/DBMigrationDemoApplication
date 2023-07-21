using Azure.Core;
using Azure.Identity;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.SqlClient;

namespace DemoApplication.Models
{
    public class MyDatabaseContext: DataContext
    {
        public MyDatabaseContext() : base(GetSqlConnection())
        {
            //var conn = (System.Data.SqlClient.SqlConnection)System.Data.Linq.Database.Connection;
            //var credential = new Azure.Identity.DefaultAzureCredential();
            //var token = credential.GetToken(new Azure.Core.TokenRequestContext(new[] { "https://database.windows.net/.default" }));
            //conn.AccessToken = token.Token;
        }

        //private static string BuildConnectionString()
        //{
        //    // Create the Managed Identity Credential
        //    ManagedIdentityCredential managedIdentityCredential = new ManagedIdentityCredential();



        //    // Get the access token
        //    string accessToken = managedIdentityCredential.GetToken(
        //        new Azure.Core.TokenRequestContext(new[] { "https://database.windows.net/.default" }))
        //        .Token;



        //    // Build the connection string using the access token
        //    SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
        //    {
        //        DataSource = $"demo-sql-mi.public.47980db82bea.database.windows.net",
        //        InitialCatalog = "DemoDB",
        //        ConnectTimeout = 30,
        //        Encrypt = true,
        //        TrustServerCertificate = false,
        //        UserID = "",
        //        Password = accessToken
        //    };



        //    return connectionStringBuilder.ToString();
        //}

        public static IDbConnection GetSqlConnection()

        {

            // Set the Azure SQL Managed Instance resource ID

            string resource = "https://database.windows.net/";



            // Use DefaultAzureCredential to get the access token

            var defaultCredential = new DefaultAzureCredential();

            var accessToken = defaultCredential.GetToken(new Azure.Core.TokenRequestContext(new[] { resource })).Token;



            // Replace "YOUR_CONNECTION_STRING" with your Azure SQL Managed Instance connection string

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder("Server=<ServerName>;Initial Catalog=<DBName>;")

            {

                //AccessToken = accessToken

            };

            var conn = new SqlConnection(builder.ConnectionString);
            conn.AccessToken = accessToken;

            // Create and return the SqlConnection object

            return conn;

        }
    }
}