using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebAPIProducts.ConstantsWebApi
{
  public static class Constants
  {
    public static class ErrorMessages
    {
      public const string GeneralError = "Error";
    }
    public static class SuccessMessages
    {
      public const string Success = "Succesfully";
    }
    public static class Configs
    {
      public const string enableCorsUrls = "https://fdasystems.github.io,http://localhost:4200";
      public const string enableCorsHeaders = "*";
      public const string enableCorsMethods = "*";
      public const string enableCorsExposedHeaders = "*";
      public const string enableCorsExposedHeadersXPagination = "X-Pagination";
      public const string enableCorsExposedHeadersXMessage = "X-Message";
    }
  }
}
