#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.IO;
using System.Collections;
using Captain.Common.Utilities;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
//using OfficeOpenXml;
using System.Configuration;
using Captain.Common.Model.Data;
using Captain.Common.Views.Forms;
using Captain.Common.Model.Objects;
using ZedGraph;




#endregion

namespace Captain
{
    public partial class TestForm : Form
    {
        public TestForm()
        {

            


            InitializeComponent();
            string s = "";
            string sFolder = "";
            DirectoryInfo MyDir;
            sFolder = "\\\\cap-dev\\C-Drive\\CapReports";
            MyDir = new DirectoryInfo(sFolder);

            txtSubject.Validator = TextBoxValidation.IntegerValidator;

            maskedTextBox1.Validator = CustomDateValidator;
            //textBox2.Validator = CustomDecimalValidation9dot2;



            //FileInfo[] MyFiles = MyDir.GetFiles("*.*");
            //foreach (FileInfo MyFile in MyFiles)
            //{
            //    s = MyFile.Name;                
            //    listBox1.Items.Add(new ListItem(s));
            //}
        }

        public static TextBoxValidation CustomDateValidator
        {
            get
            {
                return new TextBoxValidation(@"((^(10|12|0?[13578])([/])(3[01]|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(11|0?[469])([/])(30|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(2[0-8]|1[0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(29)([/])([2468][048]00)$)|(^(0?2)([/])(29)([/])([3579][26]00)$)|(^(0?2)([/])(29)([/])([1][89][0][48])$)|(^(0?2)([/])(29)([/])([2-9][0-9][0][48])$)|(^(0?2)([/])(29)([/])([1][89][2468][048])$)|(^(0?2)([/])(29)([/])([2-9][0-9][2468][048])$)|(^(0?2)([/])(29)([/])([1][89][13579][26])$)|(^(0?2)([/])(29)([/])([2-9][0-9][13579][26])$))", "Date format is wrong", "00/00/0000");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string strbody = "Hi This mail send Customer Id  " + txtEmailId.Text + " " + txtBody.Text;
            //    SendMailMessage("murali3358@gmail.com", txtEmailId.Text, "murali3358@gmail.com", string.Empty, txtSubject.Text, strbody); ;

            //    lblMsg.Text = "Your comment has been successfully sent.";

            //}

            //catch (Exception ex)
            //{

            //    lblMsg.ForeColor = Color.Red;
            //    lblMsg.Text = "Error occured while sending your message." + ex.Message;

            //}


            // Send(string.Empty, "This is sample web mail", "sample", false);

            SendMails();


        }

        public static void SendMailMessage(string from, string to, string bcc, string cc, string subject, string body)
        {
            // Instantiate a new instance of MailMessage
            MailMessage mMailMessage = new MailMessage();
            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(from);
            // Set the recepient address of the mail message
            mMailMessage.To.Add(new MailAddress(to));

            // Check if the bcc value is null or an empty string
            if ((bcc != null) && (bcc != string.Empty))
            {
                // Set the Bcc address of the mail message
                mMailMessage.Bcc.Add(new MailAddress(bcc));
            }
            // Check if the cc value is null or an empty value
            if ((cc != null) && (cc != string.Empty))
            {
                // Set the CC address of the mail message
                mMailMessage.CC.Add(new MailAddress(cc));
            }       // Set the subject of the mail message
            mMailMessage.Subject = subject;
            // Set the body of the mail message
            mMailMessage.Body = body;

            // Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = true;
            // Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal;

            // Instantiate a new instance of SmtpClient
            SmtpClient mSmtpClient = new SmtpClient();
            // Send the mail message
            mSmtpClient.Send(mMailMessage);
        }

        private void CreateGraph(Gizmox.WebGUI.Forms.ZedGraph.ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "My Test Graph";
            myPane.XAxis.Title.Text = "X Value";
            myPane.YAxis.Title.Text = "My Y Axis";

            // Make up some data points from the Sine function
            PointPairList list = new PointPairList();
            for (double x = 0; x < 36; x++)
            {
                double y = Math.Sin(x * Math.PI / 15.0);

                list.Add(x, y);
            }

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("My Curve", list, Color.Blue,
                                    SymbolType.Circle);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

            zgc.Update();
        }
        public void Send(string to, string subject, string message, bool isHtml)
        {
            try
            {


                // Create a new message
                var mail = new MailMessage();

                // Set the to and from addresses.
                // The from address must be your GMail account
                mail.From = new MailAddress("murali3358@gmail.com");
                mail.To.Add(new MailAddress("murali3358@gmail.com"));

                // Define the message
                mail.Subject = subject;
                mail.IsBodyHtml = isHtml;
                mail.Body = message;

                // Create a new Smpt Client using Google's servers
                var mailclient = new SmtpClient();
                mailclient.Host = "smtp.gmail.com";
                mailclient.Port = 587;

                // This is the critical part, you must enable SSL
                mailclient.EnableSsl = true;

                // Specify your authentication details
                mailclient.Credentials = new System.Net.NetworkCredential(
                                                 "murali3358@gmail.com ",
                                                 "bhavana0413");
                mailclient.Send(mail);
            }
            catch (Exception)
            {

                // throw;
            }
        }


        public void SendMails()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(txtEmailId.Text);
                //  mail.CC.Add("ccid@hotmail.com");
                mail.From = new MailAddress("murali3358@gmail.com");
                mail.Subject = txtSubject.Text;
                string Body = txtBody.Text;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("murali3358@gmail.com", "bhavana0413");
                smtp.Send(mail);
                lblMsg.Text = "Message send successfully.";
                //txtMessage.Text = "";
            }
            catch (Exception ex)
            {
                //lblStatus.Text = ex.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    lblMsg.Text = string.Empty;
            //    mbno = txtEmailId.Text;
            //    mseg = txtSubject.Text;

            //    sendSms(mbno, mseg);
            //    txtEmailId.Text = "";
            //    txtSubject.Text = "";
            //}
            //catch (Exception ex)
            //{
            //    lblMsg.Text = ex.Message;
            //    lblMsg.Visible = true;
            //}

            try
            {

                send("9949383358", "mrkrishna", txtSubject.Text, txtEmailId.Text);
                lblMsg.Text = "message send successfully......";
            }
            catch
            {
                lblMsg.Text = "Error Occured!!!";
            }
        }





