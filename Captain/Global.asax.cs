using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Captain.Common.Model.Data;

namespace Captain
{
    public class Global : System.Web.HttpApplication
    {

        public Global()
        {
            //PreRequestHandlerExecute += HandlePreRequestHandlerExecute;
            //PostRequestHandlerExecute += HandlePostRequestHandlerExecute;
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //Utilities.Network.NetworkDrive nd = new Utilities.Network.NetworkDrive();
            //nd.MapNetworkDrive(@"\\server\path", "Z:", "myuser", "mypwd");

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Context.Server.GetLastError();
            Logger.Log(sender.GetType(), "Global exception", ex);
            //if (Context.Session != null)
            //{
            //    Context.Session.Abandon();
            //}
        }

        protected void Session_End(object sender, EventArgs e)
        {
            if (Session["userlogid"] != null)
            {
                CaptainModel _model = new CaptainModel();
                _model.UserProfileAccess.InsertUpdateLogUsers(string.Empty, string.Empty, string.Empty, "Edit", Session["userlogid"].ToString());
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        //private void HandlePreRequestHandlerExecute(object sender, EventArgs e)
        //{
        //    Debug.WriteLine(DateTime.Now.ToString() + " In HandlePreRequestHandlerExecute");
        //    Debug.WriteLine(DateTime.Now.ToString() + " Finished HandlePreRequestHandlerExecute");
        //}

        //private void HandlePostRequestHandlerExecute(object sender, EventArgs e)
        //{
        //  //  Debug.WriteLine(DateTime.Now.ToString() + " In HandlePostRequestHandlerExecute");
        //    Debug.WriteLine(DateTime.Now.ToString() + " Finished HandlePostRequestHandlerExecute");
        //}
    }
}