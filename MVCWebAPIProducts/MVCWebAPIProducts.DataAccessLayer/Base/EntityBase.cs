using MVCWebAPIProducts.Entities.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.DataAccessLayer.Base
{
  public class EntityBase
  {
    protected SiSistemasDEMOEntities db = new SiSistemasDEMOEntities(GenerateConnectionStringEntity(ConstantsDAL.Constants.DbName));
    public static string GenerateConnectionStringEntity(string connEntity)
    {
      string connBasic = string.Empty;   

      // Initialize the SqlConnectionStringBuilder.  
      string dbServer = string.Empty;
      string dbName = string.Empty;
      // use it from previously built normal connection string      
      string connectString = Convert.ToString(ConfigurationManager.ConnectionStrings[connEntity]);
      var sqlBuilder = new SqlConnectionStringBuilder(connectString);
      // Set the properties for the data source.  
      dbServer = sqlBuilder.DataSource;
      dbName = sqlBuilder.InitialCatalog;
      sqlBuilder.IntegratedSecurity = false;
      sqlBuilder.MultipleActiveResultSets = true;
      // Build the SqlConnection connection string.  
      string providerString = Convert.ToString(sqlBuilder);
      // Initialize the EntityConnectionStringBuilder.  
      var entityBuilder = new EntityConnectionStringBuilder();
      //Set the provider name.  
      entityBuilder.Provider = "System.Data.SqlClient";
      // Set the provider-specific connection string.  
      entityBuilder.ProviderConnectionString = providerString;
      // Set the Metadata location.
      entityBuilder.Metadata = "res://*/Data.ModelMProductProject.csdl|res://*/Data.ModelMProductProject.ssdl|res://*/Data.ModelMProductProject.msl";

      return entityBuilder.ToString();
    }


  }
}