        string mbno, mseg, ckuser, ckpass;
        private HttpWebRequest req;
        private CookieContainer cookieCntr;
        private string strNewValue;
        public static string responseee;
        private HttpWebResponse response;
        public void connect()
        {
            ckuser = "9949383358";
            ckpass = "mrkrishna";

            try
            {
                this.req = (HttpWebRequest)WebRequest.Create("http://wwwd.way2sms.com/auth.cl");

                this.req.CookieContainer = new CookieContainer();
                this.req.AllowAutoRedirect = false;
                this.req.Method = "POST";
                this.req.ContentType = "application/x-www-form-urlencoded";
                this.strNewValue = "username=" + ckuser + "&password=" + ckpass;
                this.req.ContentLength = this.strNewValue.Length;
                StreamWriter writer = new StreamWriter(this.req.GetRequestStream(), Encoding.ASCII);
                writer.Write(this.strNewValue);
                writer.Close();
                this.response = (HttpWebResponse)this.req.GetResponse();
                this.cookieCntr = this.req.CookieContainer;
                this.response.Close();
                this.req = (HttpWebRequest)WebRequest.Create("http://wwwd.way2sms.com//jsp/InstantSMS.jsp?val=0");
                this.req.CookieContainer = this.cookieCntr;
                this.req.Method = "GET";
                this.response = (HttpWebResponse)this.req.GetResponse();
                responseee = new StreamReader(this.response.GetResponseStream()).ReadToEnd();
                int index = Regex.Match(responseee, "custf").Index;
                responseee = responseee.Substring(index, 0x12);
                responseee = responseee.Replace("\"", "").Replace(">", "").Trim();
                this.response.Close();

                // pnlsend.Visible = true;
                lblMsg.Text = "connected";
            }
            catch (Exception)
            {
                lblMsg.Text = "Error connecting to the server...";
                Session["error"] = "Error connecting to the server...";
                // Server.Transfer("smslogin.aspx");


            }
        }

        public void sendSms(string mbno, string mseg)
        {
            if ((mbno != "") && (mseg != ""))
            {
                try
                {
                    this.req = (HttpWebRequest)WebRequest.Create("http://wwwd.way2sms.com//FirstServletsms?custid=");
                    this.req.AllowAutoRedirect = false;
                    this.req.CookieContainer = this.cookieCntr;
                    this.req.Method = "POST";
                    this.req.ContentType = "application/x-www-form-urlencoded";
                    this.strNewValue = "custid=undefined&HiddenAction=instantsms&Action=" + responseee + "&login=&pass=&MobNo=" + this.mbno + "&textArea=" + this.mseg;

                    string msg = this.mseg;
                    string mbeno = this.mbno;

                    this.req.ContentLength = this.strNewValue.Length;
                    StreamWriter writer = new StreamWriter(this.req.GetRequestStream(), Encoding.ASCII);
                    writer.Write(this.strNewValue);
                    writer.Close();
                    this.response = (HttpWebResponse)this.req.GetResponse();

                    this.response.Close();
                    lblMsg.Text = "Message Sent..... " + mbeno + ": " + msg;
                }
                catch (Exception)
                {
                    lblMsg.Text = "Error Sending msg....check your connection...";
                }
            }
            else
            {
                lblMsg.Text = "Mob no or msg missing";
            }
        }

