using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


/// <summary>
/// Summary description for Helper
/// </summary>
public static class HelperNotify
{
   

     public enum NotificationType{
         success, info, error
    }
    public static string  HelperMessage(string title, string message,NotificationType type)
    {
        StringBuilder build = new StringBuilder();
        build.AppendFormat(@"<script type=""text/javascript"">");
        build.AppendFormat("$.pnotify({{title: '{0}',text: '{1}' ,type: '{2}' }});", title, message,type);
        build.AppendFormat("</script>");
        return build.ToString();
    }
}