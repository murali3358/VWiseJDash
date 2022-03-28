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
using Captain.Common.Views.Forms.Base;
using Captain.Common.Model.Objects;
using Captain.Common.Utilities;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Microsoft.Win32;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using Captain.Common.Model.Data;

#endregion

namespace Captain.Common.Views.Forms
{
    public partial class PdfListForm : Form
    {
        string strFileName = "";
        string strLength = "";
        string strLastWritetime = "";
        string strDeleteType = "";
        string strFolderPath = string.Empty;
        DirectoryInfo MyDir;
        public PdfListForm(BaseForm baseForm, PrivilegeEntity privilegeEntity, bool preview)
        {
            try
            {


                InitializeComponent();
                this.Text = privilegeEntity.Program;
                BaseForm = baseForm;
                //lblHeader.Text = privilegeEntity.PrivilegeName;
                Preview = preview;
                strFolderPath = Consts.Common.ReportFolderLocation + BaseForm.UserID + "\\";
                fillListView();
                EnableButtons();

            }
            catch (Exception ex)
            {

                CommonFunctions.MessageBoxDisplay(ex.Message);
            }
        }
        public PdfListForm(BaseForm baseForm, PrivilegeEntity privilegeEntity, bool preview, string FolderPath)
        {
            try
            {


                InitializeComponent();
                this.Text = privilegeEntity.Program;
                BaseForm = baseForm;
                //lblHeader.Text = privilegeEntity.PrivilegeName;
                Preview = preview;
                strFolderPath = FolderPath + BaseForm.UserID + "\\";
                fillListView();
                EnableButtons();
            }
            catch (StackOverflowException ex)
            { }
            catch (Exception ex)
            {

                CommonFunctions.MessageBoxDisplay(ex.Message);
            }

        }

        public PdfListForm(string strUserId, bool preview, string FolderPath)
        {
            try
            {


                InitializeComponent();
                this.Text = "Report Preview";

                //lblHeader.Text = privilegeEntity.PrivilegeName;
                Preview = preview;
                strFolderPath = FolderPath + strUserId + "\\";
                fillListView();
                EnableButtons();
            }
            catch (StackOverflowException ex)
            { }
            catch (Exception ex)
            {

                CommonFunctions.MessageBoxDisplay(ex.Message);
            }

        }

        public PdfListForm(BaseForm baseForm)
        {
            try
            {


                InitializeComponent();
                this.Text = "Excel Merge Preview";
                CaptainModel _model = new CaptainModel();
                string FolderPath = _model.lookupDataAccess.GetReportPath();
                BaseForm = baseForm;
                //lblHeader.Text = privilegeEntity.PrivilegeName;
                Preview = true;
                strFolderPath = FolderPath + BaseForm.UserID + "\\MERGEFILES\\";
                fillListView();
                EnableButtons();
                btnMerge.Visible = true;
            }
            catch (StackOverflowException ex)
            { }
            catch (Exception ex)
            {

                CommonFunctions.MessageBoxDisplay(ex.Message);
            }

        }



        public PdfListForm(BaseForm baseForm, PrivilegeEntity privilegeEntity, bool preview, string FolderPath, string TextFormat)
        {
            try
            {

                InitializeComponent();
                this.Text = privilegeEntity.Program;
                BaseForm = baseForm;
                Format = TextFormat;
                //lblHeader.Text = privilegeEntity.PrivilegeName;
                Preview = preview;
                strFolderPath = FolderPath + BaseForm.UserID + "\\";
                fillListView();
                EnableButtons();
            }
            catch (Exception ex)
            {

                CommonFunctions.MessageBoxDisplay(ex.Message);
            }
        }

        public BaseForm BaseForm { get; set; }

        public bool Preview { get; set; }

        public string Format { get; set; }