        //private void TestForm_Load(object sender, EventArgs e)
        //{
        //   // this.CreateGraph(this.zedGraphControl1);
        //    //connect();CreateGraph
        //}
        private void send(string uid, string password, string message, string no)
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://ubaid.tk/sms/sms.aspx?uid=" + uid + "&pwd=" + password + "&msg=" + message + "&phone=" + no + "&provider=way2sms");
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //string pathToPdf = @"C:\CapReports\SYSTEM\hssb01142070report.pdf";
            //string pathToWord = @"C:\CapReports\SYSTEM\hssb0114report.doc";
            //SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            ////this property is necessary only for registered version
            ////f.Serial = "XXXXXXXXXXX";

            //f.OpenPdf(pathToPdf);

            //if (f.PageCount > 0)
            //{
            //    int result = f.ToWord(pathToWord);

            //    //Show Word document
            //    if (result == 0)
            //    {
            //        System.Diagnostics.Process.Start(pathToWord);
            //    }
            //}

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionSample"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from CHLDMEDI where  MEDI_Task  IN ('0050', '0051','0052','0053','0054','0055')", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            foreach (DataRow item in ds.Tables[0].Rows)
            {


                textBox3.Text = item["MEDI_ANSWER1"].ToString();
                string strMediAnswer1 = textBox3.Text;
                string strMediAnswer2 = "0";
                if (IsNumeric(textBox3.Text))
                {
                    strMediAnswer2 = textBox3.Text;
                    string[] str = strMediAnswer2.Split('.');
                    if (str.Length > 1)
                    {

                        if (str[1].Length > 3)
                        {
                            strMediAnswer2 = str[0] + "." + str[1].Substring(0, 3);
                        }

                    }
                }
                else
                {
                    string strvalue = strMediAnswer1.Substring(0, 2);
                    if (strMediAnswer1.Length > 3)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 3)) && strMediAnswer1.Substring(3, 1) == ".")
                        {
                            if (strMediAnswer1.Length > 6)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(4, 3)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 7);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 5)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(4, 2)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 6);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 4)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(4, 1)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 5);
                                    goto kk;
                                }
                            }
                        }
                    }
                    if (strMediAnswer1.Length > 2)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 2)) && strMediAnswer1.Substring(2, 1) == ".")
                        {
                            if (strMediAnswer1.Length > 5)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(3, 3)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 6);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 4)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(3, 2)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 5);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 3)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(3, 1)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 4);
                                    goto kk;
                                }
                            }
                        }
                    }
                    if (strMediAnswer1.Length > 1)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 1)) && strMediAnswer1.Substring(1, 1) == ".")
                        {
                            if (strMediAnswer1.Length > 4)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(2, 3)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 5);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 3)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(2, 2)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 4);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 2)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(2, 1)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 3);
                                    goto kk;
                                }
                            }
                        }
                    }

                    ///check Fractions
                    ///

                    if (strMediAnswer1.Length > 4)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 3)) && IsNumeric(strMediAnswer1.Substring(4, 1)))
                        {
                            if (strMediAnswer1.Length > 6)
                            {
                                switch (strMediAnswer1.Substring(4, 3))
                                {
                                    case "1/4":
                                    case "2/8":
                                    case @"1\4":
                                    case @"2\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".250";
                                        break;
                                    case "1/2":
                                    case "4/8":
                                    case @"1\2":
                                    case @"4\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".500";
                                        break;
                                    case "3/4":
                                    case "6/8":
                                    case @"3\4":
                                    case @"6\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".750";
                                        break;
                                    case "1/8":
                                    case @"1\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".125";
                                        break;
                                    case "3/8":
                                    case @"3\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".375";
                                        break;
                                    case "5/8":
                                    case @"5\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".625";
                                        break;
                                    case "7/8":
                                    case @"7\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".875";
                                        break;
                                    case "1/3":
                                    case @"1\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".333";
                                        break;
                                    case "2/3":
                                    case @"2\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".666";
                                        break;

                                }
                                goto kk;
                            }
                        }
                    }
                    if (strMediAnswer1.Length > 3)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 2)) && IsNumeric(strMediAnswer1.Substring(3, 1)))
                        {
                            if (strMediAnswer1.Length > 5)
                            {
                                switch (strMediAnswer1.Substring(3, 3))
                                {
                                    case "1/4":
                                    case "2/8":
                                    case @"1\4":
                                    case @"2\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".250";
                                        break;
                                    case "1/2":
                                    case "4/8":
                                    case @"1\2":
                                    case @"4\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".500";
                                        break;
                                    case "3/4":
                                    case "6/8":
                                    case @"3\4":
                                    case @"6\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".750";
                                        break;
                                    case "1/8":
                                    case @"1\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".125";
                                        break;
                                    case "3/8":
                                    case @"3\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".375";
                                        break;
                                    case "5/8":
                                    case @"5\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".625";
                                        break;
                                    case "7/8":
                                    case @"7\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".875";
                                        break;
                                    case "1/3":
                                    case @"1\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".333";
                                        break;
                                    case "2/3":
                                    case @"2\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".666";
                                        break;

                                }
                                goto kk;
                            }
                        }
                    }
                    if (strMediAnswer1.Length > 2)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 1)) && IsNumeric(strMediAnswer1.Substring(2, 1)))
                        {
                            if (strMediAnswer1.Length > 4)
                            {
                                switch (strMediAnswer1.Substring(2, 3))
                                {
                                    case "1/4":
                                    case "2/8":
                                    case @"1\4":
                                    case @"2\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".250";
                                        break;
                                    case "1/2":
                                    case "4/8":
                                    case @"1\2":
                                    case @"4\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".500";
                                        break;
                                    case "3/4":
                                    case "6/8":
                                    case @"3\4":
                                    case @"6\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".750";
                                        break;
                                    case "1/8":
                                    case @"1\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".125";
                                        break;
                                    case "3/8":
                                    case @"3\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".375";
                                        break;
                                    case "5/8":
                                    case @"5\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".625";
                                        break;
                                    case "7/8":
                                    case @"7\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".875";
                                        break;
                                    case "1/3":
                                    case @"1\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".333";
                                        break;
                                    case "2/3":
                                    case @"2\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".666";
                                        break;

                                }
                                goto kk;
                            }
                        }
                    }



                    if (strMediAnswer1.Length > 2)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 3)))
                        {
                            strMediAnswer2 = strMediAnswer1.Substring(0, 3);
                            goto kk;
                        }
                    }
                    if (strMediAnswer1.Length > 1)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 2)))
                        {
                            strMediAnswer2 = strMediAnswer1.Substring(0, 2);
                            goto kk;
                        }
                    }

                }
            kk:
                textBox2.Text = strMediAnswer2;


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionSample"].ConnectionString);
                con.Open();
                string strupd = "Update Chldmedi SeT MEDI_ANSWER2=" + strMediAnswer2 + " WHERE MEDI_AGENCY ='" + item["MEDI_AGENCY"] + "' AND MEDI_DEPT ='" + item["MEDI_DEPT"] + "'  AND MEDI_PROG ='" + item["MEDI_PROG"] + "' AND MEDI_YEAR ='" + item["MEDI_YEAR"] + "' AND MEDI_APP_NO ='" + item["MEDI_APP_NO"] + "' AND MEDI_TASK ='" + item["MEDI_TASK"] + "' AND MEDI_SEQ =" + item["MEDI_SEQ"] + "";
                SqlCommand cmdo = new SqlCommand(strupd, con);
                cmdo.ExecuteNonQuery();
                con.Close();



            }
        }




        public bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////CaptainModel _model = new CaptainModel();

            //////List<ChldMediEntity> chldmedidate = _model.ChldTrckData.GetMediFix();

            //////foreach (ChldMediEntity item in chldmedidate)
            //////{
            //////    item.ANSWER2 = CustomQuesValidation(item.ANSWER1);
            //////    _model.ChldTrckData.Updatemedifix(item);
            //////}
            ////MessageBox.Show(LookupDataAccess.decimal2value(textBox3.Text));

            //////CommonFunctions.Convert_XMLstring_To_Datatable("ss");

            //////MessageBox.Show(maskedTextBox1.Text);

           
            //////string strmessage = "12345678910";
            ////////string strtest = "

            //////string value = "mmmdss.jpg";
            //////string[] lines = value.Split('\\');
            //////string strmm = string.Empty;
            //////foreach (string line in lines)
            //////{
            //////    strmm = line;
            //////}
            //////MessageBox.Show(strmm);

            //////if (txtSubject.Text !=string.Empty)
            //////{

            //////    int DecimalVal = int.Parse(txtSubject.Text);

            //////    string HexVal = DecimalVal.ToString("X");
            //////    MessageBox.Show(HexVal);
            //////}

            //////    CaptainModel model = new CaptainModel();
            //////DataSet ds = model.CaseMstData.GetCaseMstadpyn(


            ////Define Graph Pane
            //GraphPane mobjPane = mobjZedGraph.GraphPane;

            ////Set the Titles
            //mobjPane.Title.Text = "Test Graph\n(simple line and bar chart)";
            //mobjPane.XAxis.Title.Text = "X Axis";
            //mobjPane.YAxis.Title.Text = "Y Axis";

            ////Make up some data arrays based on the Sin function
            //double x, y1, y2;

            //PointPairList objList1 = new PointPairList();
            //PointPairList objList2 = new PointPairList();
            //for (int i = 0; i < 36; i++)
            //{
            //    x = (double)i + 5;
            //    y1 = 1.5 + Math.Sin((double)i * 0.2);
            //    y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
            //    objList1.Add(x, y1);
            //    objList2.Add(x, y2);
            //}

            ////Generate a red curve with square symbols, and "Porsche" in the legend
            //LineItem objCurve1 = mobjPane.AddCurve("Porsche", objList1, Color.Red, SymbolType.Square);

            ////Generate a blue curve with circle symbols, and "Piper" in the legend
            //LineItem objCurve2 = mobjPane.AddCurve("Piper", objList2, Color.Blue, SymbolType.Circle);

            ////Make up some random data points
            //double[] yArray = { 10, 15, 7.5, 2.2 };
            //double[] y2Array = { 9, 10, 9.5, 3.5 };
            //double[] y3Array = { 8, 11, 6.5, 1.5 };
            //double[] xArray = { 10, 20, 30, 40 };

            ////Add bars
            //// Generate a red bar with "Bar 1" in the legend
            //BarItem myBar = mobjPane.AddBar("Bar 1", xArray, yArray, Color.Beige);
            //myBar.Bar.Fill = new Fill(Color.Beige);

            //// Generate a blue bar with "Bar 2" in the legend
            //myBar = mobjPane.AddBar("Bar 2", xArray, y2Array, Color.LightPink);
            //myBar.Bar.Fill = new Fill(Color.LightPink);

            //// Generate a green bar with "Bar 3" in the legend
            //myBar = mobjPane.AddBar("Bar 3", xArray, y3Array, Color.Lavender);
            //myBar.Bar.Fill = new Fill(Color.Lavender);

            ////Refigure the axes since the data have changed
            //mobjZedGraph.AxisChange();

            ////Add a caption to graph
            //String objCaption = "This is a graph caption";
            //TextObj objText = new TextObj(objCaption, 0.3f, 0.3f);
            //objText.FontSpec.Angle = 25f;
            //objText.FontSpec.FontColor = Color.Black;
            //objText.FontSpec.IsBold = true;
            //objText.FontSpec.Size = 20;

            ////Disable the border and background fill options for the text
            //objText.FontSpec.Border.IsVisible = false;
            //objText.FontSpec.Fill.IsVisible = false;

            ////Align the text such the the Left-Bottom corner is at the specified coordinates
            //objText.Location.AlignH = AlignH.Left;
            //objText.Location.AlignV = AlignV.Bottom;

            //mobjZedGraph.GraphPane.GraphObjList.Add(objText);
            //mobjZedGraph.Update();

            //SampleTestForm obj = new SampleTestForm();
            //obj.ShowDialog();
           // Context.Redirect("/SSRS/Default.aspx");
            //SampleTestForm sample = new SampleTestForm(baseform);
            //sample.ShowDialog();
        }

        private string CustomQuesValidation(string strMediAnswer1)
        {
            string strAnswer2 = string.Empty;

            ////  ChldTrckEntity chldheightdata = propchldTrckList.Find(u => u.TASK == propTask);
            //if ("S" == "HT" || "s" == "WT" || "s" == "HC")
            //{

                string strMediAnswer2 = "0";
                if (IsNumeric(strMediAnswer1))
                {
                    strMediAnswer2 = strMediAnswer1;
                    //string[] str = strMediAnswer2.Split('.');
                    //if (str.Length > 0)
                    //{
                    //    if (str[1].Length > 3)
                    //    {
                    //        strMediAnswer2 = str[0] + "." + str[1].Substring(0, 3);
                    //    }
                    //}
                }
                else
                {
                    string strvalue = strMediAnswer1.Substring(0, 2);
                    if (strMediAnswer1.Length > 3)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 3)) && strMediAnswer1.Substring(3, 1) == ".")
                        {
                            if (strMediAnswer1.Length > 6)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(4, 3)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 7);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 5)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(4, 2)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 6);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 4)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(4, 1)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 5);
                                    goto kk;
                                }
                            }
                        }
                    }
                    if (strMediAnswer1.Length > 2)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 2)) && strMediAnswer1.Substring(2, 1) == ".")
                        {
                            if (strMediAnswer1.Length > 5)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(3, 3)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 6);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 4)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(3, 2)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 5);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 3)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(3, 1)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 4);
                                    goto kk;
                                }
                            }
                        }
                    }
                    if (strMediAnswer1.Length > 1)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 1)) && strMediAnswer1.Substring(1, 1) == ".")
                        {
                            if (strMediAnswer1.Length > 4)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(2, 3)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 5);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 3)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(2, 2)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 4);
                                    goto kk;
                                }
                            }
                            if (strMediAnswer1.Length > 2)
                            {
                                if (IsNumeric(strMediAnswer1.Substring(2, 1)))
                                {
                                    strMediAnswer2 = strMediAnswer1.Substring(0, 3);
                                    goto kk;
                                }
                            }
                        }
                    }

                    ///check Fractions
                    ///

                    if (strMediAnswer1.Length > 4)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 3)) && IsNumeric(strMediAnswer1.Substring(4, 1)))
                        {
                            if (strMediAnswer1.Length > 6)
                            {
                                switch (strMediAnswer1.Substring(4, 3))
                                {
                                    case "1/4":
                                    case "2/8":
                                    case @"1\4":
                                    case @"2\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".250";
                                        break;
                                    case "1/2":
                                    case "4/8":
                                    case @"1\2":
                                    case @"4\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".500";
                                        break;
                                    case "3/4":
                                    case "6/8":
                                    case @"3\4":
                                    case @"6\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".750";
                                        break;
                                    case "1/8":
                                    case @"1\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".125";
                                        break;
                                    case "3/8":
                                    case @"3\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".375";
                                        break;
                                    case "5/8":
                                    case @"5\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".625";
                                        break;
                                    case "7/8":
                                    case @"7\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".875";
                                        break;
                                    case "1/3":
                                    case @"1\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".333";
                                        break;
                                    case "2/3":
                                    case @"2\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 3) + ".666";
                                        break;

                                }
                                goto kk;
                            }
                        }
                    }
                    if (strMediAnswer1.Length > 3)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 2)) && IsNumeric(strMediAnswer1.Substring(3, 1)))
                        {
                            if (strMediAnswer1.Length > 5)
                            {
                                switch (strMediAnswer1.Substring(3, 3))
                                {
                                    case "1/4":
                                    case "2/8":
                                    case @"1\4":
                                    case @"2\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".250";
                                        break;
                                    case "1/2":
                                    case "4/8":
                                    case @"1\2":
                                    case @"4\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".500";
                                        break;
                                    case "3/4":
                                    case "6/8":
                                    case @"3\4":
                                    case @"6\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".750";
                                        break;
                                    case "1/8":
                                    case @"1\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".125";
                                        break;
                                    case "3/8":
                                    case @"3\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".375";
                                        break;
                                    case "5/8":
                                    case @"5\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".625";
                                        break;
                                    case "7/8":
                                    case @"7\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".875";
                                        break;
                                    case "1/3":
                                    case @"1\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".333";
                                        break;
                                    case "2/3":
                                    case @"2\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 2) + ".666";
                                        break;

                                }
                                goto kk;
                            }
                        }
                    }

                    if (strMediAnswer1.Length > 2)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 1)) && IsNumeric(strMediAnswer1.Substring(2, 1)))
                        {
                            if (strMediAnswer1.Length > 4)
                            {
                                switch (strMediAnswer1.Substring(2, 3))
                                {
                                    case "1/4":
                                    case "2/8":
                                    case @"1\4":
                                    case @"2\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".250";
                                        break;
                                    case "1/2":
                                    case "4/8":
                                    case @"1\2":
                                    case @"4\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".500";
                                        break;
                                    case "3/4":
                                    case "6/8":
                                    case @"3\4":
                                    case @"6\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".750";
                                        break;
                                    case "1/8":
                                    case @"1\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".125";
                                        break;
                                    case "3/8":
                                    case @"3\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".375";
                                        break;
                                    case "5/8":
                                    case @"5\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".625";
                                        break;
                                    case "7/8":
                                    case @"7\8":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".875";
                                        break;
                                    case "1/3":
                                    case @"1\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".333";
                                        break;
                                    case "2/3":
                                    case @"2\3":
                                        strMediAnswer2 = strMediAnswer1.Substring(0, 1) + ".666";
                                        break;

                                }
                                goto kk;
                            }
                        }
                    }


                    if (strMediAnswer1.Length > 2)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 3)))
                        {
                            strMediAnswer2 = strMediAnswer1.Substring(0, 3);
                            goto kk;
                        }
                    }
                    if (strMediAnswer1.Length > 1)
                    {
                        if (IsNumeric(strMediAnswer1.Substring(0, 2)))
                        {
                            strMediAnswer2 = strMediAnswer1.Substring(0, 2);
                            goto kk;
                        }
                    }

                }
            kk:
                strAnswer2 = strMediAnswer2;

            //}
            return strAnswer2;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            ////RunSample3(ConfigurationManager.ConnectionStrings["ConnectionSample"].ConnectionString);
            //GraphPane mobjPane = mobjZedGraph.GraphPane;

            ////Set the GraphPane title
            //mobjPane.Title.Text = "Graph with Pie Chart";
            //mobjPane.Title.FontSpec.Size = 10f;

            ////Set the legend to an arbitrary location
            //mobjPane.Legend.Position = LegendPos.Float;
            //mobjPane.Legend.Location = new Location(0.95f, 0.15f, CoordType.PaneFraction, AlignH.Right, AlignV.Top);
            //mobjPane.Legend.FontSpec.Size = 10f;
            //mobjPane.Legend.IsHStack = false;

            ////Add some pie slices
            //PieItem segment1 = mobjPane.AddPieSlice(20, Color.Navy, Color.White, 45f, 0, "North");
            //PieItem segment3 = mobjPane.AddPieSlice(30, Color.Purple, Color.White, 45f, .0, "East");
            //PieItem segment4 = mobjPane.AddPieSlice(10.21, Color.LimeGreen, Color.White, 45f, 0, "West");
            //PieItem segment2 = mobjPane.AddPieSlice(40, Color.SandyBrown, Color.White, 45f, 0.2, "South");
            //PieItem segment6 = mobjPane.AddPieSlice(250, Color.Red, Color.White, 45f, 0, "Europe");
            //PieItem segment7 = mobjPane.AddPieSlice(50, Color.Blue, Color.White, 45f, 0.2, "Pac Rim");
            //PieItem segment8 = mobjPane.AddPieSlice(400, Color.Green, Color.White, 45f, 0, "South America");
            //PieItem segment9 = mobjPane.AddPieSlice(50, Color.Yellow, Color.White, 45f, 0.2, "Africa");

            ////Calculate the Axis Scale Ranges
            //mobjZedGraph.AxisChange();
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void maskedTextBox1_Validated(object sender, EventArgs e)
        {

        }

        private void tabControl1_CloseClick(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }



        //public static string RunSample3(string connectionString)
        //{

        //    // just check nobody is been an idiot here!
        //    if (connectionString.IndexOf("YourServerName") > 0)
        //        throw new Exception("You must edit the connection string to reference the correct server name!");
        //    FileInfo newFile = new FileInfo(@"C:\sample3.xlsx");
        //    FileInfo template = new FileInfo(@"C:\sample3template.xlsx");
        //    if (!template.Exists) throw new Exception("Template file does not exist! i.e. sample3template.xlsx");


        //    // ok, we can run the real code of the sample now
        //    using (ExcelPackage xlPackage = new ExcelPackage(newFile))
        //    {
        //        // uncomment this line if you want the XML written out to the outputDir
        //        //xlPackage.DebugMode = true; 

        //        // get handle to the existing worksheet
        //        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
        //        if (worksheet != null)
        //        {
        //            ExcelCell cell;
        //            const int startRow = 5;
        //            int row = startRow;

        //            // lets connect to the AdventureWorks sample database for some data
        //            using (SqlConnection sqlConn = new SqlConnection(connectionString))
        //            {
        //                sqlConn.Open();
        //                using (SqlCommand sqlCmd = new SqlCommand("select TOP 10 SNP_ALT_Fi +', ' + SNP_ALT_LNAME AS [NAME],SNP_STATUS,SNP_SEX,SNP_SCHOOL_DISTRICT,SNP_RACE,SNP_VEHICLE_VALUE,SNP_VEHICLE_VALUE from casesnp where snp_year='2013'", sqlConn))
        //                {
        //                    using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
        //                    {
        //                        // get the data and fill rows 5 onwards
        //                        while (sqlReader.Read())
        //                        {
        //                            int col = 1;
        //                            // we have our total formula on row 7, so push them down so we can insert more data
        //                            if (row > startRow) worksheet.InsertRow(row);

        //                            // our query has the columns in the right order, so simply
        //                            // iterate through the columns
        //                            for (int i = 0; i < sqlReader.FieldCount; i++)
        //                            {
        //                                // use the email address as a hyperlink for column 1
        //                                if (sqlReader.GetName(i) == "EmailAddress")
        //                                {
        //                                    // insert the email address as a hyperlink for the name
        //                                    string hyperlink = "mailto:" + sqlReader.GetValue(i).ToString();
        //                                    worksheet.Cell(row, 1).Hyperlink = new Uri(hyperlink, UriKind.Absolute);
        //                                }
        //                                else
        //                                {
        //                                    // do not bother filling cell with blank data (also useful if we have a formula in a cell)
        //                                    if (sqlReader.GetValue(i) != null)
        //                                        worksheet.Cell(row, col).Value = sqlReader.GetValue(i).ToString();
        //                                    //worksheet.WorksheetXml
        //                                    col++;
        //                                }
        //                            }
        //                            row++;
        //                        }
        //                        sqlReader.Close();

        //                        // delete the two spare rows we have in the template
        //                        worksheet.DeleteRow(row, true);
        //                        worksheet.DeleteRow(row, true);
        //                        row--;
        //                    }
        //                }
        //                sqlConn.Close();
        //            }
        //            /* 
        //             * The data we just inserted is between startRow and row.
        //             * Now we need to apply the same styles and common formula for all these rows.
        //             * 
        //             * First copy the styles from startRow to the new rows.     */
        //            for (int iCol = 1; iCol <= 7; iCol++)
        //            {
        //                cell = worksheet.Cell(startRow, iCol);
        //                for (int iRow = startRow; iRow <= row; iRow++)
        //                {
        //                    worksheet.Cell(iRow, iCol).StyleID = cell.StyleID;
        //                }
        //            }
        //            // style the first row as they are the top achiever
        //            worksheet.Cell(startRow, 6).Style = "Good";
        //            // style the last row as they are the worst performer
        //            worksheet.Cell(row, 6).Style = "Bad";

        //            // now create a *shared* formula based on the formula in the startRow column 5 and 7
        //            worksheet.CreateSharedFormula(worksheet.Cell(startRow, 5), worksheet.Cell(row, 5));
        //            worksheet.CreateSharedFormula(worksheet.Cell(startRow, 7), worksheet.Cell(row, 7));

        //            // to force Excel to re-calculate the formulas in the total line, 
        //            // we must remove the values currently in the cells
        //            worksheet.Cell(row + 1, 5).RemoveValue();
        //            worksheet.Cell(row + 1, 6).RemoveValue();
        //            worksheet.Cell(row + 1, 7).RemoveValue();

        //            // lets set the header text 
        //            worksheet.HeaderFooter.oddHeader.CenteredText = "AdventureWorks Inc. Sales Report";
        //            // add the page number to the footer plus the total number of pages
        //            worksheet.HeaderFooter.oddFooter.RightAlignedText =
        //                string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
        //            // add the sheet name to the footer
        //            worksheet.HeaderFooter.oddFooter.CenteredText = ExcelHeaderFooter.SheetName;
        //            // add the file path to the footer
        //            worksheet.HeaderFooter.oddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;
        //        }
        //        xlPackage.Save();
        //        // we had better add some document properties to the spreadsheet 

        //        // set some core property values
        //        //xlPackage.Workbook.Properties.Title = "Sample 3";
        //        //xlPackage.Workbook.Properties.Author = "John Tunnicliffe";
        //        //xlPackage.Workbook.Properties.Subject = "ExcelPackage Samples";
        //        //xlPackage.Workbook.Properties.Keywords = "Office Open XML";
        //        //xlPackage.Workbook.Properties.Category = "ExcelPackage Samples";
        //        //xlPackage.Workbook.Properties.Comments = "This sample demonstrates how to create an Excel 2007 file from scratch using the Packaging API and Office Open XML";

        //        //// set some extended property values
        //        //xlPackage.Workbook.Properties.Company = "AdventureWorks Inc.";
        //        //xlPackage.Workbook.Properties.HyperlinkBase = new Uri("http://www.linkedin.com/pub/0/277/8a5");

        //        //// set some custom property values
        //        //xlPackage.Workbook.Properties.SetCustomPropertyValue("Checked by", "John Tunnicliffe");
        //        //xlPackage.Workbook.Properties.SetCustomPropertyValue("EmployeeID", "1147");
        //        //xlPackage.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "ExcelPackage");

        //        //// save the new spreadsheet
        //        //xlPackage.Save();
        //    }

        //    // if you want to take a look at the XML created in the package, simply uncomment the following lines
        //    // These copy the output file and give it a zip extension so you can open it and take a look!
        //    //FileInfo zipFile = new FileInfo(outputDir.FullName + @"\sample3.zip");
        //    //if (zipFile.Exists) zipFile.Delete();
        //    //newFile.CopyTo(zipFile.FullName);

        //    return newFile.FullName;
        //}



    }
}