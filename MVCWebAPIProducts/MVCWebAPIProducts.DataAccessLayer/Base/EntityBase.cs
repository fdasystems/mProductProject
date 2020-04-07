using MVCWebAPIProducts.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.DataAccessLayer.Base
{
  public class EntityBase
  {
     protected SiSistemasDEMOEntities db = new SiSistemasDEMOEntities(GenerateConnectionStringEntity(Environment.GetEnvironmentVariable("SiSistemasWebEntitiesSQLSIMPLEMODE")));


    public static string GenerateConnectionStringEntity(string connectString)  //  (string connEntity)
    {
      string connBasic = string.Empty;   

      // Initialize the SqlConnectionStringBuilder.  
      string dbServer = string.Empty;
      string dbName = string.Empty;
      // use it from previously built normal connection string      // string connectString = Convert.ToString(ConfigurationManager.ConnectionStrings[connEntity]);
      var sqlBuilder = new SqlConnectionStringBuilder(connectString);
      // Set the properties for the data source.  
      dbServer = sqlBuilder.DataSource;
      dbName = sqlBuilder.InitialCatalog;         //sqlBuilder.UserID = "Database_User_ID";      //sqlBuilder.Password = "Database_User_Password";
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
      // Set the Metadata location.        //entityBuilder.Metadata = "res://*/EntityDataObjectName.csdl|res: //*/EntityDataObjectName.ssdl|res: //*/EntityDataObjectName.msl";  //@
     // entityBuilder.Metadata = "res://*/Models.ModelDBSistemasWeb.csdl|res://*/Models.ModelDBSistemasWeb.ssdl|res://*/Models.ModelDBSistemasWeb.msl"; // ";" in or out
      entityBuilder.Metadata = "res://*/Data.ModelMProductProject.csdl|res://*/Data.ModelMProductProject.ssdl|res://*/Data.ModelMProductProject.msl";

      return entityBuilder.ToString();

      /*OK*/ //connBasic = "metadata="+entityBuilder.Metadata +"; provider="+ entityBuilder.Provider + ";provider connection string=\"" + providerString + "App=EntityFramework\"";
             /*OK2*/ //connBasic = "metadata=res://*/Models.ModelDBSistemasWeb.csdl|res://*/Models.ModelDBSistemasWeb.ssdl|res://*/Models.ModelDBSistemasWeb.msl;provider=System.Data.SqlClient;provider connection string=\""+ providerString + "App=EntityFramework\"";
                     /*OK3*/ //connBasic = "metadata=res://*/Models.ModelDBSistemasWeb.csdl|res://*/Models.ModelDBSistemasWeb.ssdl|res://*/Models.ModelDBSistemasWeb.msl;provider=System.Data.SqlClient;provider connection string=\"data source="+ sqlBuilder.DataSource + ";initial catalog="+ sqlBuilder.InitialCatalog + ";persist security info=True;user id="+ sqlBuilder.UserID + ";password="+sqlBuilder.Password+";MultipleActiveResultSets=True;App=EntityFramework\"";
                             // connBasic = "metadata=res://*/Models.ModelDBSistemasWeb.csdl|res://*/Models.ModelDBSistemasWeb.ssdl|res://*/Models.ModelDBSistemasWeb.msl;provider=System.Data.SqlClient;provider connection string=\"data source=190.105.226.76\\MSSQLSERVER2017;initial catalog=SiSistemasDEMO;persist security info=True;user id=FdaSystems;password=F@vio2020!;MultipleActiveResultSets=True;App=EntityFramework\"";

      // return connBasic;
    }


  }
}
