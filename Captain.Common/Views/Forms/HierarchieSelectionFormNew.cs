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
using Captain.Common.Views.Forms.Base;
using Captain.Common.Model.Objects;
using Captain.Common.Model.Data;
using Captain.Common.Utilities;

#endregion

namespace Captain.Common.Views.Forms
{
    public partial class HierarchieSelectionFormNew : Form
    {
        private ErrorProvider _errorProvider = null;
        private List<HierarchyEntity> _selectedHierarchies = null;
        private List<ListItem> _selectedListItem = null;
        private CaptainModel _model = null;
        private bool boolhierchy = true;
        public HierarchieSelectionFormNew()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with parameters. Hierachys display with Multi Selection records.(two grids)/// strType = "I" All Hierachy ****** Value Displayed
        /// strFilter ="D" Only CaseDep Records Displayed
        /// strFilter = "U" Only With Out CaseDep Records
        ///  strFilter = "*"  CaseHie Records with "******" Records.
        ///  strFilter = "A"  CaseHie Records with Out ****** Records.
        ///  strFormType ="I" Filter Records with Hierachys
        /// </summary>
        /// <param name="baseForm"></param>
        public HierarchieSelectionFormNew(BaseForm baseForm, List<HierarchyEntity> hierarchy, string mode, string strType, string strFilter, string strFormType, PrivilegeEntity privilegesEntity)
        {
            try
            {
                InitializeComponent();
                AddGridColumns(HierarchieGrid);
                BaseForm = baseForm;
                PrivilegeEntity = privilegesEntity;
                ListOfSelectedHierarchies = hierarchy;
                Mode = mode;
                string inTake = "I";
                this.Text = "Hierarchy Selection";
                HierarchyType = inTake;
                string strFormTypefilter = strFormType;
                _model = new CaptainModel();
                HierarchyEntity hierarchyAll = new HierarchyEntity();
                hierarchyAll.Code = "**-**-**";
                hierarchyAll.HirarchyName = "All Hierarchies";
                if (strFilter == "*")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, strFormTypefilter);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    if (ListOfSelectedHierarchies != null && ListOfSelectedHierarchies.Count > 0)
                    {
                        caseHierarchy.ForEach(item => item.InActiveFlag = (ListOfSelectedHierarchies.Exists(u => u.Code.Replace("-", string.Empty).Equals(item.Code.Replace("-", string.Empty)))) ? "true" : "false");
                    }
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        boolhierchy = true;
                        if (strFormType == "I")
                        {

                            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept == string.Empty && hierarchyEntity.Prog == string.Empty)
                            {
                                List<HierarchyEntity> caseHierarchyAgency = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency));
                                if (caseHierarchyAgency.Count <= 2)
                                {
                                    boolhierchy = false;
                                }

                            }
                            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept != string.Empty && hierarchyEntity.Prog == string.Empty)
                            {
                                List<HierarchyEntity> caseHierarchyDept = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency) && u.Dept.Equals(hierarchyEntity.Dept));
                                if (caseHierarchyDept.Count <= 1)
                                {
                                    boolhierchy = false;
                                }
                            }

                        }
                        if (boolhierchy)
                        {

                            rowIndex = gvwHierarchie.Rows.Add(hierarchyEntity.InActiveFlag, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                            gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                        }
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency == string.Empty ? "**" : hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept == string.Empty ? "**" : hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog == string.Empty ? "**" : hierarchyEntity.Prog;
                        //string code = hierarchyEntity.Agency == string.Empty ? "**" : hierarchyEntity.Agency + "-" + hierarchyEntity.Dept == string.Empty ? "**" : hierarchyEntity.Dept + "-" + hierarchyEntity.Prog == string.Empty ? "**" : hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        if (hierarchyEntity.Code == "**-**-**")
                        {
                            code = "**_**_**"; string Name = "All Hierarchies";
                            rowIndex = gvwSelectedHierarachies.Rows.Add(code, Name);
                        }
                        else
                            rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }
                else if (strFilter == "A")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, strFormTypefilter);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    if (ListOfSelectedHierarchies != null && ListOfSelectedHierarchies.Count > 0)
                    {
                        caseHierarchy.ForEach(item => item.InActiveFlag = (ListOfSelectedHierarchies.Exists(u => u.Code.Replace("-", string.Empty).Equals(item.Code.Replace("-", string.Empty)))) ? "true" : "false");
                    }
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {

                        if (!hierarchyEntity.Code.Contains('*'))
                        {
                            rowIndex = gvwHierarchie.Rows.Add(hierarchyEntity.InActiveFlag, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                            gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                        }
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }

                }
                else if (strFilter == "U")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy(string.Empty);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        //string isInActive = hierarchyEntity.InActiveFlag.Equals("N") ? "true" : "false";
                        rowIndex = gvwHierarchie.Rows.Add("false", hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }

                else if (strFilter == "D")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy("CaseDep", string.Empty, string.Empty, BaseForm.UserID);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        //string isInActive = hierarchyEntity.InActiveFlag.Equals("N") ? "true" : "false";
                        rowIndex = gvwHierarchie.Rows.Add("false", hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }


                EnableDisableCheckBox();

                AddGridEventHandles();
                _errorProvider = new ErrorProvider(this);
                _errorProvider.BlinkRate = 3;
                _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                _errorProvider.Icon = null;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Constructor with parameters. Hierachys display with Multi Selection records.(two grids)/// strType = "I" All Hierachy ****** Value Displayed
        /// strFilter ="D" Only CaseDep Records Displayed
        /// strFilter = "U" Only With Out CaseDep Records
        ///  strFilter = "*"  CaseHie Records with "******" Records.
        ///  strFilter = "A"  CaseHie Records with Out ****** Records.
        ///  strFormType ="I" Filter Records with Hierachys
        /// </summary>
        /// <param name="baseForm"></param>
        int Hie_Sel_Limit = 0, Sel_Hie_Cnt = 0;
        public HierarchieSelectionFormNew(BaseForm baseForm, List<HierarchyEntity> hierarchy, string mode, string strType, string strFilter, string strFormType, int hie_sel_limit)
        {
            try
            {
                InitializeComponent();
                AddGridColumns(HierarchieGrid);
                BaseForm = baseForm;
                ListOfSelectedHierarchies = hierarchy;
                Sel_Hie_Cnt = hierarchy.Count;
                Hie_Sel_Limit = hie_sel_limit;
                Mode = mode;
                string inTake = "I";
                this.Text = "Hierarchy Selection";
                HierarchyType = inTake;
                string strFormTypefilter = strFormType;
                _model = new CaptainModel();
                HierarchyEntity hierarchyAll = new HierarchyEntity();
                hierarchyAll.Code = "**-**-**";
                hierarchyAll.HirarchyName = "All Hierarchies";
                if (strFilter == "*")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, strFormTypefilter);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    if (ListOfSelectedHierarchies != null && ListOfSelectedHierarchies.Count > 0)
                    {
                        caseHierarchy.ForEach(item => item.InActiveFlag = (ListOfSelectedHierarchies.Exists(u => u.Code.Replace("-", string.Empty).Equals(item.Code.Replace("-", string.Empty)))) ? "true" : "false");
                    }
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        boolhierchy = true;
                        if (strFormType == "I")
                        {

                            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept == string.Empty && hierarchyEntity.Prog == string.Empty)
                            {
                                List<HierarchyEntity> caseHierarchyAgency = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency));
                                if (caseHierarchyAgency.Count <= 2)
                                {
                                    boolhierchy = false;
                                }

                            }
                            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept != string.Empty && hierarchyEntity.Prog == string.Empty)
                            {
                                List<HierarchyEntity> caseHierarchyDept = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency) && u.Dept.Equals(hierarchyEntity.Dept));
                                if (caseHierarchyDept.Count <= 1)
                                {
                                    boolhierchy = false;
                                }
                            }

                        }
                        if (boolhierchy)
                        {

                            rowIndex = gvwHierarchie.Rows.Add(hierarchyEntity.InActiveFlag, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                            gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                        }
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency == string.Empty ? "**" : hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept == string.Empty ? "**" : hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog == string.Empty ? "**" : hierarchyEntity.Prog;
                        //string code = hierarchyEntity.Agency == string.Empty ? "**" : hierarchyEntity.Agency + "-" + hierarchyEntity.Dept == string.Empty ? "**" : hierarchyEntity.Dept + "-" + hierarchyEntity.Prog == string.Empty ? "**" : hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        if (hierarchyEntity.Code == "**-**-**")
                        {
                            code = "**_**_**"; string Name = "All Hierarchies";
                            rowIndex = gvwSelectedHierarachies.Rows.Add(code, Name);
                        }
                        else
                            rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }
                else if (strFilter == "A")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, strFormTypefilter);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    if (ListOfSelectedHierarchies != null && ListOfSelectedHierarchies.Count > 0)
                    {
                        caseHierarchy.ForEach(item => item.InActiveFlag = (ListOfSelectedHierarchies.Exists(u => u.Code.Replace("-", string.Empty).Equals(item.Code.Replace("-", string.Empty)))) ? "true" : "false");
                    }
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {

                        if (!hierarchyEntity.Code.Contains('*'))
                        {
                            rowIndex = gvwHierarchie.Rows.Add(hierarchyEntity.InActiveFlag, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                            gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                        }
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }

                }
                else if (strFilter == "U")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy(string.Empty);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        //string isInActive = hierarchyEntity.InActiveFlag.Equals("N") ? "true" : "false";
                        rowIndex = gvwHierarchie.Rows.Add("false", hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }

                else if (strFilter == "D")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy("CaseDep", string.Empty, string.Empty, BaseForm.UserID);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        //string isInActive = hierarchyEntity.InActiveFlag.Equals("N") ? "true" : "false";
                        rowIndex = gvwHierarchie.Rows.Add("false", hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }


                EnableDisableCheckBox();

                AddGridEventHandles();
                _errorProvider = new ErrorProvider(this);
                _errorProvider.BlinkRate = 3;
                _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                _errorProvider.Icon = null;
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// Constructor with parameters. Hierachys display with Single Selection records.
        /// strType = "I" All Hierachy ****** Value Displayed
        /// strFilter ="D" Only CaseDep Records Displayed
        /// strFilter = "U" Only With Out CaseDep Records
        ///  strFilter = "*"  CaseHie Records with "******" Records.
        ///  strFilter = "A"  CaseHie Records with Out ****** Records.
        ///  strFormType ="I" Filter Records with Hierachys
        /// </summary>
        /// <param name="baseForm"></param>
        public HierarchieSelectionFormNew(BaseForm baseForm, string hierarchy, string mode, string strType, string strFilter, string strFormType)
        {
            try
            {
                InitializeComponent();
                AddGridColumns(HierarchieGrid);
                BaseForm = baseForm;
                Mode = "Program";
                string inTake = "I";
                this.Text = "Hierarchy Selection";
                lblChoose.Text = "Choose Hierarchy Here";
                HierarchyType = inTake;

                _model = new CaptainModel();
                HierarchyEntity hierarchyAll = new HierarchyEntity();
                hierarchyAll.Code = "**-**-**";
                hierarchyAll.HirarchyName = "All Hierarchies";
                if (strFilter == "*")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, strFormType);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;

                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        boolhierchy = true;
                        if (strFormType == "I")
                        {
                            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept == string.Empty && hierarchyEntity.Prog == string.Empty)
                            {
                                List<HierarchyEntity> caseHierarchyAgency = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency));
                                if (caseHierarchyAgency.Count <= 2)
                                {
                                    boolhierchy = false;
                                }

                            }
                            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept != string.Empty && hierarchyEntity.Prog == string.Empty)
                            {
                                List<HierarchyEntity> caseHierarchyDept = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency) && u.Dept.Equals(hierarchyEntity.Dept));
                                if (caseHierarchyDept.Count <= 1)
                                {
                                    boolhierchy = false;
                                }
                            }

                        }
                        if (boolhierchy)
                        {
                            if (hierarchyEntity.Code == hierarchy)
                            {
                                rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                            }
                            // string isInActive = hierarchyEntity.InActiveFlag.Equals("N") ? "true" : "false";
                            else
                            {
                                rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                            }
                            gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                        }
                    }
                }
                else if (strFilter == "A")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, strFormType);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        if (!hierarchyEntity.Code.Contains('*'))
                        {
                            if (hierarchyEntity.Code == hierarchy)
                            {
                                rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                            }
                            else
                            {
                                rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                            }
                            gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                        }

                    }

                }
                else if (strFilter == "U")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy(string.Empty);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        if (hierarchyEntity.Code == hierarchy)
                        {
                            rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        }
                        else
                        {
                            rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        }
                        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }
                else if (strFilter == "D")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy("CaseDep", string.Empty, string.Empty, BaseForm.UserID);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        if (hierarchyEntity.Code == hierarchy)
                        {
                            rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        }
                        else
                        {
                            rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        }
                        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }
                EnableDisableCheckBox();
                gvwSelectedHierarachies.Visible = false;
                lblSelected.Visible = false;
                lblChoose.Location = new Point(12, 6);
                gvwHierarchie.Location = new Point(9, 25);
                gvwHierarchie.Size = new System.Drawing.Size(413, 347);
                gvwHierarchie.DataError += new DataGridViewDataErrorEventHandler(DataGridViewDataError);
                AddGridEventHandles();
                _errorProvider = new ErrorProvider(this);
                _errorProvider.BlinkRate = 3;
                _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                _errorProvider.Icon = null;


            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Constructor with parameters. Hierachys display with Single Selection records.
        /// strType = "I" All Hierachy ****** Value Displayed
        /// strFilter ="D" Only CaseDep Records Displayed
        /// strFilter = "U" Only With Out CaseDep Records
        ///  strFilter = "*"  CaseHie Records with "******" Records.
        ///  strFilter = "A"  CaseHie Records with Out ****** Records.
        ///  strFormType ="I" Filter Records with Hierachys
        /// </summary>
        /// <param name="baseForm"></param>
        public HierarchieSelectionFormNew(BaseForm baseForm, string hierarchy, string mode, string strType, string strFilter, string strFormType, string ScreenName)
        {
            try
            {
                InitializeComponent();
                AddGridColumns(HierarchieGrid);
                BaseForm = baseForm;
                Mode = "Program";
                string inTake = "I";
                this.Text = "Hierarchy Selection";
                lblChoose.Text = "Choose Hierarchy Here";
                HierarchyType = inTake;

                _model = new CaptainModel();
                HierarchyEntity hierarchyAll = new HierarchyEntity();
                hierarchyAll.Code = "**-**-**";
                hierarchyAll.HirarchyName = "All Hierarchies";
                if (strFilter == "*")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, strFormType);
                    List<SERVSTOPEntity> SERVSTOPList = _model.CaseSumData.GetSERVSTOPDet(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;

                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        bool IsFact = true;
                        if (SERVSTOPList.Count > 0)
                        {
                            SERVSTOPEntity SelEnt = SERVSTOPList.Find(u => u.Agency == hierarchyEntity.Code.Substring(0,2) && u.Dept == hierarchyEntity.Code.Substring(3, 2) && u.Program == hierarchyEntity.Code.Substring(6, 2));
                            if (SelEnt != null) IsFact = false;
                        }
                        boolhierchy = true;
                        if (strFormType == "I")
                        {
                            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept == string.Empty && hierarchyEntity.Prog == string.Empty)
                            {
                                List<HierarchyEntity> caseHierarchyAgency = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency));
                                if (caseHierarchyAgency.Count <= 2)
                                {
                                    boolhierchy = false;
                                }

                            }
                            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept != string.Empty && hierarchyEntity.Prog == string.Empty)
                            {
                                List<HierarchyEntity> caseHierarchyDept = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency) && u.Dept.Equals(hierarchyEntity.Dept));
                                if (caseHierarchyDept.Count <= 1)
                                {
                                    boolhierchy = false;
                                }
                            }

                        }

                        if (IsFact)
                        {
                            if (boolhierchy)
                            {
                                if (hierarchyEntity.Code == hierarchy)
                                {
                                    rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                                }
                                // string isInActive = hierarchyEntity.InActiveFlag.Equals("N") ? "true" : "false";
                                else
                                {
                                    rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                                }
                                gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                            }
                        }
                    }
                }
                else if (strFilter == "A")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, strFormType);
                    List<SERVSTOPEntity> SERVSTOPList = _model.CaseSumData.GetSERVSTOPDet(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        bool IsFact = true;
                        if (SERVSTOPList.Count > 0)
                        {
                            SERVSTOPEntity SelEnt = SERVSTOPList.Find(u => u.Agency == hierarchyEntity.Agency && u.Dept == hierarchyEntity.Dept && u.Program == hierarchyEntity.Prog);
                            if (SelEnt != null) IsFact = false;
                        }

                        if (IsFact)
                        {
                            if (!hierarchyEntity.Code.Contains('*'))
                            {
                                if (hierarchyEntity.Code == hierarchy)
                                {
                                    rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                                }
                                else
                                {
                                    rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                                }
                                gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                            }
                        }

                    }

                }
                else if (strFilter == "U")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy(string.Empty);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        if (hierarchyEntity.Code == hierarchy)
                        {
                            rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        }
                        else
                        {
                            rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        }
                        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }
                else if (strFilter == "D")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy("CaseDep", string.Empty, string.Empty, BaseForm.UserID);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        if (hierarchyEntity.Code == hierarchy)
                        {
                            rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        }
                        else
                        {
                            rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        }
                        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }
                EnableDisableCheckBox();
                gvwSelectedHierarachies.Visible = false;
                lblSelected.Visible = false;
                lblChoose.Location = new Point(12, 6);
                gvwHierarchie.Location = new Point(9, 25);
                gvwHierarchie.Size = new System.Drawing.Size(413, 347);
                gvwHierarchie.DataError += new DataGridViewDataErrorEventHandler(DataGridViewDataError);
                AddGridEventHandles();
                _errorProvider = new ErrorProvider(this);
                _errorProvider.BlinkRate = 3;
                _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                _errorProvider.Icon = null;


            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// Constructor with parameters. Hierachys display with Single Selection records.
        /// strType = "I" All Hierachy ****** Value Displayed
        /// strFilter ="D" Only CaseDep Records Displayed
        /// strFilter = "U" Only With Out CaseDep Records
        ///  strFilter = "*"  CaseHie Records with "******" Records.
        ///  strFilter = "A"  CaseHie Records with Out ****** Records.
        ///  strFormType ="I" Filter Records with Hierachys
        /// </summary>
        /// <param name="baseForm"></param>
        public HierarchieSelectionFormNew(BaseForm baseForm, string hierarchy, string Ser_Plan)
        {
            try
            {
                InitializeComponent();
                AddGridColumns(HierarchieGrid);
                BaseForm = baseForm;
                Mode = "Program";
                string inTake = "I";
                this.Text = "Hierarchy Selection";
                lblChoose.Text = "Choose Hierarchy Here";
                HierarchyType = inTake;

                _model = new CaptainModel();
                HierarchyEntity hierarchyAll = new HierarchyEntity();
                List<HierarchyEntity> caseHierarchy;
                if (Ser_Plan == "CASEHIE")
                {
                    caseHierarchy = _model.HierarchyAndPrograms.GetCaseHierarchy("PROGRAM", BaseForm.BaseAgency, BaseForm.BaseDept);
                }
                else
                {
                    caseHierarchy = _model.lookupDataAccess.Get_SerPlan_Prog_List(BaseForm.UserProfile.UserID, Ser_Plan,string.Empty);
                }
                int rowIndex = 0;

                foreach (HierarchyEntity Ent in caseHierarchy)
                {
                    if (hierarchy == Ent.Agency + Ent.Dept + Ent.Prog)
                        rowIndex = gvwHierarchie.Rows.Add(true, Ent.Code, Ent.HirarchyName);
                    else
                        rowIndex = gvwHierarchie.Rows.Add(false, Ent.Code, Ent.HirarchyName);
                }

                gvwSelectedHierarachies.Visible = false;
                lblSelected.Visible = false;
                lblChoose.Location = new Point(12, 6);
                gvwHierarchie.Location = new Point(9, 25);
                gvwHierarchie.Size = new System.Drawing.Size(413, 347);

                AddGridEventHandles();
                _errorProvider = new ErrorProvider(this);
                _errorProvider.BlinkRate = 3;
                _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                _errorProvider.Icon = null;


                //hierarchyAll.Code = "**-**-**";
                //hierarchyAll.HirarchyName = "All Hierarchies";
                ////if (strFilter == "*")
                //{
                //    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, "I");
                //    int rowIndex = 0;

                //    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                //    {
                //        boolhierchy = true;
                //        if (!hierarchyEntity.Code.Contains("**"))
                //        {
                //            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept == string.Empty && hierarchyEntity.Prog == string.Empty)
                //            {
                //                List<HierarchyEntity> caseHierarchyAgency = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency));
                //                if (caseHierarchyAgency.Count <= 2)
                //                {
                //                    boolhierchy = false;
                //                }

                //            }
                //            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept != string.Empty && hierarchyEntity.Prog == string.Empty)
                //            {
                //                List<HierarchyEntity> caseHierarchyDept = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency) && u.Dept.Equals(hierarchyEntity.Dept));
                //                if (caseHierarchyDept.Count <= 1)
                //                {
                //                    boolhierchy = false;
                //                }
                //            }

                //        }
                //        if (boolhierchy)
                //        {
                //            if (hierarchyEntity.Code == hierarchy)
                //            {
                //                rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                //            }
                //            // string isInActive = hierarchyEntity.InActiveFlag.Equals("N") ? "true" : "false";
                //            else
                //            {
                //                rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                //            }
                //            gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                //        }
                //    }
                //}
                //else if (strFilter == "A")
                //{
                //    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, strFormType);
                //    if (strType == "I")
                //        caseHierarchy.Insert(0, hierarchyAll);
                //    int rowIndex = 0;
                //    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                //    {
                //        if (!hierarchyEntity.Code.Contains('*'))
                //        {
                //            if (hierarchyEntity.Code == hierarchy)
                //            {
                //                rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                //            }
                //            else
                //            {
                //                rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                //            }
                //            gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                //        }

                //    }

                //}
                //else if (strFilter == "U")
                //{
                //    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy(string.Empty);
                //    if (strType == "I")
                //        caseHierarchy.Insert(0, hierarchyAll);
                //    int rowIndex = 0;
                //    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                //    {
                //        if (hierarchyEntity.Code == hierarchy)
                //        {
                //            rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                //        }
                //        else
                //        {
                //            rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                //        }
                //        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                //    }
                //}
                //else if (strFilter == "D")
                //{
                //    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy("CaseDep", string.Empty, string.Empty, BaseForm.UserID);
                //    if (strType == "I")
                //        caseHierarchy.Insert(0, hierarchyAll);
                //    int rowIndex = 0;
                //    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                //    {
                //        if (hierarchyEntity.Code == hierarchy)
                //        {
                //            rowIndex = gvwHierarchie.Rows.Add(true, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                //        }
                //        else
                //        {
                //            rowIndex = gvwHierarchie.Rows.Add(false, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                //        }
                //        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                //    }
                //}
                //EnableDisableCheckBox();
                //gvwSelectedHierarachies.Visible = false;
                //lblSelected.Visible = false;
                //lblChoose.Location = new Point(12, 6);
                //gvwHierarchie.Location = new Point(9, 25);
                //gvwHierarchie.Size = new System.Drawing.Size(413, 347);
                //gvwHierarchie.DataError += new DataGridViewDataErrorEventHandler(DataGridViewDataError);
                //AddGridEventHandles();
                //_errorProvider = new ErrorProvider(this);
                //_errorProvider.BlinkRate = 3;
                //_errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                //_errorProvider.Icon = null;


            }
            catch (Exception)
            {
            }
        }


        public HierarchieSelectionFormNew(BaseForm baseForm, string hierarchy, string Ser_Plan, string strBaseFilter)
        {
            try
            {
                InitializeComponent();
                AddGridColumns(HierarchieGrid);
                BaseForm = baseForm;
                Mode = "Program";
                string inTake = "I";
                this.Text = "Hierarchy Selection";
                lblChoose.Text = "Choose Hierarchy Here";
                HierarchyType = inTake;

                if (strBaseFilter == "Y" || strBaseFilter == "S") HierarchyType = "S";

                _model = new CaptainModel();
                HierarchyEntity hierarchyAll = new HierarchyEntity();

                

                List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.Get_SerPlan_Prog_List(BaseForm.UserProfile.UserID, Ser_Plan, HierarchyType);
                int rowIndex = 0;

                //Added by sudheer on 08/11/2021 baed on the service plan hierarchies
                if(caseHierarchy.Count>0)
                {
                    if (BaseForm.BaseAgencyControlDetails.SerPlanAllow.Trim() == "D")
                        caseHierarchy = caseHierarchy.FindAll(u => u.Agency == BaseForm.BaseAgency && (u.Dept == BaseForm.BaseDept || u.Dept=="**"));
                    else
                        caseHierarchy = caseHierarchy.FindAll(u => u.Agency == BaseForm.BaseAgency);
                }

                //Added by sudheer on 07/24/2021 baed on the service plan hierarchies
                if (HierarchyType == "S")
                {
                    foreach (HierarchyEntity Ent in caseHierarchy)
                    {
                        if (!Ent.Code.Contains('*'))
                        {
                            if (hierarchy == Ent.Agency + Ent.Dept + Ent.Prog)
                                rowIndex = gvwHierarchie.Rows.Add(true, Ent.Code, Ent.HirarchyName);
                            else
                                rowIndex = gvwHierarchie.Rows.Add(false, Ent.Code, Ent.HirarchyName);

                        }
                    }
                }
                else
                {
                    caseHierarchy = caseHierarchy.FindAll(u => u.Agency == BaseForm.BaseAgency);
                    foreach (HierarchyEntity Ent in caseHierarchy)
                    {
                        if (hierarchy == Ent.Agency + Ent.Dept + Ent.Prog)
                            rowIndex = gvwHierarchie.Rows.Add(true, Ent.Code, Ent.HirarchyName);
                        else
                            rowIndex = gvwHierarchie.Rows.Add(false, Ent.Code, Ent.HirarchyName);
                    }
                }

                gvwSelectedHierarachies.Visible = false;
                lblSelected.Visible = false;
                lblChoose.Location = new Point(12, 6);
                gvwHierarchie.Location = new Point(9, 25);
                gvwHierarchie.Size = new System.Drawing.Size(413, 347);

                AddGridEventHandles();
                _errorProvider = new ErrorProvider(this);
                _errorProvider.BlinkRate = 3;
                _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                _errorProvider.Icon = null;

            }
            catch (Exception)
            {
            }
        }


        public string Selected_SerPlan_Prog()
        {
            string Sele_Prog = "", Tmp_Prog = "";

            foreach (DataGridViewRow dr in gvwHierarchie.Rows)
            {
                if (dr.Cells["Select"].Value.ToString() == true.ToString())
                {
                    Tmp_Prog = dr.Cells["Code"].Value.ToString();
                    Tmp_Prog = Tmp_Prog.Replace("-", "");
                    Sele_Prog = Tmp_Prog + " - " + dr.Cells["Description"].Value.ToString().Trim();
                    break;
                }
            }

            return Sele_Prog;
        }



        /// <summary>
        /// Constructor with parameters.  display with Multi Selection records.(two grids) AddtionalPriviliges
        /// </summary>
        /// <param name="baseForm"></param>
        public HierarchieSelectionFormNew(BaseForm baseForm, List<ListItem> listComponents)
        {
            try
            {
                InitializeComponent();
                AddGridColumns(HierarchieGrid);
                BaseForm = baseForm;
                // ListOfSelectedHierarchies = hierarchy;
                Mode = "Components";
                string inTake = "I";
                lblSelected.Text = "Selected Components";
                lblChoose.Text = "Choose Components Here";
                this.Text = "Components Selection";
                HierarchyType = inTake;
                ListOfSelectedComponents = listComponents;
                _model = new CaptainModel();

                List<SPCommonEntity> AgyCommon_List = new List<SPCommonEntity>();
                AgyCommon_List = _model.SPAdminData.Get_AgyRecs("COMPONENTS");

                AgyCommon_List = AgyCommon_List.OrderBy(u => u.Code.Trim()).ToList();

                //DataSet ds = Captain.DatabaseLayer.Lookups.GetAdditionalPrivileges();
                //DataTable dt = ds.Tables[0];
                List<ListItem> listItem = new List<ListItem>();

                listItem.Add(new ListItem("None", "None", "false", "false"));
                listItem.Add(new ListItem("All", "****", "false", "false"));

                if (AgyCommon_List.Count > 0)
                {
                    foreach (SPCommonEntity Entity in AgyCommon_List)
                    {
                        listItem.Add(new ListItem(Entity.Desc, Entity.Code, "false", "false"));
                    }
                }

                //foreach (DataRow dr in dt.Rows)
                //{
                //    listItem.Add(new ListItem(dr["AGY_7"].ToString(), dr["AGY_4"].ToString(), "false", "false"));
                //}

                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                int rowIndex = 0;
                if (ListOfSelectedComponents != null && ListOfSelectedComponents.Count > 0)
                {
                    listItem.ForEach(item => item.ValueDisplayCode = (ListOfSelectedComponents.Exists(u => u.Value.Equals(item.Value))) ? "true" : "false");
                }
                foreach (ListItem ListEntity in listItem)
                {
                    rowIndex = gvwHierarchie.Rows.Add(ListEntity.ValueDisplayCode, ListEntity.Value, ListEntity.Text);
                    gvwHierarchie.Rows[rowIndex].Tag = ListEntity;
                }
                foreach (ListItem seletedComponents in ListOfSelectedComponents)
                {
                    //code = "**_**_**"; string Name = "All Hierarchies";
                    //rowIndex = gvwSelectedHierarachies.Rows.Add(code, Name);
                    rowIndex = gvwSelectedHierarachies.Rows.Add(seletedComponents.Value, seletedComponents.Text);
                    gvwSelectedHierarachies.Rows[rowIndex].Tag = seletedComponents;
                }




                EnableDisableCheckBoxComponents();

                AddGridEventHandles();
                _errorProvider = new ErrorProvider(this);
                _errorProvider.BlinkRate = 3;
                _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                _errorProvider.Icon = null;
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// Constructor with parameters. Hierachys display with Multi Selection records.(two grids)/// strType = "I" All Hierachy ****** Value Displayed
        /// strFilter ="D" Only CaseDep Records Displayed
        /// strFilter = "U" Only With Out CaseDep Records
        ///  strFilter = "*"  CaseHie Records with "******" Records.
        ///  strFilter = "A"  CaseHie Records with Out ****** Records.
        ///  strFormType ="I" Filter Records with Hierachys
        ///  Screenusing Assignuseraccounts
        /// </summary>
        /// <param name="baseForm"></param>
        public HierarchieSelectionFormNew(BaseForm baseForm, List<HierarchyEntity> hierarchy, string mode, string strType, string strFilter, string strFormType, UserEntity userProfile)
        {
            try
            {
                InitializeComponent();
                AddGridColumns(HierarchieGrid);
                BaseForm = baseForm;
                ListOfSelectedHierarchies = hierarchy;
                Mode = mode;
                string inTake = "I";
                this.Text = "Hierarchy Selection";
                HierarchyType = inTake;
                string strFormTypefilter = strFormType;
                _model = new CaptainModel();
                HierarchyEntity hierarchyAll = new HierarchyEntity();
                hierarchyAll.Code = "**-**-**";
                hierarchyAll.HirarchyName = "All Hierarchies";
                if (strFilter == "*")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(UserProfile != null ? UserProfile.UserID : string.Empty, HierarchyType, strFormTypefilter);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    if (ListOfSelectedHierarchies != null && ListOfSelectedHierarchies.Count > 0)
                    {
                        caseHierarchy.ForEach(item => item.InActiveFlag = (ListOfSelectedHierarchies.Exists(u => u.Code.Replace("-", string.Empty).Equals(item.Code.Replace("-", string.Empty)))) ? "true" : "false");
                    }
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        boolhierchy = true;
                        if (strFormType == "I")
                        {

                            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept == string.Empty && hierarchyEntity.Prog == string.Empty)
                            {
                                List<HierarchyEntity> caseHierarchyAgency = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency));
                                if (caseHierarchyAgency.Count <= 2)
                                {
                                    boolhierchy = false;
                                }

                            }
                            if (hierarchyEntity.Agency != string.Empty && hierarchyEntity.Dept != string.Empty && hierarchyEntity.Prog == string.Empty)
                            {
                                List<HierarchyEntity> caseHierarchyDept = caseHierarchy.FindAll(u => u.Agency.Equals(hierarchyEntity.Agency) && u.Dept.Equals(hierarchyEntity.Dept));
                                if (caseHierarchyDept.Count <= 1)
                                {
                                    boolhierchy = false;
                                }
                            }

                        }
                        if (boolhierchy)
                        {

                            rowIndex = gvwHierarchie.Rows.Add(hierarchyEntity.InActiveFlag, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                            gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                        }
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency == string.Empty ? "**" : hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept == string.Empty ? "**" : hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog == string.Empty ? "**" : hierarchyEntity.Prog;
                        //string code = hierarchyEntity.Agency == string.Empty ? "**" : hierarchyEntity.Agency + "-" + hierarchyEntity.Dept == string.Empty ? "**" : hierarchyEntity.Dept + "-" + hierarchyEntity.Prog == string.Empty ? "**" : hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        if (hierarchyEntity.Code == "**-**-**")
                        {
                            code = "**_**_**"; string Name = "All Hierarchies";
                            rowIndex = gvwSelectedHierarachies.Rows.Add(code, Name);
                        }
                        else
                            rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }
                else if (strFilter == "A")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetHierarchyByUserID(BaseForm.UserProfile.UserID, HierarchyType, strFormTypefilter);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    if (ListOfSelectedHierarchies != null && ListOfSelectedHierarchies.Count > 0)
                    {
                        caseHierarchy.ForEach(item => item.InActiveFlag = (ListOfSelectedHierarchies.Exists(u => u.Code.Replace("-", string.Empty).Equals(item.Code.Replace("-", string.Empty)))) ? "true" : "false");
                    }
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {

                        if (!hierarchyEntity.Code.Contains('*'))
                        {
                            rowIndex = gvwHierarchie.Rows.Add(hierarchyEntity.InActiveFlag, hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                            gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                        }
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }

                }
                else if (strFilter == "U")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy(string.Empty);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        //string isInActive = hierarchyEntity.InActiveFlag.Equals("N") ? "true" : "false";
                        rowIndex = gvwHierarchie.Rows.Add("false", hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }

                else if (strFilter == "D")
                {
                    List<HierarchyEntity> caseHierarchy = _model.lookupDataAccess.GetCaseHierarchy("CaseDep", string.Empty, string.Empty, BaseForm.UserID);
                    if (strType == "I")
                        caseHierarchy.Insert(0, hierarchyAll);
                    int rowIndex = 0;
                    foreach (HierarchyEntity hierarchyEntity in caseHierarchy)
                    {
                        //string isInActive = hierarchyEntity.InActiveFlag.Equals("N") ? "true" : "false";
                        rowIndex = gvwHierarchie.Rows.Add("false", hierarchyEntity.Code, hierarchyEntity.HirarchyName);
                        gvwHierarchie.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                    foreach (HierarchyEntity hierarchyEntity in ListOfSelectedHierarchies)
                    {
                        string strAgency = hierarchyEntity.Agency;
                        string strDept = hierarchyEntity.Dept;
                        string strProgram = hierarchyEntity.Prog;
                        string code = strAgency + "-" + strDept + "-" + strProgram;
                        rowIndex = gvwSelectedHierarachies.Rows.Add(code, hierarchyEntity.HirarchyName);
                        gvwSelectedHierarachies.Rows[rowIndex].Tag = hierarchyEntity;
                    }
                }


                EnableDisableCheckBox();

                AddGridEventHandles();
                _errorProvider = new ErrorProvider(this);
                _errorProvider.BlinkRate = 3;
                _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                _errorProvider.Icon = null;
            }
            catch (Exception)
            {
            }
        }



        private void fillAddlPrivileges()
        {
            DataSet ds = Captain.DatabaseLayer.Lookups.GetAdditionalPrivileges();
            DataTable dt = ds.Tables[0];
            List<ListItem> listItem = new List<ListItem>();

            listItem.Add(new ListItem("None", "0"));
            listItem.Add(new ListItem("All", "****"));
            foreach (DataRow dr in dt.Rows)
            {
                listItem.Add(new ListItem(dr["AGY_7"].ToString(), dr["AGY_4"].ToString()));
            }

        }


        #region Properties

        public TagClass SelectedNodeTagClass { get; set; }

        public BaseForm BaseForm { get; set; }
        PrivilegeEntity PrivilegeEntity = new PrivilegeEntity();

        public string HierarchyType { get; set; }

        public DataGridView HierarchieGrid
        {
            get { return gvwHierarchie; }
        }

        public List<HierarchyEntity> ListOfSelectedHierarchies
        {
            get;
            set;
        }

        public List<ListItem> ListOfSelectedComponents
        {
            get;
            set;
        }

        public UserEntity UserProfile { get; set; }

        public string Mode { get; set; }

        public string Prog_Multiple_sel { get; set; }

        public DataGridViewRow HierarchieGridRow
        {
            get;
            set;
        }

        public List<HierarchyEntity> SelectedHierarchies
        {
            get
            {
                return _selectedHierarchies = (from c in gvwHierarchie.Rows.Cast<DataGridViewRow>().ToList()
                                               where (((DataGridViewCheckBoxCell)c.Cells["Select"]).Value.ToString().Equals(Consts.YesNoVariants.True, StringComparison.CurrentCultureIgnoreCase))
                                               select ((DataGridViewRow)c).Tag as HierarchyEntity).ToList();

            }
        }

        public List<ListItem> SelectedListItems
        {
            get
            {
                return _selectedListItem = (from c in gvwHierarchie.Rows.Cast<DataGridViewRow>().ToList()
                                            where (((DataGridViewCheckBoxCell)c.Cells["Select"]).Value.ToString().Equals(Consts.YesNoVariants.True, StringComparison.CurrentCultureIgnoreCase))
                                            select ((DataGridViewRow)c).Tag as ListItem).ToList();

            }
        }

        public string SelectedItem
        {
            get;
            set;
        }

        public List<RowState> ExpandedRows { get; set; }

        #endregion


        #region Private Methods

        private bool ValidateForm()
        {
            bool isValid = true;

            if (gvwHierarchie.Rows.Count > 0)
            {
                int invalidRecords = 0;
                foreach (DataGridViewRow item in gvwHierarchie.Rows)
                {
                    if (string.IsNullOrEmpty(item.Cells[1].Value.ToString().Trim()))
                    {
                        invalidRecords++;
                        break;
                    }
                }
                if (invalidRecords > 0)
                {
                    //_errorProvider.SetError(gvwConvertObject, Consts.Messages.AllObjectTypeSelectionRequired.GetMessage());
                    isValid = false;
                }
                else
                {
                    //_errorProvider.SetError(gvwHierarchie, Convert.ToString(""));
                }
            }

            return (isValid);
        }

        /// <summary>
        /// Add the columns to the grid.
        /// </summary>
        /// <param name="dataGridView"></param>
        private void AddGridColumns(DataGridView dataGridView)
        {
            DataGridViewCheckBoxColumn dataTypeColumn = null;
            string columnName = string.Empty;

            gvwHierarchie.Columns.Clear();
            // 
            // DatatypeColumn

            dataTypeColumn = new DataGridViewCheckBoxColumn();
            dataTypeColumn.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            dataTypeColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            dataTypeColumn.HeaderText = "Select";
            dataTypeColumn.Name = "Select";
            dataTypeColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            dataTypeColumn.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            dataTypeColumn.Width = 40;
            dataGridView.Columns.Add(dataTypeColumn);

            DataGridViewTextBoxColumn codeColumn = new DataGridViewTextBoxColumn();
            codeColumn.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            codeColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            codeColumn.CellTemplate = new DataGridViewTextBoxCell();
            codeColumn.HeaderText = "Code";
            codeColumn.Name = "Code";
            codeColumn.ReadOnly = true;
            codeColumn.Width = 70;
            dataGridView.Columns.Add(codeColumn);

            DataGridViewTextBoxColumn descColumn = new DataGridViewTextBoxColumn();
            descColumn.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            descColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            descColumn.CellTemplate = new DataGridViewTextBoxCell();
            descColumn.HeaderText = "Description";
            descColumn.Name = "Description";
            descColumn.ReadOnly = true;
            descColumn.Width = 300;
            dataGridView.Columns.Add(descColumn);
        }


        /// <summary>
        /// Adds the event handlers to the grid
        /// </summary>
        private void AddGridEventHandles()
        {
            gvwHierarchie.DataError += new Gizmox.WebGUI.Forms.DataGridViewDataErrorEventHandler(DataGridViewDataError);
            //gvwHierarchie.CellValueChanged += new DataGridViewCellEventHandler(DataGridViewCellValueChanged);
            // Commented By Yeswanth on 11/25/2014 Because of this an issue rised only in CAPOK Site and good in rest the of site
            // Added Below logic to avoid the issue
            gvwHierarchie.CellClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }

        /// <summary>
        /// Removes the event handlers from the grid.
        /// </summary>
        private void RemoveGridEventHandles()
        {
            gvwHierarchie.DataError -= new DataGridViewDataErrorEventHandler(DataGridViewDataError);
            gvwHierarchie.CellValueChanged -= new DataGridViewCellEventHandler(DataGridViewCellValueChanged);
        }

        private void EnableDisableCheckBox()
        {
            if (SelectedHierarchies.Count == 0) { return; }
            foreach (HierarchyEntity hierarchyEntity in SelectedHierarchies)
            {
                string selectedHIE = hierarchyEntity.Code;

                if (selectedHIE.IndexOf("**") > 0 || selectedHIE.Equals("**-**-**"))
                {
                    string selectedHierarchy = selectedHIE.Replace("-**", string.Empty);
                    foreach (DataGridViewRow dr in gvwHierarchie.Rows)
                    {
                        string rowCode = dr.Cells["Code"].Value.ToString();
                        if (selectedHIE.Equals("**-**-**") && !rowCode.Equals(selectedHIE))
                        {
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }
                        else if (rowCode.StartsWith(selectedHierarchy) && !rowCode.Equals(selectedHIE))
                        {
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }
                    }
                }
                gvwHierarchie.Update();
                gvwHierarchie.ResumeLayout();
            }
        }

        private void EnableDisableCheckBoxComponents()
        {
            if (SelectedHierarchies.Count == 0) { return; }
            foreach (ListItem hierarchyEntity in SelectedListItems)
            {
                string selectedHIE = hierarchyEntity.Value.ToString();



                if (selectedHIE.IndexOf("**") > 0 || selectedHIE.Equals("****") || selectedHIE.Equals("None"))
                {
                    string selectedHierarchy = selectedHIE.Replace("-**", string.Empty);
                    foreach (DataGridViewRow dr in gvwHierarchie.Rows)
                    {

                        string rowCode = dr.Cells["Code"].Value.ToString();
                        if (selectedHIE.Equals("****") && !rowCode.Equals(selectedHIE))
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;

                        }
                        else if (selectedHIE.Equals("None") && !rowCode.Equals(selectedHIE))
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }

                    }
                }
                gvwHierarchie.Update();
                gvwHierarchie.ResumeLayout();
            }
        }

        #endregion

        #region Handled Events

        /// <summary>
        /// Handles the grid value changed event and keeps track of the changes made on the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView hierarchicalGrid = sender as DataGridView;
            string selectedHIE = hierarchicalGrid.SelectedRows[0].Cells["Code"].Value.ToString();
            bool isSelect = false;
            if (hierarchicalGrid.SelectedRows[0].Cells["Select"].Value.ToString().Equals(Consts.YesNoVariants.True, StringComparison.CurrentCultureIgnoreCase))
            {
                isSelect = true;
            }                         // Commented By Yeswanth on 11/25/2014 Because of this an issue rised only in CAPOK Site and good in rest the of site

            if (Mode.Equals("Program"))
            {
                if (Prog_Multiple_sel != "Hie_multiple_sel")
                {
                    foreach (DataGridViewRow dr in hierarchicalGrid.Rows)
                    {
                        string rowCode = dr.Cells["Code"].Value.ToString();
                        if (!rowCode.Equals(selectedHIE))
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
            if (Mode.Equals("Components"))
            {

                foreach (DataGridViewRow dr in hierarchicalGrid.Rows)
                {
                    string rowCode = dr.Cells["Code"].Value.ToString();
                    if (selectedHIE.Equals("****") && !rowCode.Equals(selectedHIE))
                    {
                        if (isSelect)
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }
                        else
                        {
                            dr.Cells["Select"].ReadOnly = false;
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                    else if (selectedHIE.Equals("None") && !rowCode.Equals(selectedHIE))
                    {
                        if (isSelect)
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }
                        else
                        {
                            dr.Cells["Select"].ReadOnly = false;
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }

            }
            else if (selectedHIE.IndexOf("**") > 0 || selectedHIE.Equals("**-**-**"))
            {
                string selectedHierarchy = selectedHIE.Replace("-**", string.Empty);
                foreach (DataGridViewRow dr in hierarchicalGrid.Rows)
                {
                    string rowCode = dr.Cells["Code"].Value.ToString();
                    if (selectedHIE.Equals("**-**-**") && !rowCode.Equals(selectedHIE))
                    {
                        if (isSelect)
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }
                        else
                        {
                            dr.Cells["Select"].ReadOnly = false;
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                    else if (rowCode.StartsWith(selectedHierarchy) && !rowCode.Equals(selectedHIE))
                    {
                        if (isSelect)
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }
                        else
                        {
                            dr.Cells["Select"].ReadOnly = false;
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
                hierarchicalGrid.Update();
                hierarchicalGrid.ResumeLayout();
            }
        }

        /// <summary>
        /// Handles the grid Cell Click event and keeps track of the changes made on the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView hierarchicalGrid = sender as DataGridView;

            if (hierarchicalGrid.CurrentCell.ColumnIndex != 0)
                return;
            //Hie_Sel_Limit = 0, Sel_Hie_Cnt = 0
            if (Mode.Equals("Service") && Hie_Sel_Limit > 0)
            {
                if (Sel_Hie_Cnt >= Hie_Sel_Limit && hierarchicalGrid.CurrentRow.Cells["Select"].Value.ToString() == true.ToString())
                {
                    MessageBox.Show("Maximum Selection Limit(" + Hie_Sel_Limit.ToString() + ") exceeds");
                    hierarchicalGrid.CurrentRow.Cells["Select"].Value = "false";
                    return;
                }
            }

            string selectedHIE = hierarchicalGrid.SelectedRows[0].Cells["Code"].Value.ToString();
            bool isSelect = false;
            if (hierarchicalGrid.SelectedRows[0].Cells["Select"].Value.ToString().Equals(Consts.YesNoVariants.True, StringComparison.CurrentCultureIgnoreCase))
            {
                isSelect = true;
            }                         // Commented By Yeswanth on 11/25/2014 Because of this an issue rised only in CAPOK Site and good in rest the of site

            if (Mode.Equals("Program"))
            {
                if (Prog_Multiple_sel != "Hie_multiple_sel")
                {
                    foreach (DataGridViewRow dr in hierarchicalGrid.Rows)
                    {
                        string rowCode = dr.Cells["Code"].Value.ToString();
                        if (!rowCode.Equals(selectedHIE))
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
            if (Mode.Equals("Components"))
            {

                foreach (DataGridViewRow dr in hierarchicalGrid.Rows)
                {
                    string rowCode = dr.Cells["Code"].Value.ToString();
                    if (selectedHIE.Equals("****") && !rowCode.Equals(selectedHIE))
                    {
                        if (isSelect)
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }
                        else
                        {
                            dr.Cells["Select"].ReadOnly = false;
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                    else if (selectedHIE.Equals("None") && !rowCode.Equals(selectedHIE))
                    {
                        if (isSelect)
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }
                        else
                        {
                            dr.Cells["Select"].ReadOnly = false;
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }

            }
            else if (selectedHIE.IndexOf("**") > 0 || selectedHIE.Equals("**-**-**"))
            {
                string selectedHierarchy = selectedHIE.Replace("-**", string.Empty);
                foreach (DataGridViewRow dr in hierarchicalGrid.Rows)
                {
                    string rowCode = dr.Cells["Code"].Value.ToString();
                    if (selectedHIE.Equals("**-**-**") && !rowCode.Equals(selectedHIE))
                    {
                        if (isSelect)
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }
                        else
                        {
                            dr.Cells["Select"].ReadOnly = false;
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                    else if (rowCode.StartsWith(selectedHierarchy) && !rowCode.Equals(selectedHIE))
                    {
                        if (isSelect)
                        {
                            dr.Cells["Select"].Value = "false";
                            dr.Cells["Select"].ReadOnly = true;
                            dr.DefaultCellStyle.ForeColor = Color.LightGray;
                        }
                        else
                        {
                            dr.Cells["Select"].ReadOnly = false;
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
                hierarchicalGrid.Update();
                hierarchicalGrid.ResumeLayout();
            }

            if (Mode.Equals("Service"))
            {
                if (hierarchicalGrid.CurrentRow.Cells["Select"].Value.ToString() == false.ToString())
                    Sel_Hie_Cnt--;
                else
                    Sel_Hie_Cnt++;

                if (Sel_Hie_Cnt <= 0)
                    Sel_Hie_Cnt = 0;
            }

        }

        /// <summary>
        /// Handles the grid DataError event to prevent error messages in the client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewDataError(object sender, Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs e)
        {
            //DO NOTHING HERE
        }

        /// <summary>
        /// Handles grid before click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewBeforeClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)sender;

        }

        /// <summary>
        /// Handles OK click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOkClick(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (Mode.Equals("Edit"))
                {
                    //savePasswordHIE();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {

                    if (PrivilegeEntity.Program == "ADMN0020")
                    {
                        if (BaseForm.BaseAgencyControlDetails.PaymentCategorieService == "Y")
                        {
                            bool boolok = false;
                            if (SelectedHierarchies.Count > 0)
                            {
                                List<ListItem> _listcat = new List<ListItem>();
                                string Agy = "**", Dept = "**", Prog = "**";
                                string strServiceCatcode = string.Empty;
                                if (SelectedHierarchies.FindAll(u => u.Agency == "" || u.Dept == "" || u.Prog == "").Count > 0)
                                {
                                    foreach (HierarchyEntity row in SelectedHierarchies)
                                    {
                                        Agy = Dept = Prog = "**";
                                        if (!string.IsNullOrEmpty(row.Agency.Trim()))
                                            Agy = row.Agency.Trim();

                                        if (!string.IsNullOrEmpty(row.Prog.Trim()))
                                            Prog = row.Prog.Trim();

                                        if (!string.IsNullOrEmpty(row.Dept.Trim()))
                                            Dept = row.Dept.Trim();

                                        if (Agy != "**" && Dept != "**" && Prog != "**")
                                        {
                                            ProgramDefinitionEntity programEntity = _model.HierarchyAndPrograms.GetCaseDepadp(Agy, Dept, Prog);
                                            if (programEntity != null)
                                            {
                                                _listcat.Add(new ListItem(programEntity.DepSerpostPAYCAT));
                                            }
                                        }
                                    }
                                    if (_listcat.FindAll(u => u.Text.Trim() == "").Count == _listcat.Count)
                                    {
                                        boolok = true;
                                    }
                                }
                                else
                                {
                                    foreach (HierarchyEntity row in SelectedHierarchies)
                                    {
                                        Agy = Dept = Prog = "**";
                                        if (!string.IsNullOrEmpty(row.Agency.Trim()))
                                            Agy = row.Agency.Trim();

                                        if (!string.IsNullOrEmpty(row.Prog.Trim()))
                                            Prog = row.Prog.Trim();

                                        if (!string.IsNullOrEmpty(row.Dept.Trim()))
                                            Dept = row.Dept.Trim();

                                        string strHie = Agy + Dept + Prog;

                                        ProgramDefinitionEntity programEntity = _model.HierarchyAndPrograms.GetCaseDepadp(Agy, Dept, Prog);
                                        if(programEntity!=null)
                                        {
                                            _listcat.Add(new ListItem(programEntity.DepSerpostPAYCAT));
                                        }
                                        
                                    }

                                    if(_listcat.FindAll(u=>u.Text == "01").Count == SelectedHierarchies.Count)
                                    {
                                        boolok = true;
                                    }
                                    if (_listcat.FindAll(u => u.Text == "02").Count == SelectedHierarchies.Count)
                                    {
                                        boolok = true;
                                    }
                                    if (_listcat.FindAll(u => u.Text.Trim() == "").Count == SelectedHierarchies.Count)
                                    {
                                        boolok = true;
                                    }
                                }
                                if(boolok)
                                {

                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    CommonFunctions.MessageBoxDisplay("All Selected Hierarchies are not in Same Category");
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Handles Cancel click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion




    }
}