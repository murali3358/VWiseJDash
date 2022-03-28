#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Captain.Common.Utilities;
using Captain.Common.Model.Data;
using Captain.Common.Model.Objects;
using System.IO;
using Captain.Common.Views.Forms;
using System.Net.Mail;
using System.Configuration;
#endregion

namespace Captain
{
    public partial class LoginForm : Form, ILogonForm
    {
        private ErrorProvider _errorProvider = null;
        string strFolderPath = string.Empty;
        DirectoryInfo MyDir;
        public LoginForm()
        {
            InitializeComponent();
            userProfile = null;
            timer1.Stop();
            timer1.Enabled = false;
        }

        private void LoginFormLoad(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                if (!string.IsNullOrEmpty(Context.Cookies["UserName"]))
                {
                    this.txtUserName.Text = Context.Cookies["UserName"];
                    this.chkRememberUserName.Checked = true;
                    this.txtPassword.Focus();
                }
                else
                {
                    this.txtUserName.Focus();
                }

                pnlLogin.Left = (this.Width / 2) - (pnlLogin.Width / 2);
                pnlLogin.Top = (this.Height / 2) - (pnlLogin.Height / 2);
                pnlLogin.Update();
            }
            catch (Exception ex)
            {
                //
            }
        }

        /// <summary>
        /// This method is to validate the form when login button is clicked.
        /// </summary>
        /// <returns>true/false</returns>
        private bool IsFormValid()
        {
            bool isValid = true;

            _errorProvider = new ErrorProvider();
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                _errorProvider.SetError(txtUserName, "Please Enter User ID");
                lblMessage.Text = "Please Enter User ID";
                txtUserName.Clear();
                txtUserName.Focus();
                return isValid = false;
            }
            else
            {
                _errorProvider.SetError(txtUserName, string.Empty);
                isValid = true;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                _errorProvider.SetError(txtPassword, "Please Enter Password");
                lblMessage.Text = "Please Enter Password";
                txtPassword.Clear();
                txtPassword.Focus();
                return isValid = false;
            }
            else
            {
                _errorProvider.SetError(txtPassword, string.Empty);
                isValid = true;
            }

