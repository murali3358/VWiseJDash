//using IpPublicKnowledge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Captain
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // System.Web.HttpContext context = System.Web.HttpContext.Current;
           // string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

           // string ip = "Main Address" + ipAddress;//System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

           // ip = ip + ", Local Addres" + System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

           // if (System.Web.HttpContext.Current.Request.UserHostAddress != null)
           // {
           //     ip = ip + ", HostAddress" + System.Web.HttpContext.Current.Request.UserHostAddress;

           // }

           // ip = ip + ", Client Ip" + System.Web.HttpContext.Current.Request.Params["HTTP_CLIENT_IP"] ?? System.Web.HttpContext.Current.Request.UserHostAddress;

           //string   externalIP = (new WebClient() { Proxy = null }).DownloadString("http://checkip.dyndns.org/");
           // Response.Write(ip + "download proxy" + externalIP);
            
           // var ip123 = IPK.GetMyPublicIp();

           // //Get all IP infos
           // var IPinfo = IPK.GetIpInfo(ip123);

           // //print some info
           // Response.Write("*--------------------------- IPK -----------------------------*");

           // Response.Write("My public IP : " + IPinfo.IP);

           // Response.Write("My ISP : " + IPinfo.isp);

           // Response.Write("My Country : " + IPinfo.country);

           // Response.Write("My Languages : ");

           // foreach (var lang in IPinfo.languages)
           // {
           //     Response.Write(" " + lang.Key + " : " + lang.Value);
           // }


            Response.Redirect("~/MainForm.wgx");


        }
    }
}