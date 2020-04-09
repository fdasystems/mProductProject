using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebAPIProducts.Entities.Model
{
  public class EmailModel
  {
    //Set primary data
    public string From { get; set; }
    public string AliasFrom { get; set; }
    //Basic info to send mail
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public EmailModel(string fromEmail, string aliasFromEmail = "FDA SINCE API")
    {
      this.From = fromEmail;
      this.AliasFrom = aliasFromEmail; 
    }

  }
}
