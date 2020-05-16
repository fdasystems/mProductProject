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
      public const string enableCorsUrls = "http://localhost:4200,https://fdasystems.github.io,http://www.sisistemas.com.ar,https://www.sisistemas.com.ar"; //"*"; // TEMP CONFIG THEN ENABLE ONLY NEED // "https://fdasystems.github.io,http://www.sisistemas.com.ar,http://localhost:4200"; //http://localhost:4200,
      public const string enableCorsHeaders = "*";
      public const string enableCorsMethods = "*";
      public const string enableCorsExposedHeaders = "X-Pagination,X-Message";  //*
      public const string enableCorsExposedHeadersXPagination = "X-Pagination";
      public const string enableCorsExposedHeadersXMessage = "X-Message";
    }
  }
}