            return isValid;
        }

        int inttimelife = 0;
        UserEntity userProfile;
        private void LoginClick(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                string userName = txtUserName.Text;
                string password = txtPassword.Text;
                string strErrorMsg = string.Empty;
                lblMessage.Text = string.Empty;
                CaptainModel model = new CaptainModel();
                try
                {

                    userProfile = model.AuthenticateUser.AuthenticateWithProfile(userName, password, string.Empty, out strErrorMsg);

                    if (userProfile != null)
                    {
                        if ((!userProfile.UserID.Equals("@InCorrect@1UID@2PSW")) && (!userProfile.UserID.Equals("@InActiveUserId")) && (int.Parse(userProfile.UnSuccessful) < 5)) //|| userProfile != null) 
                        {

                            bool isLoginRegistered = model.AuthenticateUser.RegisterLogin(userProfile.UserID);
                            bool boollogin = true;
                            if (txtPassword.Text != "******")
                            {
                                AgencyControlEntity AgencyControlDetails = model.ZipCodeAndAgency.GetAgencyControlFile("00");
                                if (AgencyControlDetails != null)
                                {
                                    if (AgencyControlDetails.LoginMFA.ToUpper() == "Y")
                                    {
                                        if (userProfile.PWDEmail.Trim() != string.Empty)
                                        {
                                            boollogin = false;
                                        }
                                    }
                                }
                                if (boollogin)
                                {
                                    Captain<string>.Session[Consts.SessionVariables.FullName] = userProfile.FirstName.Trim() + Consts.Common.Space + (userProfile.MI.Trim().Equals(string.Empty) ? string.Empty : userProfile.MI + Consts.Common.Space) + userProfile.LastName.Trim();
                                    Captain<string>.Session[Consts.SessionVariables.UserID] = userProfile.UserID.Trim();
                                    Captain<string>.Session[Consts.SessionVariables.UserName] = userProfile.UserName;

                                    Captain<string>.Session[Consts.SessionVariables.LostLogin_Status] = " Successful";
                                    Captain<string>.Session[Consts.SessionVariables.LostLogin_Date] = userProfile.LastSuccessful;
                                    if (int.Parse(userProfile.UnSuccessful) > 0)
                                    {
                                        Captain<string>.Session[Consts.SessionVariables.LostLogin_Status] = " unsuccessful";
                                        Captain<string>.Session[Consts.SessionVariables.LostLogin_Date] = userProfile.LastUnSuccessful;
                                    }

                                    Captain<UserEntity>.Session[Consts.SessionVariables.UserProfile] = userProfile;
                                    Context.Session.IsLoggedOn = true;
                                }
                                else
                                {
                                    RandomTokenNumber(6);
                                    SendEmail(userProfile.PWDEmail, proptext);

                                    lblTimerLeft.Visible = true;
                                    txtverifytext.Visible = true; lblEntertext.Visible = true; btnValidCaptcher.Visible = true;
                                    btnLogin.Enabled = false; linkresend.Visible = false; linktryanotheruser.Visible = lblOnetime.Visible = true;
                                    txtPassword.Enabled = false; txtUserName.Enabled = false;
                                    inttimelife = 1;
                                    //lblTimerLeft.Text = "60 seconds left";                                    
                                    lblOnetime.Text = "One time Text sent to your email id :" + MaskEmailfunction(userProfile.PWDEmail);
                                    timer1.Start();

                                }

                            }
                            else
                            {
                                if (userProfile.AccessAll.Equals("Y"))
                                {
                                    //Admn0004UserForm objAdmn0004 = new Admn0004UserForm(userProfile, txtUserName.Text);
                                    //objAdmn0004.ShowDialog();
                                }
                                else
                                {
                                    lblMessage.Text = "Invalid User ID/Password. Please Contact System administrator";
                                }
                            }

                            Session["usersessionid"] = Session.SessionID;
                            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                            if (string.IsNullOrEmpty(ip))
                            {
                                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                            }
                            Session["userlogid"] = model.UserProfileAccess.InsertUpdateLogUsers(userProfile.UserID, Session["usersessionid"].ToString(), ip, "Add", string.Empty);


                        }
                        else if (userProfile.UserID.Equals("@NoHierarchy"))
                        {
                            lblMessage.Text = "Sorry! you have access on no hierarchy";
                        }
                        else if (userProfile.UserID.Equals("@InActiveUserId"))
                        {
                            lblMessage.Text = "Inactivated User...Please Contact Administrator...";
                        }
                        else
                        {
                            lblMessage.Text = "Invalid User ID/Password. Please Contact System administrator";
                            if (userProfile.UserID.Equals("@InCorrect@1UID@2PSW") &&
                                (userProfile.Password.Equals("PASSWORD") || int.Parse(userProfile.UnSuccessful) > 0))
                            {
                                if (int.Parse(userProfile.UnSuccessful) < 5)
                                    lblMessage.Text = "Invalid Password. You have '" + (5 - int.Parse(userProfile.UnSuccessful)).ToString() + "' attempts Left With";
                                else
                                    lblMessage.Text = "Your Account is Blocked. Please Contact System administrator";
                            }
                        }
                        if (chkRememberUserName.Checked)
                        {
                            Context.Cookies[Consts.SessionVariables.UserName] = this.txtUserName.Text;
                        }
                        else
                        {
                            Context.Cookies[Consts.SessionVariables.UserName] = null;
                        }
                    }
                    else
                    {
                        //CommonFunctions.MessageBoxDisplay("Sqlserver is down please contact administrator");
                        CommonFunctions.MessageBoxDisplay(strErrorMsg);
                    }
                }
                catch (Exception ex)
                {
                    CommonFunctions.MessageBoxDisplay(strErrorMsg);
                }

            }
        }

        /// <summary>
        /// This event is fired when the user types enter key in password textbox.
        /// </summary>
        /// <param name="objSender"></param>
        /// <param name="objArgs"></param>
        private void PasswordEnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            LoginClick(btnLogin, EventArgs.Empty);
        }

        /// <summary>
        /// This event fires when user resizes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginFormResize(object sender, EventArgs e)
        {
            pnlLogin.Left = (this.Width / 2) - (pnlLogin.Width / 2);
            pnlLogin.Top = (this.Height / 2) - (pnlLogin.Height / 2);
            pnlLogin.Update();
        }

        private void txtPassword_GotFocus(object sender, EventArgs e)
        {
            txtPassword.SelectionLength = txtPassword.Text.Length;
        }

        private void btnValidCaptcher_Click(object sender, EventArgs e)
        {
            _errorProvider.SetError(btnValidCaptcher, null);
            if (string.IsNullOrEmpty(txtverifytext.Text))
            {
                _errorProvider.SetError(btnValidCaptcher, "Please Enter Text");
            }
            else
            {
                bool boolpagelogin = true;
                if (proptext == string.Empty)
                {
                    boolpagelogin = false;
                    if (propexptext == txtverifytext.Text)
                    {
                        CommonFunctions.MessageBoxDisplay("Text is expaired,Please Click on Resend Text link");
                        boolpagelogin = false;
                    }
                    else
                    {
                        CommonFunctions.MessageBoxDisplay("Wrong Text is entered");
                        boolpagelogin = false;
                    }
                }
                if (boolpagelogin)
                {
                    if (proptext == txtverifytext.Text)
                    {
                        timer1.Stop();
                        CaptainModel model = new CaptainModel();
                        _errorProvider.SetError(btnValidCaptcher, null);
                        bool isLoginRegistered = model.AuthenticateUser.RegisterLogin(userProfile.UserID);


                        Captain<string>.Session[Consts.SessionVariables.FullName] = userProfile.FirstName.Trim() + Consts.Common.Space + (userProfile.MI.Trim().Equals(string.Empty) ? string.Empty : userProfile.MI + Consts.Common.Space) + userProfile.LastName.Trim();
                        Captain<string>.Session[Consts.SessionVariables.UserID] = userProfile.UserID.Trim();
                        Captain<string>.Session[Consts.SessionVariables.UserName] = userProfile.UserName;

                        Captain<string>.Session[Consts.SessionVariables.LostLogin_Status] = " Successful";
                        Captain<string>.Session[Consts.SessionVariables.LostLogin_Date] = userProfile.LastSuccessful;
                        if (int.Parse(userProfile.UnSuccessful) > 0)
                        {
                            Captain<string>.Session[Consts.SessionVariables.LostLogin_Status] = " unsuccessful";
                            Captain<string>.Session[Consts.SessionVariables.LostLogin_Date] = userProfile.LastUnSuccessful;
                        }

                        Captain<UserEntity>.Session[Consts.SessionVariables.UserProfile] = userProfile;
                        Context.Session.IsLoggedOn = true;

                    }
                    else
                    {
                        CommonFunctions.MessageBoxDisplay("Wrong Text is entered");
                    }
                }
            }

        }

        #region Recapptcha
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

        }
        string proptext = string.Empty;
        string propexptext = string.Empty;
        string RandomTokenNumber(int length)
        {
            string strTokenNumber = RandomString(length);
            proptext = strTokenNumber;
            return strTokenNumber;
        }

        private void SendEmail(string emailID, string TokenNumber)
        {

            try
            {

                CaptainModel model = new CaptainModel();
                DataTable dtMailConfig = model.UserProfileAccess.GetEMailSetting("LOGINOTP");

                if (dtMailConfig.Rows.Count > 0)
                {


                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(dtMailConfig.Rows[0]["MAIL_EMAILID"].ToString());
                    mailMessage.Subject = dtMailConfig.Rows[0]["MAIL_SUBJECT"].ToString();

                    string body = dtMailConfig.Rows[0]["MAIL_CONTENT"].ToString()  + TokenNumber;
                    body = body + "<br/><br/><br/><br/><br/><br/>"+ dtMailConfig.Rows[0]["MAIL_SENDER_NAME"].ToString() +"<br/>"+ dtMailConfig.Rows[0]["MAIL_SENDER_ADDR"].ToString();
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    mailMessage.To.Add(emailID);



                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = dtMailConfig.Rows[0]["MAIL_HOST"].ToString();
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = dtMailConfig.Rows[0]["MAIL_EMAILID"].ToString();
                    NetworkCred.Password = dtMailConfig.Rows[0]["MAIL_PASSWORD"].ToString();
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(dtMailConfig.Rows[0]["MAIL_PORT"].ToString());
                    smtp.Send(mailMessage);
                }

            }
            catch (Exception ex)
            {

                //lblerrormsg.Text = ex.Message; //"email not delivered!";

                //lblerrormsg.Text = "email not delivered!";          
                //Response.Write(ex.Message);
            }




        }

        //private string createEmailBody(string userName, string message, string strAgency, string TokenNumber, DataSet dscontent)
        //{
        //    string strLanguage = "English";
        //    if (Session["language"] != null)
        //    {
        //        if (Session["language"].ToString() == "es")
        //            strLanguage = "Spanish";
        //    }
        //    DataSet ds = dscontent;//publicintakeportalDB.DatabaseLayer.Capsystems.GETLEANMESSAGES(Session["DBName"].ToString(), "INTK", strLanguage);
        //    string body = string.Empty;
        //    //using streamreader for reading my htmltemplate  
        //    if (strLanguage == "Spanish")
        //    {
        //        using (StreamReader reader = new StreamReader(Server.MapPath("~/leanapplicanttokenSpanish.html")))
        //        {
        //            body = reader.ReadToEnd();

        //        }
        //    }
        //    else
        //    {
        //        using (StreamReader reader = new StreamReader(Server.MapPath("~/leanapplicanttoken.html")))
        //        {
        //            body = reader.ReadToEnd();

        //        }
        //    }


        //    string strMainLogopath = string.Empty;
        //    string CompanyName = string.Empty;
        //    string Address = string.Empty;
        //    string City = string.Empty;
        //    string State = string.Empty;
        //    string Country = string.Empty;
        //    string Pin = string.Empty;
        //    string Message = string.Empty;
        //    string strImagurl = string.Empty;
        //    string Prefix = string.Empty;
        //    string strName = string.Empty;


        //    strMainLogopath = "http://capsystems.com/images/" + Session["DBName"].ToString().ToUpper() + "MAINLOGO.png";


        //    body = body.Replace("{imagelogo}", strMainLogopath);


        //    CompanyName = ds.Tables[0].Rows[0]["LEAN_MSG_COMPANY"].ToString();
        //    Address = ds.Tables[0].Rows[0]["LEAN_MSG_ADDRESS"].ToString();
        //    Message = ds.Tables[0].Rows[0]["LEAN_MESSAGE"].ToString();

        //    Prefix = ds.Tables[0].Rows[0]["LEAN_PREFIX"].ToString();
        //    strName = ds.Tables[0].Rows[0]["LEAN_NAME_TYPE"].ToString();
        //    City = string.Empty;
        //    State = string.Empty;
        //    Country = string.Empty;
        //    Pin = string.Empty;

        //    if (strName == "1")
        //        userName = txtLname.Text;
        //    if (strName == "2")
        //        userName = txtfname.Text;
        //    if (strName == "3")
        //        userName = txtLname.Text + ", " + txtfname.Text;
        //    if (strName == "4")
        //        userName = txtfname.Text + ", " + txtLname.Text;

        //    //replacing the required things  
        //    body = body.Replace("{Prefix}", Prefix);
        //    body = body.Replace("{Name}", userName);
        //    body = body.Replace("{token}", TokenNumber);

        //    //replacing the required things  
        //    body = body.Replace("{CompanyName}", CompanyName);
        //    body = body.Replace("{Message}", Message);
        //    // body = body.Replace("{username}", userName);           
        //    body = body.Replace("{Address}", Address);
        //    body = body.Replace("{City}", City);
        //    body = body.Replace("{State}", State);

        //    body = body.Replace("{Country}", Country);
        //    body = body.Replace("{Pin}", Pin);

        //    // body = body.Replace("{imageurl}", strImagurl);

        //    //body = body.Replace("{message}", message);

        //    return body;

        //}


        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (userProfile != null)
            {
                if (inttimelife > 0)
                {
                    // Display the new time left
                    // by updating the Time Left label.
                    inttimelife = inttimelife - 1;
                    //lblTimerLeft.Text = inttimelife + " seconds left";
                    linkresend.Visible = false;
                }
                else
                {
                    // If the user ran out of time, stop the timer, show
                    // a MessageBox, and fill in the answers.
                    timer1.Stop();
                    linkresend.Visible = true;
                    btnValidCaptcher.Visible = false; lblEntertext.Visible = txtverifytext.Visible = lblOnetime.Visible = lblTimerLeft.Visible = false;
                    if (proptext != string.Empty)
                    {
                        propexptext = proptext;
                        proptext = string.Empty;
                    }
                }
            }
        }

        private void linkresend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            _errorProvider.SetError(btnValidCaptcher, null);
            lblTimerLeft.Visible = true;
            txtverifytext.Visible = true; lblEntertext.Visible = true; btnValidCaptcher.Visible = true;
            lblOnetime.Visible = true;
            btnLogin.Enabled = false;
            inttimelife = 1;
            linkresend.Visible = false;
            lblEntertext.Visible = true;
            // lblTimerLeft.Text = "60 seconds left";
            timer1.Start();
            RandomTokenNumber(6);
            SendEmail(userProfile.PWDEmail, proptext);
        }

        private void linktryanotheruser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _errorProvider.SetError(btnValidCaptcher, null);
            lblTimerLeft.Visible = false;
            txtverifytext.Visible = false; lblEntertext.Visible = false; btnValidCaptcher.Visible = linkresend.Visible = lblOnetime.Visible = linktryanotheruser.Visible = false;
            btnLogin.Enabled = true; txtUserName.Enabled = true; txtPassword.Enabled = true; userProfile = null; txtUserName.Text = ""; txtPassword.Clear();
        }

        string MaskEmailfunction(string strEmail)
        {
            string strMainmaskemail = string.Empty;
            try
            {



                string[] stremailat = strEmail.Split('@');
                if (stremailat.Length > 0)
                {
                    string email = stremailat[0].ToString();
                    string strmaskemail = string.Empty;
                    if (email.Length > 0)
                    {
                        for (int i = 0; i < email.Length; i++)
                        {
                            if (i == 0)
                            {
                                strmaskemail = strmaskemail + email[0].ToString();
                            }
                            else if (i == email.Length - 1)
                                strmaskemail = strmaskemail + email[email.Length - 1].ToString();
                            else
                                strmaskemail = strmaskemail + "*";

                        }
                    }
                    //var maskedEmail = string.Format("{0}****{1}", email[0],
                    //email.Substring(email.Length - 1));
                    string email2 = stremailat[1].ToString();
                    string strmaskemail2 = string.Empty;
                    if (email2.Length > 0)
                    {
                        string[] strarremail = email2.Split('.');
                        for (int i = 0; i < strarremail[0].Length; i++)
                        {
                            if (i == 0)
                            {
                                strmaskemail2 = strmaskemail2 + strarremail[0][0].ToString();
                            }
                            else if (i == strarremail[0].Length - 1)
                                strmaskemail2 = strmaskemail2 + strarremail[0][strarremail[0].Length - 1].ToString();
                            else
                                strmaskemail2 = strmaskemail2 + "*";

                        }
                        strmaskemail2 = strmaskemail2 + "." + strarremail[1];
                    }


                    //var maskedEmail2 = string.Format("{0}****{1}", email2[0],
                    //email2.Substring(email2.IndexOf('.') - 1));
                    strMainmaskemail = strmaskemail + "@" + strmaskemail2;

                }
            }
            catch (Exception ex)
            {


            }
            return strMainmaskemail;
        }
    }
}