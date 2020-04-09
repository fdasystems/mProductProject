using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Services.ConstantsServices
{
  public static class Constants
  {
    public static class ApiErrorMessages
    {
      public const string SendgridError = "Error while send via Sendgrid service";
    }
      public static class ApiContactConfigs
    {
      public const string SmtpClient = "API_SMTPCLIENT";
      public const string SmtpPort = "API_SMTPPORT";
      public const string SmtpEnableSSL = "API_SMTPENABLESSL";
      public const string SmtpDefaultCredentials = "API_SMTPDEFAULTCREDENTIALS";
      public const string SmtpUser = "API_SMTPUSER";
      public const string SmtpPassword = "API_SMTPPASSWORD";
      public const string SendgridKey = "API_SENDGRID_KEY";
      public const string AliasFrom = "FDA SINCE API SENDGRID"; //default change then when user pass details data
    }


  }
}