        private void OnHelpClick(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Context.Server.MapPath("~\\Resources\\HelpFiles\\Captain_Help.chm"), HelpNavigator.KeywordIndex, "Captain");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strDeleteFile = "";
            var selectedItems = listViewPdf.SelectedItems;
            if (selectedItems.Count > 0)
            {
                bool boolmark = false;
                foreach (ListViewItem item in listViewPdf.Items)
                {
                    if (item.Selected)
                    {
                        //if (item.SubItems[3].Text == "*")
                        //{
                        boolmark = true;
                        strDeleteType = "Mark";
                        break;

                        // }
                    }
                }

                strDeleteFile = listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[0].Text.ToString();
                if (boolmark == true)
                    MessageBox.Show("Are you sure you want to delete selected files?", Consts.Common.ApplicationCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxHandler, true);
                else
                    MessageBox.Show(Consts.Messages.AreYouSureYouWantToDelete.GetMessage() + "\nFile " + strDeleteFile, Consts.Common.ApplicationCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxHandler, true);

            }
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            // strDeleteType = "ALL";
            // MessageBox.Show(Consts.Messages.AreYouSureYouWantToDelete.GetMessage() + "All Files", Consts.Common.ApplicationCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxHandler, true);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string strPreviewFile = "";
            var selectedItems = listViewPdf.SelectedItems;
            try
            {
                if (selectedItems.Count > 0)
                {
                    if (listViewPdf.Items[listViewPdf.SelectedIndex].Selected)
                        strPreviewFile = listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[0].Text == null ? string.Empty : listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[0].Text.ToString();

                    if (!string.IsNullOrEmpty(strPreviewFile))
                    {
                        int Count = strPreviewFile.Length;
                        if (BaseForm.BaseAgencyControlDetails.ReportSwitch.ToUpper() == "Y")
                        {
                            if (strPreviewFile.Substring(Count - 4, 4) == ".pdf")
                            {
                                PdfViewerNewForm objfrm = new PdfViewerNewForm(strFolderPath + "\\" + strPreviewFile);
                                objfrm.ShowDialog();

                            }
                            else if (strPreviewFile.Substring(Count - 4, 4) == ".xls")
                            {
                                CommonFunctions.MessageBoxDisplay("you can't preview xls, please download it.");
                            }
                            else if (strPreviewFile.Substring(Count - 4, 4) == ".txt")
                            {
                                PdfViewerNewForm objfrm = new PdfViewerNewForm(strFolderPath + "\\" + strPreviewFile);
                                objfrm.ShowDialog();
                            }
                        }
                        else
                        {

                            if (strPreviewFile.Substring(Count - 4, 4) == ".pdf")
                            {
                                FrmViewer objfrm = new FrmViewer(strFolderPath + "\\" + strPreviewFile);
                                objfrm.ShowDialog();
                            }
                            else if (strPreviewFile.Substring(Count - 4, 4) == ".xls")
                            {
                                //FrmViewer objfrm = new FrmViewer(strFolderPath + "\\" + strPreviewFile);
                                //objfrm.ShowDialog();
                                //OpenExcelFile(strPreviewFile);
                                CommonFunctions.MessageBoxDisplay("you can't preview xls, please download it.");
                            }
                            else if (strPreviewFile.Substring(Count - 4, 4) == ".txt")
                            {
                                FrmViewer objfrm = new FrmViewer(strFolderPath + "\\" + strPreviewFile);
                                objfrm.ShowDialog();
                                //Process.Start("notepad.exe", strFolderPath + strPreviewFile);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }
        //private Excel.Application ExcelObj = null;
        //private void OpenExcelFile(string FileName)
        //{
        //    ExcelObj = new Excel.Application();
        //    ExcelObj.Visible = true;
        //    Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(strFolderPath + "\\" + FileName, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
        //    // get the collection of sheets in the workbook
        //    Excel.Sheets sheets = theWorkbook.Worksheets;
        //    // get the first and only worksheet from the collection of worksheets
        //    Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
        //}

        private void fillListView()
        {
            MyDir = new DirectoryInfo(strFolderPath);
            if (MyDir.Exists == true)
            {
                FileInfo[] MyFiles = MyDir.GetFiles("*.*");
                this.listViewPdf.SelectedIndexChanged -= new System.EventHandler(this.listViewPdf_SelectedIndexChanged);
                listViewPdf.Items.Clear();
                this.listViewPdf.SelectedIndexChanged += new System.EventHandler(this.listViewPdf_SelectedIndexChanged);
                foreach (FileInfo MyFile in MyFiles)
                {
                    strFileName = MyFile.Name;
                    strLength = (MyFile.Length / 1024).ToString();
                    strLastWritetime = MyFile.LastWriteTime.ToShortDateString() + " " + MyFile.LastWriteTime.ToShortTimeString();
                    listViewPdf.Items.Add(new ListViewItem(new string[] { strFileName, strLength + "  KB", strLastWritetime, string.Empty }));
                }
            }
            else
            {
                MyDir.Create();
            }
        }

        private void MessageBoxHandler(object sender, EventArgs e)
        {

            // Get Gizmox.WebGUI.Forms.Form object that called MessageBox
            Gizmox.WebGUI.Forms.Form senderForm = (Gizmox.WebGUI.Forms.Form)sender;
            string strDeleteFile = "";
            if (senderForm != null)
            {
                // Set DialogResult value of the Form as a text for label
                if (senderForm.DialogResult.ToString() == "Yes")
                {
                    if (strDeleteType == "ALL")
                    {
                        MyDir = new DirectoryInfo(strFolderPath);
                        FileInfo[] MyFiles = MyDir.GetFiles("*.*");
                        foreach (FileInfo MyFile in MyFiles)
                        {
                            if (MyFile.Exists)
                            {
                                MyFile.Delete();
                            }
                        }
                    }
                    else if (strDeleteType == "Mark")
                    {
                        foreach (ListViewItem item in listViewPdf.Items)
                        {
                            //if (item.SubItems[3].Text == "*")
                            //{
                            if (item.Selected)
                            {
                                strDeleteFile = item.SubItems[0].Text.ToString();
                                MyDir = new DirectoryInfo(strFolderPath);
                                FileInfo[] MyFiles = MyDir.GetFiles("*.*");
                                foreach (FileInfo MyFile in MyFiles)
                                {
                                    if (MyFile.Exists)
                                    {
                                        if (strDeleteFile == MyFile.Name)
                                        {
                                            MyFile.Delete();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (strDeleteType == "Download")
                    {
                        var selectedItems = listViewPdf.SelectedItems;
                        if (selectedItems.Count > 0)
                        {
                            strDeleteFile = listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[0].Text.ToString();

                            FileDownloadGateway downloadGateway = new FileDownloadGateway();
                            downloadGateway.Filename = strDeleteFile;

                            // downloadGateway.Version = file.Version;

                            downloadGateway.SetContentType(DownloadContentType.OctetStream);

                            downloadGateway.StartFileDownload(new ContainerControl(), strFolderPath + "\\" + strDeleteFile);

                        }


                    }
                    else
                    {
                        var selectedItems = listViewPdf.SelectedItems;
                        if (selectedItems.Count > 0)
                        {
                            strDeleteFile = listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[0].Text.ToString();
                        }
                        MyDir = new DirectoryInfo(strFolderPath);
                        FileInfo[] MyFiles = MyDir.GetFiles("*.*");
                        foreach (FileInfo MyFile in MyFiles)
                        {
                            if (MyFile.Exists)
                            {
                                if (strDeleteFile == MyFile.Name)
                                {
                                    MyFile.Delete();
                                }
                            }
                        }

                    }

                    fillListView();
                }

            }
        }

        private void EnableButtons()
        {
            if (!Preview)
            {
                btnDelete.Visible = false;
                btnDeleteAll.Visible = false;
                btnPreview.Visible = false;
                btnMerge.Visible = false;
                this.Size = new System.Drawing.Size(539, 328);
                this.SavePanel.Location = new System.Drawing.Point(1, 269);
                this.SavePanel.Size = new System.Drawing.Size(537, 56);
                SavePanel.Visible = true;
                btnDownload.Visible = false;
                if (Format == "Text")
                    CbmFileType.SelectedIndex = 1;
                else
                    CbmFileType.SelectedIndex = 0;
                lblHeader.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblHeader.Text = "Save As";
            }
        }

        public string GetFileName()
        {
            string SelAppKey = null;

            if (!(string.IsNullOrEmpty(TxtFileName.Text)))
                SelAppKey = TxtFileName.Text;

            return SelAppKey;
        }

        private void listViewPdf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Format == "Text")
            {
                string[] Name = Regex.Split(listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[0].Text.ToString(), ".txt");
                TxtFileName.Text = Name[0];
            }
            else
            {
                string[] Name = Regex.Split(listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[0].Text.ToString(), ".pdf");
                TxtFileName.Text = Name[0];
            }
            //TxtFileName.Text = listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[0].Text.ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(TxtFileName.Text.Trim())))
                MessageBox.Show("Please give a FileName ...", "CAP Systems", MessageBoxButtons.OK);
            else
            {
                Regex r = new Regex(@"[~`!@#$%^&*()-+=|\{}':;.,<>/?]");
                if (r.IsMatch(TxtFileName.Text))
                {

                    CommonFunctions.MessageBoxDisplay(@"A file name can't contain any of the following characters: \/:*?<>|""");

                }
                else
                {
                    if ((TxtFileName.Text.Contains(@"\")) || (TxtFileName.Text.Contains("/")) || (TxtFileName.Text.Contains('"')) || (TxtFileName.Text.Contains("<")) || (TxtFileName.Text.Contains(">")))
                    {
                        CommonFunctions.MessageBoxDisplay(@"A file name can't contain any of the following characters: \/:*?<>|""");
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }


        private void listViewPdf_MenuClick(object objSource, MenuItemEventArgs objArgs)
        {
            if (objArgs.MenuItem.Tag == "*")
            {
                listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[3].Text = "*";
                listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[3].ForeColor = Color.Red;
            }
            else if (objArgs.MenuItem.Tag == "MA")
            {
                foreach (ListViewItem item in listViewPdf.Items)
                {
                    item.SubItems[3].Text = "*";
                    item.SubItems[3].ForeColor = Color.Red;

                }
            }
            else if (objArgs.MenuItem.Tag == "UA")
            {
                foreach (ListViewItem item in listViewPdf.Items)
                {
                    item.SubItems[3].Text = string.Empty;
                }
            }
            else
            {
                listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[3].Text = string.Empty;
            }

        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            //if (Preview)
            //{
            //    if (listViewPdf.Items.Count > 0)
            //    {
            //        contextMenu1.MenuItems.Clear();
            //        if (listViewPdf.SelectedItems.Count > 0)
            //        {
            //            if (listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[3].Text.ToString() == "*")
            //            {
            //                MenuItem menuItem = new MenuItem();
            //                menuItem.Text = "Unmark";
            //                menuItem.Tag = "";
            //                contextMenu1.MenuItems.Add(menuItem);
            //                menuItem = new MenuItem();
            //                menuItem.Text = "Mark All";
            //                menuItem.Tag = "MA";
            //                contextMenu1.MenuItems.Add(menuItem);
            //                menuItem = new MenuItem();
            //                menuItem.Text = "Unmark All";
            //                menuItem.Tag = "UA";
            //                contextMenu1.MenuItems.Add(menuItem);
            //            }
            //            else
            //            {
            //                MenuItem menuItem = new MenuItem();
            //                menuItem.Text = "Mark";
            //                menuItem.Tag = "*";
            //                contextMenu1.MenuItems.Add(menuItem);
            //                menuItem = new MenuItem();
            //                menuItem.Text = "Mark All";
            //                menuItem.Tag = "MA";
            //                contextMenu1.MenuItems.Add(menuItem);
            //                menuItem = new MenuItem();
            //                menuItem.Text = "Unmark All";
            //                menuItem.Tag = "UA";
            //                contextMenu1.MenuItems.Add(menuItem);
            //            }

            //        }
            //    }
            //}

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

            string strPreviewFile = "";
            var selectedItems = listViewPdf.SelectedItems;
            if (selectedItems.Count > 0)
            {
                strDeleteType = "Download";
                strPreviewFile = listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[0].Text.ToString();
                MessageBox.Show("Are you sure you want to download this file " + strPreviewFile, Consts.Common.ApplicationCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxHandler, true);

            }



            ////  var selectedItems = listViewPdf.SelectedItems;
            //  if (selectedItems.Count > 0)
            //  {
            //      strPreviewFile = listViewPdf.Items[listViewPdf.SelectedIndex].SubItems[0].Text.ToString();
            //      FileDownloadGateway downloadGateway = new FileDownloadGateway();
            //      downloadGateway.Filename = strPreviewFile;

            //      // downloadGateway.Version = file.Version;

            //      downloadGateway.SetContentType(DownloadContentType.OctetStream);

            //      downloadGateway.StartFileDownload(new ContainerControl(),  strFolderPath + "\\" + strPreviewFile);
            //  }
        }


        public string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public string FriendlyName()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            intsourceName = 0;
            List<ListItem> SourceFilePaths = new List<ListItem>();
            bool boolmsg = false;
            if (listViewPdf.SelectedItems.Count >= 1)
            {
                int intseq = 0;
                //string name = listViewPdf.SelectedItems[0].Name.ToString();
                foreach (ListViewItem item in listViewPdf.Items)
                {
                    if (item.Selected == true)
                    {
                        if (item.Text.Contains(".xls"))
                        {
                            intseq = intseq + 1;
                            boolmsg = true;
                            SourceFilePaths.Add(new ListItem(item.Text.ToString(), intseq.ToString(), string.Empty, strFolderPath + item.Text.ToString()));//.Add(strFolderPath + item.Text.ToString());
                        }
                    }
                }
            }
            //MergeExcelForm mergeForm = new MergeExcelForm(SourceFilePaths);
            //mergeForm.FormClosed += new FormClosedEventHandler(mergeForm_FormClosed);
            //mergeForm.ShowDialog();

        }

        void mergeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MergeExcelForm form = sender as MergeExcelForm;
            //if (form.DialogResult == DialogResult.OK)
            //{
            //    List<ListItem> listDetails = form.listNames;
            //    if (listDetails.Count > 0)
            //    {
            //        listDetails = listDetails.OrderBy(u => Convert.ToInt32(u.Value)).ToList();
            //        DoMerge(listDetails, true);
            //        fillListView();
            //    }
            //}
        }
        int intsourceName = 0;
        void DoMerge(List<ListItem> _sourceFiles, bool boolmsg)
        {
            bool b = false;
            int i = 0;

            foreach (ListItem strFile in _sourceFiles)
            {
                i = i + 1;
                intsourceName = intsourceName + 1;
                NPOICOPY(strFile.ValueDisplayCode, i, intsourceName);
            }
            if (boolmsg)
                CommonFunctions.MessageBoxDisplay("Merge Sucessfully File Name is : MergeExcelSheets.xls");
        }
        HSSFWorkbook product = new HSSFWorkbook();
        void NPOICOPY(string filename, int X, int intsourceName)
        {

            byte[] byteArray = File.ReadAllBytes(filename);

            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, (int)byteArray.Length);

                HSSFWorkbook book1 = new HSSFWorkbook(stream);
                if (X == 1)
                {
                    product = new HSSFWorkbook();
                }
                for (int i = 0; i < book1.NumberOfSheets; i++)
                {
                    HSSFSheet sheet1 = book1.GetSheetAt(i) as HSSFSheet;
                    sheet1.CopyTo(product, sheet1.SheetName + intsourceName.ToString(), true, true);
                }
                string strName = "\\MergeExcelSheets.xls";
                using (FileStream fs = new FileStream((strFolderPath + strName), FileMode.Create, FileAccess.Write))
                {
                    product.Write(fs);

                }

            }


        }



    }


}