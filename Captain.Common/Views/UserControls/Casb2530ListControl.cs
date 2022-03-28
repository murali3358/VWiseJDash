#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Captain.Common.Utilities;
using Captain.Common.Model.Objects;
using Captain.Common.Model.Data;

#endregion

namespace Captain.Common.Views.UserControls
{
    public partial class Casb2530ListControl : UserControl
    {
        private CaptainModel _model = null;
        public Casb2530ListControl(DataTable dt, List<RNKCRIT2Entity> RnkQuesFledsDataCodeEntity, List<RNKCRIT2Entity> RnkCustFldsDataCodeEntity, CaseMstEntity caseMst, List<CaseSnpEntity> caseSnp, List<CustomQuestionsEntity> custResponses, List<AGYTABSEntity> agytabsentity, List<CommonEntity> commonAgyList, List<RNKCRIT2Entity> RnkQuesFledsEntity)
        {
            InitializeComponent();
            _model = new CaptainModel();
            propRnkQuesFldEntity = RnkQuesFledsDataCodeEntity;
            propRnkQuescustFldEntity = RnkCustFldsDataCodeEntity;
            propMstRank = caseMst;
            propCaseSnpEntity = caseSnp;
            propCustResponse = custResponses;
            propAgyTabsList = agytabsentity;
            propcommonAgyList = commonAgyList;
            propRnkQuesFledsEntity = RnkQuesFledsEntity;
            FillListView(dt);
        }

        //  public DataTable propDatatable { get; set; }
        public List<RNKCRIT2Entity> propRnkQuescustFldEntity { get; set; }
        public List<RNKCRIT2Entity> propRnkQuesFldEntity { get; set; }
        public CaseMstEntity propMstRank { get; set; }
        public List<CaseSnpEntity> propCaseSnpEntity { get; set; }
        public List<CustomQuestionsEntity> propCustResponse { get; set; }
        public List<AGYTABSEntity> propAgyTabsList { get; set; }
        public List<CommonEntity> propcommonAgyList { get; set; }
        public List<RNKCRIT2Entity> propRnkQuesFledsEntity { get; set; }
        private void FillListView(DataTable propDatatable)
        {
            string strResponce = string.Empty;
            foreach (DataRow item in propDatatable.Rows)
            {



                ListViewItem objItem = null;
                //if (item[3].ToString().StartsWith("SNP"))
                //{
                DataTable dttable = new DataTable();
                List<RNKCRIT2Entity> RnkQuesSearchList = propRnkQuesFldEntity.FindAll(u => u.RankFldName.Trim() == item[3].ToString());
                if (item[3].ToString().StartsWith("SNP"))
                {
                    FillRnkSubDetails(item["TableCode"].ToString());
                    dttable = CaseSnpDetailsCalc(RnkQuesSearchList, propCaseSnpEntity, ApplicantCode(item["TableCode"].ToString()), item["TableCode"].ToString(), item[4].ToString(), out strResponce);

                    RNKCRIT2Entity rnkCriti2Field = propRnkQuesFledsEntity.Find(u => u.RankFldName.Trim() == item[3].ToString());
                    GetSnpAgyTabDesc(rnkCriti2Field);


                    Casb2530GridControl objPanel = new Casb2530GridControl(propcommonEntity);
                    objPanel.Visible = false;
                    objPanel.Dock = DockStyle.Fill;
                    objItem = this.listViewRanks.Items.Add(objPanel, "");
                }
                else
                {
                    Casb2530GridControl objPanel = new Casb2530GridControl(dttable);
                    objPanel.Visible = false;
                    objPanel.Dock = DockStyle.Fill;
                    objItem = this.listViewRanks.Items.Add(objPanel, "");
                }

                //}
                objItem.SubItems.Add(item[0].ToString());

                objItem.SubItems.Add(item[2].ToString());

                if (item[3].ToString().StartsWith("SNP"))
                {
                    Gizmox.WebGUI.Forms.Label objButton = new Gizmox.WebGUI.Forms.Label();
                    objButton.Click += new EventHandler(OnEditButtonClick);
                    // objButton.Image = bookview;

                    objButton.Tag = objItem;
                    objButton.Text = "+";
                    objItem.SubItems.Add(objButton);
                }
                else
                {
                    Gizmox.WebGUI.Forms.Label objButton = new Gizmox.WebGUI.Forms.Label();
                    // objButton.Click += new EventHandler(OnEditButtonClick);
                    // objButton.Image = bookview;

                    objButton.Tag = objItem;
                    objButton.Text = item["FieldDesc"].ToString();

                    objItem.SubItems.Add(objButton);
                }
                objItem.SubItems.Add(item[1].ToString());

                //// objItem.SubItems.Add(GetIcon("Icons.16X16.AddItem.gif"));
                //if (Privileges.AddPriv.Equals("true"))
                //{

                //    Gizmox.WebGUI.Forms.Button objAddButton = new Gizmox.WebGUI.Forms.Button();
                //    objAddButton.Click += new EventHandler(OnAddButtonClick);
                //    objAddButton.Tag = objItem;
                //    objAddButton.Text = liheApd.LdLetterId;
                //    objAddButton.Image = "Icons.16X16.AddItem.gif";
                //    objItem.SubItems.Add(objAddButton);
                //}


            }
        }

        private void OnEditButtonClick(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.Label objButton = sender as Gizmox.WebGUI.Forms.Label;
            if (objButton != null)
            {
                ListViewPanelItem objPanelItem = objButton.Tag as ListViewPanelItem;
                if (objPanelItem != null)
                {
                    if (objPanelItem.Panel.Visible = !objPanelItem.Panel.Visible)
                    {
                        objButton.Text = "-";
                        // objButton.Image = bookClose;
                    }
                    else
                    {
                        objButton.Text = "+";
                        // objButton.Image = bookview;

                        Casb2530GridControl objPanel = objPanelItem.Panel as Casb2530GridControl;
                        if (objPanel != null)
                        {

                        }
                    }
                }
            }
        }

        #region RankCriteriaCalculation
        DataTable dtRankSubDetails = null;
        private DataTable CaseSnpDetailsCalc(List<RNKCRIT2Entity> rnkCaseSnp, List<CaseSnpEntity> caseSnpDetails, string strApplicantCode, string FilterCode, string ResponceType, out string strResponseDesc)
        {

            dtRankSubDetails = new DataTable();
            dtRankSubDetails.Columns.Add("FieldCode", typeof(string));
            dtRankSubDetails.Columns.Add("FieldDesc", typeof(string));
            dtRankSubDetails.Columns.Add("Points", typeof(string));

            int intSnpPoints = 0; int HealthPoints = 0;
            string strResponceCode = strApplicantCode;
            string strResponceData = strApplicantCode;
            List<CommonEntity> commonHighcount = new List<CommonEntity>();
            List<CommonEntity> commonLowcount = new List<CommonEntity>();
            commonHighcount.Clear();
            commonLowcount.Clear();
            foreach (RNKCRIT2Entity item in rnkCaseSnp)
            {
                List<RNKCRIT2Entity> RnkCrit2 = rnkCaseSnp.FindAll(u => u.RespCd.Equals(item.RespCd));
                HealthPoints = 0;
                if (item.CountInd.Trim() == "A")
                {

                    switch (ResponceType)
                    {
                        case "D":
                        case "L":
                            if (item.RespCd.Trim() == strApplicantCode)
                            {
                                foreach (CommonEntity commonitem in propcommonEntity)
                                {
                                    if (commonitem.Hierarchy == propMstRank.FamilySeq)
                                    {
                                        commonitem.Extension = item.Points;
                                        //  commonitem.Code = strApplicantCode;
                                        //commonitem.Desc = strApplicantCode;
                                        break;
                                    }
                                }


                            }
                            break;
                        case "N":
                            if (strApplicantCode != string.Empty)
                                if (Convert.ToDecimal(strApplicantCode) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(strApplicantCode) <= Convert.ToDecimal(item.LtNum))
                                {
                                    foreach (CommonEntity commonitem in propcommonEntity)
                                    {
                                        if (commonitem.Hierarchy == propMstRank.FamilySeq)
                                        {
                                            commonitem.Extension = item.Points;
                                            // commonitem.Code = strApplicantCode;
                                            // commonitem.Desc = strApplicantCode;
                                            break;
                                        }
                                    }

                                }
                            break;
                        case "G":
                            CaseSnpEntity casesnpAge = caseSnpDetails.Find(u => u.FamilySeq == propMstRank.FamilySeq);
                            if (casesnpAge != null)
                            {
                                if (casesnpAge.AltBdate != string.Empty && item.Relation.Trim() == casesnpAge.MemberCode)
                                {
                                    DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                    int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(casesnpAge.AltBdate), EndDate);

                                    if (AgeMonth > 12)
                                    {
                                        strResponceData = (AgeMonth / 12).ToString();
                                    }

                                    foreach (CommonEntity commonitem in propcommonEntity)
                                    {
                                        if (commonitem.Hierarchy == propMstRank.FamilySeq)
                                        {
                                            if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                            {
                                                commonitem.Extension = item.Points;
                                                //commonitem.Code = strResponceData;                                              
                                            }

                                            break;
                                        }
                                    }

                                }
                            }
                            break;
                        case "B":
                        case "T":
                            if (strApplicantCode != string.Empty)
                                if (Convert.ToDateTime(strApplicantCode).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(strApplicantCode).Date <= Convert.ToDateTime(item.LtDate).Date)
                                {
                                    foreach (CommonEntity commonitem in propcommonEntity)
                                    {
                                        if (commonitem.Hierarchy == propMstRank.FamilySeq)
                                        {
                                            commonitem.Extension = item.Points;
                                            //commonitem.Code = Convert.ToDateTime(strApplicantCode).Date.ToString();
                                            // commonitem.Desc = strApplicantCode;
                                            break;
                                        }
                                    }
                                }
                            break;
                    }

                }
                else if (item.CountInd.Trim() == "M")
                {
                    if (item.Relation == "*")
                    {
                        DataRow dr = dtRankSubDetails.NewRow();

                        dr["FieldCode"] = strApplicantCode;
                        dr["FieldDesc"] = "All";
                        dr["Points"] = "0";

                        int count = 0;
                        switch (FilterCode)
                        {
                            case Consts.RankQues.S1shift:
                                count = caseSnpDetails.FindAll(u => u.IstShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S2ndshift:
                                count = caseSnpDetails.FindAll(u => u.IIndShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S3rdShift:
                                count = caseSnpDetails.FindAll(u => u.IIIrdShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SAge:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                    {
                                        DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                        int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpDate.AltBdate), EndDate);
                                        if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                    }
                                }
                                break;
                            case Consts.RankQues.SAltBdate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }

                                break;
                            case Consts.RankQues.SSchoolDistrict:
                                count = caseSnpDetails.FindAll(u => u.SchoolDistrict.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEducation:
                                count = caseSnpDetails.FindAll(u => u.Education.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SWic:
                                count = caseSnpDetails.FindAll(u => u.Wic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDisable:
                                count = caseSnpDetails.FindAll(u => u.Disable.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDrvlic:
                                count = caseSnpDetails.FindAll(u => u.Drvlic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEmployed:
                                count = caseSnpDetails.FindAll(u => u.Employed.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEthinic:
                                count = caseSnpDetails.FindAll(u => u.Ethnic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SExpireWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.ExpireWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SFarmer:
                                count = caseSnpDetails.FindAll(u => u.Farmer.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SFoodStamps:
                                count = caseSnpDetails.FindAll(u => u.FootStamps.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.WorkStatus:
                                count = caseSnpDetails.FindAll(u => u.WorkStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.DisconectYouth:
                                count = caseSnpDetails.FindAll(u => u.Youth.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.MiltaryStatus:
                                count = caseSnpDetails.FindAll(u => u.MilitaryStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.HealthCodes:
                                foreach (CaseSnpEntity snpHealth in caseSnpDetails)
                                {
                                    if (!string.IsNullOrEmpty(snpHealth.Health_Codes.Trim()))
                                    {
                                        int intRankSnpPoints = fillAlertHealthCodes(snpHealth.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());
                                        HealthPoints = HealthPoints + intRankSnpPoints;
                                        //count = intRankSnpPoints + Convert.ToInt32(item.Points);
                                    }
                                    count = count + 1;
                                }
                                if (count == caseSnpDetails.Count)
                                { intSnpPoints = intSnpPoints + HealthPoints; count++; }
                                break;
                            case Consts.RankQues.SFThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.FullTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHealthIns:
                                count = caseSnpDetails.FindAll(u => u.HealthIns.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SHireDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.HireDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHourlyWage:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.HourlyWage != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SjobCategory:
                                count = caseSnpDetails.FindAll(u => u.JobCategory.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SjobTitle:
                                count = caseSnpDetails.FindAll(u => u.JobTitle.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SLastWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.LastWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SLegalTowork:
                                count = caseSnpDetails.FindAll(u => u.LegalTowork.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMartialStatus:
                                count = caseSnpDetails.FindAll(u => u.MaritalStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMemberCode:
                                count = caseSnpDetails.FindAll(u => u.MemberCode.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SNofcjob:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberOfcjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SNofljobs:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberofLvjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SPFrequency:
                                count = caseSnpDetails.FindAll(u => u.PayFrequency.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPregnant:
                                count = caseSnpDetails.FindAll(u => u.Pregnant.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.PartTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SRace:
                                count = caseSnpDetails.FindAll(u => u.Race.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRelitran:
                                count = caseSnpDetails.FindAll(u => u.Relitran.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SResident:
                                count = caseSnpDetails.FindAll(u => u.Resident.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRshift:
                                count = caseSnpDetails.FindAll(u => u.RShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSEmploy:
                                count = caseSnpDetails.FindAll(u => u.SeasonalEmploy.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSex:
                                count = caseSnpDetails.FindAll(u => u.Sex.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSnpVet:
                                count = caseSnpDetails.FindAll(u => u.Vet.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SStatus:
                                count = caseSnpDetails.FindAll(u => u.Status.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.STranserv:
                                count = caseSnpDetails.FindAll(u => u.Transerv.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SworkLimit:
                                count = caseSnpDetails.FindAll(u => u.WorkLimit.Trim().Equals(item.RespCd)).Count;
                                break;

                        }

                        if (caseSnpDetails.Count == count)
                        {
                            dr["Points"] = Convert.ToInt32(item.Points);
                            intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);

                            foreach (CommonEntity commonitem in propcommonEntity)
                            {
                                if (commonitem.Hierarchy == "999")
                                {
                                    commonitem.Extension = item.Points;
                                    // commonitem.Code = "";
                                    // commonitem.Desc = strApplicantCode;
                                    break;
                                }
                            }

                        }
                        dtRankSubDetails.Rows.Add(dr);
                    }
                    else
                    {
                        switch (ResponceType)
                        {
                            case "D":
                            case "L":
                                foreach (CaseSnpEntity snpdropdown in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.S1shift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IstShift.Trim())
                                            {

                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                            }
                                            break;
                                        case Consts.RankQues.S2ndshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIndShift.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.S3rdShift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIIrdShift.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSchoolDistrict:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SchoolDistrict.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEducation:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Education.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;//Convert.ToInt16(item.Points == string.Empty ? "0" : item.Points) + Convert.ToInt16(commonitem.Extension).ToString();
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SWic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Wic.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDisable:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Disable.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //  commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDrvlic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Drvlic.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEmployed:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Employed.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEthinic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Ethnic.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFarmer:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Farmer.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFoodStamps:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.FootStamps.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.WorkStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkStatus.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.DisconectYouth:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Youth.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.MiltaryStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MilitaryStatus.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.HealthCodes:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode)
                                            {
                                                // int intRankSnpPoints = fillAlertHealthCodes(snpdropdown.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim());
                                                // intSnpPoints = intSnpPoints + intRankSnpPoints;

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SHealthIns:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.HealthIns.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobCategory:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobCategory.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobTitle:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobTitle.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SLegalTowork:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.LegalTowork.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //  commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMartialStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MaritalStatus.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMemberCode:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MemberCode.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPFrequency:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.PayFrequency.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPregnant:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Pregnant.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //  commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRace:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Race.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //  commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRelitran:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Relitran.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SResident:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Resident.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.RShift.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //  commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSEmploy:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SeasonalEmploy.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSex:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Sex.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSnpVet:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Vet.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        //commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Status.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.STranserv:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Transerv.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SworkLimit:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkLimit.Trim())
                                            {
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpdropdown.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        // commonitem.Code = item.RespCd.Trim();
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                    }

                                }
                                //if (listRelationstring.Contains(item.Relation))
                                //{
                                //    if (listCodestring.Contains(item.RespCd))
                                //    {
                                //        intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                //    }
                                //}
                                break;
                            case "N":
                            case "G":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {


                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAge:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                            {
                                                DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                                int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpNumeric.AltBdate), EndDate);
                                                if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                                if (AgeMonth > 12)
                                                {
                                                    strResponceData = (AgeMonth / 12).ToString();
                                                }
                                                foreach (CommonEntity commonitem in propcommonEntity)
                                                {
                                                    if (commonitem.Hierarchy == snpNumeric.FamilySeq)
                                                    {
                                                        commonitem.Extension = item.Points;
                                                        commonitem.Code = strResponceData;
                                                        // commonitem.Desc = strApplicantCode;
                                                        break;
                                                    }
                                                }
                                            }
                                            break;

                                        case Consts.RankQues.SNofcjob:
                                            if (snpNumeric.NumberOfcjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    foreach (CommonEntity commonitem in propcommonEntity)
                                                    {
                                                        if (commonitem.Hierarchy == snpNumeric.FamilySeq)
                                                        {
                                                            commonitem.Extension = item.Points;
                                                            //  commonitem.Code = snpNumeric.NumberOfcjobs;
                                                            // commonitem.Desc = strApplicantCode;
                                                            break;
                                                        }
                                                    }
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SNofljobs:
                                            if (snpNumeric.NumberofLvjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    foreach (CommonEntity commonitem in propcommonEntity)
                                                    {
                                                        if (commonitem.Hierarchy == snpNumeric.FamilySeq)
                                                        {
                                                            commonitem.Extension = item.Points;
                                                            //  commonitem.Code = snpNumeric.NumberofLvjobs;
                                                            // commonitem.Desc = strApplicantCode;
                                                            break;
                                                        }
                                                    }
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SFThours:
                                            if (snpNumeric.FullTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    foreach (CommonEntity commonitem in propcommonEntity)
                                                    {
                                                        if (commonitem.Hierarchy == snpNumeric.FamilySeq)
                                                        {
                                                            commonitem.Extension = item.Points;
                                                            //   commonitem.Code = snpNumeric.FullTimeHours;
                                                            // commonitem.Desc = strApplicantCode;
                                                            break;
                                                        }
                                                    }
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SPThours:
                                            if (snpNumeric.PartTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    foreach (CommonEntity commonitem in propcommonEntity)
                                                    {
                                                        if (commonitem.Hierarchy == snpNumeric.FamilySeq)
                                                        {
                                                            commonitem.Extension = item.Points;
                                                            //   commonitem.Code = snpNumeric.PartTimeHours;
                                                            // commonitem.Desc = strApplicantCode;
                                                            break;
                                                        }
                                                    }
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SHourlyWage:
                                            if (snpNumeric.HourlyWage != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    foreach (CommonEntity commonitem in propcommonEntity)
                                                    {
                                                        if (commonitem.Hierarchy == snpNumeric.FamilySeq)
                                                        {
                                                            commonitem.Extension = item.Points;
                                                            // commonitem.Code = snpNumeric.HourlyWage;
                                                            // commonitem.Desc = strApplicantCode;
                                                            break;
                                                        }
                                                    }
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;

                                    }

                                }
                                break;
                            case "B":
                            case "T":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    DataRow dr = dtRankSubDetails.NewRow();

                                    dr["FieldCode"] = snpNumeric.MemberCode;
                                    dr["FieldDesc"] = "";
                                    dr["Points"] = "0";

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAltBdate:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    foreach (CommonEntity commonitem in propcommonEntity)
                                                    {
                                                        if (commonitem.Hierarchy == snpNumeric.FamilySeq)
                                                        {
                                                            commonitem.Extension = item.Points;
                                                            //  commonitem.Code = snpNumeric.AltBdate;
                                                            // commonitem.Desc = strApplicantCode;
                                                            break;
                                                        }
                                                    }
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SExpireWorkDate:
                                            if (snpNumeric.ExpireWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    foreach (CommonEntity commonitem in propcommonEntity)
                                                    {
                                                        if (commonitem.Hierarchy == snpNumeric.FamilySeq)
                                                        {
                                                            commonitem.Extension = item.Points;
                                                            //  commonitem.Code = snpNumeric.ExpireWorkDate;
                                                            // commonitem.Desc = strApplicantCode;
                                                            break;
                                                        }
                                                    }
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SLastWorkDate:
                                            if (snpNumeric.LastWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    foreach (CommonEntity commonitem in propcommonEntity)
                                                    {
                                                        if (commonitem.Hierarchy == snpNumeric.FamilySeq)
                                                        {
                                                            commonitem.Extension = item.Points;
                                                            // commonitem.Code = snpNumeric.LastWorkDate;
                                                            // commonitem.Desc = strApplicantCode;
                                                            break;
                                                        }
                                                    }
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SHireDate:
                                            if (snpNumeric.HireDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    foreach (CommonEntity commonitem in propcommonEntity)
                                                    {
                                                        if (commonitem.Hierarchy == snpNumeric.FamilySeq)
                                                        {
                                                            commonitem.Extension = item.Points;
                                                            //  commonitem.Code = snpNumeric.HireDate;
                                                            // commonitem.Desc = strApplicantCode;
                                                            break;
                                                        }
                                                    }
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;


                                    }
                                    dtRankSubDetails.Rows.Add(dr);
                                }
                                break;

                        }


                    }

                }
                else if (item.CountInd.Trim() == "H")
                {
                    if (item.Relation == "*")
                    {

                        int count = 0;
                        switch (FilterCode)
                        {
                            case Consts.RankQues.S1shift:
                                count = caseSnpDetails.FindAll(u => u.IstShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S2ndshift:
                                count = caseSnpDetails.FindAll(u => u.IIndShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S3rdShift:
                                count = caseSnpDetails.FindAll(u => u.IIIrdShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SAge:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                    {
                                        DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                        int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpDate.AltBdate), EndDate);
                                        if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                    }
                                }
                                break;
                            case Consts.RankQues.SAltBdate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }

                                break;
                            case Consts.RankQues.SSchoolDistrict:
                                count = caseSnpDetails.FindAll(u => u.SchoolDistrict.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEducation:
                                count = caseSnpDetails.FindAll(u => u.Education.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SWic:
                                count = caseSnpDetails.FindAll(u => u.Wic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDisable:
                                count = caseSnpDetails.FindAll(u => u.Disable.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDrvlic:
                                count = caseSnpDetails.FindAll(u => u.Drvlic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEmployed:
                                count = caseSnpDetails.FindAll(u => u.Employed.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEthinic:
                                count = caseSnpDetails.FindAll(u => u.Ethnic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SExpireWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.ExpireWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SFarmer:
                                count = caseSnpDetails.FindAll(u => u.Farmer.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SFoodStamps:
                                count = caseSnpDetails.FindAll(u => u.FootStamps.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.WorkStatus:
                                count = caseSnpDetails.FindAll(u => u.WorkStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.DisconectYouth:
                                count = caseSnpDetails.FindAll(u => u.Youth.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.MiltaryStatus:
                                count = caseSnpDetails.FindAll(u => u.MilitaryStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.HealthCodes:
                                foreach (CaseSnpEntity snpHealth in caseSnpDetails)
                                {
                                    if (!string.IsNullOrEmpty(snpHealth.Health_Codes.Trim()))
                                    {
                                        int intRankSnpPoints = fillAlertHealthCodes(snpHealth.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());
                                        HealthPoints = HealthPoints + intRankSnpPoints;
                                        //count = intRankSnpPoints + Convert.ToInt32(item.Points);
                                    }
                                    count = count + 1;
                                }
                                if (count == caseSnpDetails.Count)
                                { intSnpPoints = intSnpPoints + HealthPoints; count++; }
                                break;
                            case Consts.RankQues.SFThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.FullTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHealthIns:
                                count = caseSnpDetails.FindAll(u => u.HealthIns.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SHireDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.HireDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHourlyWage:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.HourlyWage != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SjobCategory:
                                count = caseSnpDetails.FindAll(u => u.JobCategory.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SjobTitle:
                                count = caseSnpDetails.FindAll(u => u.JobTitle.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SLastWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.LastWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SLegalTowork:
                                count = caseSnpDetails.FindAll(u => u.LegalTowork.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMartialStatus:
                                count = caseSnpDetails.FindAll(u => u.MaritalStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMemberCode:
                                count = caseSnpDetails.FindAll(u => u.MemberCode.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SNofcjob:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberOfcjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SNofljobs:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberofLvjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SPFrequency:
                                count = caseSnpDetails.FindAll(u => u.PayFrequency.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPregnant:
                                count = caseSnpDetails.FindAll(u => u.Pregnant.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.PartTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SRace:
                                count = caseSnpDetails.FindAll(u => u.Race.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRelitran:
                                count = caseSnpDetails.FindAll(u => u.Relitran.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SResident:
                                count = caseSnpDetails.FindAll(u => u.Resident.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRshift:
                                count = caseSnpDetails.FindAll(u => u.RShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSEmploy:
                                count = caseSnpDetails.FindAll(u => u.SeasonalEmploy.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSex:
                                count = caseSnpDetails.FindAll(u => u.Sex.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSnpVet:
                                count = caseSnpDetails.FindAll(u => u.Vet.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SStatus:
                                count = caseSnpDetails.FindAll(u => u.Status.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.STranserv:
                                count = caseSnpDetails.FindAll(u => u.Transerv.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SworkLimit:
                                count = caseSnpDetails.FindAll(u => u.WorkLimit.Trim().Equals(item.RespCd)).Count;
                                break;

                        }

                        if (caseSnpDetails.Count == count)
                        {
                            commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                        }

                    }
                    else
                    {
                        switch (ResponceType)
                        {
                            case "D":
                            case "L":
                                foreach (CaseSnpEntity snpdropdown in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.S1shift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IstShift.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                            }
                                            break;
                                        case Consts.RankQues.S2ndshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIndShift.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));

                                            }
                                            break;
                                        case Consts.RankQues.S3rdShift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIIrdShift.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSchoolDistrict:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SchoolDistrict.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEducation:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Education.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SWic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Wic.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDisable:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Disable.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDrvlic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Drvlic.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEmployed:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Employed.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEthinic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Ethnic.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFarmer:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Farmer.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFoodStamps:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.FootStamps.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.WorkStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkStatus.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.DisconectYouth:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Youth.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.MiltaryStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MilitaryStatus.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.HealthCodes:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode)
                                            {
                                                int intRankSnpPoints = fillAlertHealthCodes(snpdropdown.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());
                                                commonHighcount.Add(new CommonEntity(intRankSnpPoints.ToString(), item.RespText));

                                            }
                                            break;
                                        case Consts.RankQues.SHealthIns:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.HealthIns.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobCategory:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobCategory.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobTitle:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobTitle.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SLegalTowork:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.LegalTowork.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMartialStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MaritalStatus.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMemberCode:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MemberCode.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPFrequency:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.PayFrequency.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPregnant:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Pregnant.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRace:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Race.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRelitran:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Relitran.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SResident:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Resident.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.RShift.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSEmploy:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SeasonalEmploy.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSex:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Sex.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSnpVet:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Vet.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Status.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.STranserv:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Transerv.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SworkLimit:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkLimit.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                    }

                                }
                                //if (listRelationstring.Contains(item.Relation))
                                //{
                                //    if (listCodestring.Contains(item.RespCd))
                                //    {
                                //        intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                //    }
                                //}
                                break;
                            case "N":
                            case "G":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAge:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                            {
                                                DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                                int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpNumeric.AltBdate), EndDate);
                                                if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                                if (AgeMonth > 12)
                                                {
                                                    strResponceData = (AgeMonth / 12).ToString();
                                                }

                                            }
                                            break;

                                        case Consts.RankQues.SNofcjob:
                                            if (snpNumeric.NumberOfcjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SNofljobs:
                                            if (snpNumeric.NumberofLvjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SFThours:
                                            if (snpNumeric.FullTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SPThours:
                                            if (snpNumeric.PartTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SHourlyWage:
                                            if (snpNumeric.HourlyWage != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;

                                    }

                                }
                                break;
                            case "B":
                            case "T":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAltBdate:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SExpireWorkDate:
                                            if (snpNumeric.ExpireWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SLastWorkDate:
                                            if (snpNumeric.LastWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SHireDate:
                                            if (snpNumeric.HireDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;


                                    }

                                }
                                break;

                        }


                    }

                }
                //Lowest Points
                else if (item.CountInd.Trim() == "L")
                {
                    if (item.Relation == "*")
                    {

                        int count = 0;
                        switch (FilterCode)
                        {
                            case Consts.RankQues.S1shift:
                                count = caseSnpDetails.FindAll(u => u.IstShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S2ndshift:
                                count = caseSnpDetails.FindAll(u => u.IIndShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S3rdShift:
                                count = caseSnpDetails.FindAll(u => u.IIIrdShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SAge:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                    {
                                        DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                        int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpDate.AltBdate), EndDate);
                                        if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                    }
                                }
                                break;
                            case Consts.RankQues.SAltBdate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }

                                break;
                            case Consts.RankQues.SSchoolDistrict:
                                count = caseSnpDetails.FindAll(u => u.SchoolDistrict.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEducation:
                                count = caseSnpDetails.FindAll(u => u.Education.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SWic:
                                count = caseSnpDetails.FindAll(u => u.Wic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDisable:
                                count = caseSnpDetails.FindAll(u => u.Disable.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDrvlic:
                                count = caseSnpDetails.FindAll(u => u.Drvlic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEmployed:
                                count = caseSnpDetails.FindAll(u => u.Employed.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEthinic:
                                count = caseSnpDetails.FindAll(u => u.Ethnic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SExpireWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.ExpireWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SFarmer:
                                count = caseSnpDetails.FindAll(u => u.Farmer.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SFoodStamps:
                                count = caseSnpDetails.FindAll(u => u.FootStamps.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.WorkStatus:
                                count = caseSnpDetails.FindAll(u => u.WorkStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.DisconectYouth:
                                count = caseSnpDetails.FindAll(u => u.Youth.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.MiltaryStatus:
                                count = caseSnpDetails.FindAll(u => u.MilitaryStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.HealthCodes:
                                foreach (CaseSnpEntity snpHealth in caseSnpDetails)
                                {
                                    if (!string.IsNullOrEmpty(snpHealth.Health_Codes.Trim()))
                                    {
                                        int intRankSnpPoints = fillAlertHealthCodes(snpHealth.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());
                                        HealthPoints = HealthPoints + intRankSnpPoints;
                                    }
                                    count = count + 1;
                                }
                                if (caseSnpDetails.Count == count)
                                {
                                    commonLowcount.Add(new CommonEntity(HealthPoints.ToString(), item.RespText));
                                    count++;
                                }
                                break;
                            case Consts.RankQues.SFThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.FullTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHealthIns:
                                count = caseSnpDetails.FindAll(u => u.HealthIns.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SHireDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.HireDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHourlyWage:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.HourlyWage != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SjobCategory:
                                count = caseSnpDetails.FindAll(u => u.JobCategory.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SjobTitle:
                                count = caseSnpDetails.FindAll(u => u.JobTitle.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SLastWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.LastWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SLegalTowork:
                                count = caseSnpDetails.FindAll(u => u.LegalTowork.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMartialStatus:
                                count = caseSnpDetails.FindAll(u => u.MaritalStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMemberCode:
                                count = caseSnpDetails.FindAll(u => u.MemberCode.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SNofcjob:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberOfcjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SNofljobs:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberofLvjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SPFrequency:
                                count = caseSnpDetails.FindAll(u => u.PayFrequency.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPregnant:
                                count = caseSnpDetails.FindAll(u => u.Pregnant.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.PartTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SRace:
                                count = caseSnpDetails.FindAll(u => u.Race.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRelitran:
                                count = caseSnpDetails.FindAll(u => u.Relitran.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SResident:
                                count = caseSnpDetails.FindAll(u => u.Resident.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRshift:
                                count = caseSnpDetails.FindAll(u => u.RShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSEmploy:
                                count = caseSnpDetails.FindAll(u => u.SeasonalEmploy.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSex:
                                count = caseSnpDetails.FindAll(u => u.Sex.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSnpVet:
                                count = caseSnpDetails.FindAll(u => u.Vet.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SStatus:
                                count = caseSnpDetails.FindAll(u => u.Status.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.STranserv:
                                count = caseSnpDetails.FindAll(u => u.Transerv.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SworkLimit:
                                count = caseSnpDetails.FindAll(u => u.WorkLimit.Trim().Equals(item.RespCd)).Count;
                                break;

                        }

                        if (caseSnpDetails.Count == count)
                        {
                            commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                        }

                    }
                    else
                    {
                        switch (ResponceType)
                        {
                            case "D":
                            case "L":
                                foreach (CaseSnpEntity snpdropdown in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.S1shift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IstShift.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                            }
                                            break;
                                        case Consts.RankQues.S2ndshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIndShift.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));

                                            }
                                            break;
                                        case Consts.RankQues.S3rdShift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIIrdShift.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSchoolDistrict:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SchoolDistrict.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEducation:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Education.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SWic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Wic.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDisable:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Disable.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDrvlic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Drvlic.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEmployed:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Employed.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEthinic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Ethnic.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFarmer:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Farmer.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFoodStamps:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.FootStamps.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.WorkStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkStatus.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.DisconectYouth:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Youth.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.MiltaryStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MilitaryStatus.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.HealthCodes:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode)
                                            {
                                                int intRankSnpPoints = fillAlertHealthCodes(snpdropdown.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());
                                                commonLowcount.Add(new CommonEntity(intRankSnpPoints.ToString(), item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SHealthIns:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.HealthIns.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobCategory:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobCategory.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobTitle:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobTitle.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SLegalTowork:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.LegalTowork.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMartialStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MaritalStatus.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMemberCode:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MemberCode.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPFrequency:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.PayFrequency.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPregnant:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Pregnant.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRace:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Race.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRelitran:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Relitran.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SResident:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Resident.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.RShift.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSEmploy:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SeasonalEmploy.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSex:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Sex.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSnpVet:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Vet.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Status.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.STranserv:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Transerv.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SworkLimit:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkLimit.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                    }

                                }
                                //if (listRelationstring.Contains(item.Relation))
                                //{
                                //    if (listCodestring.Contains(item.RespCd))
                                //    {
                                //        intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                //    }
                                //}
                                break;
                            case "N":
                            case "G":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAge:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                            {
                                                DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                                int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpNumeric.AltBdate), EndDate);
                                                if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                                if (AgeMonth > 12)
                                                {
                                                    strResponceData = (AgeMonth / 12).ToString();
                                                }

                                            }
                                            break;

                                        case Consts.RankQues.SNofcjob:
                                            if (snpNumeric.NumberOfcjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SNofljobs:
                                            if (snpNumeric.NumberofLvjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SFThours:
                                            if (snpNumeric.FullTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SPThours:
                                            if (snpNumeric.PartTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SHourlyWage:
                                            if (snpNumeric.HourlyWage != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;

                                    }

                                }
                                break;
                            case "B":
                            case "T":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAltBdate:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SExpireWorkDate:
                                            if (snpNumeric.ExpireWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SLastWorkDate:
                                            if (snpNumeric.LastWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;
                                        case Consts.RankQues.SHireDate:
                                            if (snpNumeric.HireDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                }
                                            break;


                                    }

                                }
                                break;

                        }


                    }

                }

            }
            if (commonHighcount.Count > 0)
            {
                DataRow dr = dtRankSubDetails.NewRow();

                dr["FieldCode"] = strApplicantCode;
                dr["FieldDesc"] = "All Highest Points Only";
                dr["Points"] = "0";
                commonHighcount = commonHighcount.FindAll(u => u.Code.Trim() != string.Empty);
                commonHighcount = commonHighcount.OrderByDescending(u => Convert.ToInt16(u.Code)).ToList();
                if (commonHighcount.Count > 0)
                {
                    foreach (CommonEntity commonitem in propcommonEntity)
                    {
                        if (commonitem.Hierarchy == "888")
                        {
                            commonitem.Extension = commonHighcount[0].Code;
                            dr["Points"] = commonHighcount[0].Code;
                            // commonitem.Code = "";
                            commonitem.Code = commonHighcount[0].Desc;
                            break;
                        }
                    }
                    intSnpPoints = intSnpPoints + Convert.ToInt32(commonHighcount[0].Code);
                    strResponceData = commonHighcount[0].Desc;
                }
                dtRankSubDetails.Rows.Add(dr);
            }

            if (commonLowcount.Count > 0)
            {
                DataRow dr = dtRankSubDetails.NewRow();

                dr["FieldCode"] = strApplicantCode;
                dr["FieldDesc"] = "All Lowest Points Only";
                dr["Points"] = "0";
                commonLowcount = commonLowcount.FindAll(u => u.Code.Trim() != string.Empty);
                commonLowcount = commonLowcount.OrderBy(u => Convert.ToInt16(u.Code)).ToList();
                if (commonLowcount.Count > 0)
                {
                    foreach (CommonEntity commonitem in propcommonEntity)
                    {
                        if (commonitem.Hierarchy == "777")
                        {
                            commonitem.Extension = commonLowcount[0].Code;
                            dr["Points"] = commonLowcount[0].Code;
                            // commonitem.Code = "";
                            commonitem.Code = commonLowcount[0].Desc;
                            break;
                        }
                    }
                    intSnpPoints = intSnpPoints + Convert.ToInt32(commonLowcount[0].Code);
                    strResponceData = commonLowcount[0].Desc;
                }
                dtRankSubDetails.Rows.Add(dr);
            }

            strResponseDesc = strResponceData;
            return dtRankSubDetails;
        }


        public DateTime GetEndDateAgeCalculation(string Type, CaseMstEntity caseMst)
        {
            DateTime EndDate = DateTime.Now.Date;
            if (Type == "T")
            {
                EndDate = DateTime.Now.Date;
            }
            else if (Type == "I")
            {
                EndDate = Convert.ToDateTime(caseMst.IntakeDate);
            }
            else if (Type == "K")
            {
                string strDate = DateTime.Now.Date.ToShortDateString();
                string strYear;
                List<ZipCodeEntity> zipCodeEntity = _model.ZipCodeAndAgency.GetZipCodeSearch(caseMst.Zip, string.Empty, string.Empty, string.Empty);
                ZipCodeEntity zipentity = zipCodeEntity.Find(u => u.Zcrzip.Trim().Equals(caseMst.Zip.Trim()));
                if (zipentity != null)
                {
                    if (zipentity.Zcrhssyear.Trim() == "2")
                    {
                        strYear = DateTime.Now.AddYears(1).Year.ToString();
                    }
                    else
                    {
                        strYear = DateTime.Now.Year.ToString();
                    }
                    strDate = zipentity.Zcrhssmo + "/" + zipentity.Zcrhssday + "/" + strYear;
                }
                EndDate = Convert.ToDateTime(strDate);
            }
            return EndDate;
        }


        public void GetSnpAgyTabDesc(RNKCRIT2Entity rnkQuesData)
        {
            foreach (CommonEntity item in propcommonEntity)
            {
                string strDesc = string.Empty;
                if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                {
                    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == item.Code);
                    if (agytab != null)
                        strDesc = agytab.Code_Desc.ToString();
                    else
                        strDesc = item.Code;
                }
                else
                    strDesc = item.Code;

                item.Code = strDesc;
            }

        }
        List<CommonEntity> propcommonEntity = new List<CommonEntity>();
        private void FillRnkSubDetails(string strCode)
        {
            string strFieldCode = string.Empty;
            List<CommonEntity> Relation = CommonFunctions.AgyTabsFilterCode(propcommonAgyList, Consts.AgyTab.RELATIONSHIP, propMstRank.ApplAgency, propMstRank.ApplDept, propMstRank.ApplProgram, string.Empty);
            propcommonEntity.Clear();
            CaseSnpEntity casesnpapplicant = propCaseSnpEntity.Find(u => u.FamilySeq.Trim() == propMstRank.FamilySeq.Trim());
            propcommonEntity.Add(new CommonEntity(SnpDescCode(strCode, casesnpapplicant), "All Members", "999", "0"));
            propcommonEntity.Add(new CommonEntity(SnpDescCode(strCode, casesnpapplicant), "Highest Points Only", "888", "0"));
            propcommonEntity.Add(new CommonEntity(SnpDescCode(strCode, casesnpapplicant), "Lowest Points Only", "777", "0"));
            foreach (CaseSnpEntity item in propCaseSnpEntity)
            {
                string strDesc = item.MemberCode;
                if (Relation.Count > 0)
                {
                    CommonEntity commerdesc = Relation.Find(u => u.Code == item.MemberCode);
                    if (commerdesc != null)
                    {
                        strDesc = commerdesc.Desc;
                    }
                }


                propcommonEntity.Add(new CommonEntity(SnpDescCode(strCode, item), strDesc, item.FamilySeq, "0")); ;
            }
        }


        private string SnpDescCode(string strCode, CaseSnpEntity item)
        {
            string strFieldCode = string.Empty;
            switch (strCode)
            {


                case Consts.RankQues.S1shift:
                    strFieldCode = item.IstShift.Trim();
                    //   count = caseSnpDetails.FindAll(u => u.IstShift.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.S2ndshift:
                    strFieldCode = item.IIndShift.Trim();
                    // count = caseSnpDetails.FindAll(u => u.IIndShift.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.S3rdShift:
                    strFieldCode = item.IIIrdShift.Trim();
                    // count = caseSnpDetails.FindAll(u => u.IIIrdShift.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SAge:
                    strFieldCode = item.Age.Trim();
                    //foreach (CaseSnpEntity snpDate in caseSnpDetails)
                    //{
                    //    if (snpDate.AltBdate != string.Empty)
                    //    {
                    //        DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                    //        int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpDate.AltBdate), EndDate);
                    //        if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                    //        {
                    //            count = count + 1;
                    //        }
                    //    }
                    //}
                    break;
                case Consts.RankQues.SAltBdate:
                    strFieldCode = LookupDataAccess.Getdate(item.AltBdate.Trim());
                    //foreach (CaseSnpEntity snpDate in caseSnpDetails)
                    //{
                    //    if (snpDate.AltBdate != string.Empty)
                    //        if (Convert.ToDateTime(snpDate.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                    //        {
                    //            count = count + 1;
                    //        }
                    //}

                    break;
                case Consts.RankQues.SSchoolDistrict:
                    strFieldCode = item.SchoolDistrict.Trim();
                    //count = caseSnpDetails.FindAll(u => u.SchoolDistrict.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SEducation:
                    strFieldCode = item.Education.Trim();
                    // count = caseSnpDetails.FindAll(u => u.Education.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SWic:
                    strFieldCode = item.Wic.Trim();
                    // count = caseSnpDetails.FindAll(u => u.Wic.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SDisable:
                    strFieldCode = item.Disable.Trim();
                    // count = caseSnpDetails.FindAll(u => u.Disable.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SDrvlic:
                    strFieldCode = item.Drvlic.Trim();
                    //  count = caseSnpDetails.FindAll(u => u.Drvlic.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SEmployed:
                    strFieldCode = item.Employed.Trim();
                    // count = caseSnpDetails.FindAll(u => u.Employed.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SEthinic:
                    strFieldCode = item.Ethnic.Trim();
                    //   count = caseSnpDetails.FindAll(u => u.Ethnic.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SExpireWorkDate:
                    strFieldCode = LookupDataAccess.Getdate(item.ExpireWorkDate.Trim());
                    //foreach (CaseSnpEntity snpDate in caseSnpDetails)
                    //{
                    //    if (snpDate.ExpireWorkDate != string.Empty)
                    //        if (Convert.ToDateTime(snpDate.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                    //        {
                    //            count = count + 1;
                    //        }
                    //}
                    break;
                case Consts.RankQues.SFarmer:
                    strFieldCode = item.Farmer.Trim();
                    //count = caseSnpDetails.FindAll(u => u.Farmer.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SFoodStamps:
                    strFieldCode = item.FootStamps.Trim();
                    // count = caseSnpDetails.FindAll(u => u.FootStamps.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.WorkStatus:
                    strFieldCode = item.WorkStatus.Trim();
                    break;
                case Consts.RankQues.DisconectYouth:
                    strFieldCode = item.Youth.Trim();
                    break;
                case Consts.RankQues.MiltaryStatus:
                    strFieldCode = item.MilitaryStatus.Trim();
                    break;
                case Consts.RankQues.HealthCodes:
                    strFieldCode = item.Health_Codes.Trim();
                    break;
                case Consts.RankQues.SFThours:
                    strFieldCode = item.FullTimeHours.Trim();
                    //foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                    //{
                    //    if (snpNumeric.FullTimeHours != string.Empty)
                    //        if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                    //        {
                    //            count = count + 1;
                    //        }
                    //}
                    break;
                case Consts.RankQues.SHealthIns:
                    strFieldCode = item.HealthIns.Trim();
                    // count = caseSnpDetails.FindAll(u => u.HealthIns.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SHireDate:
                    strFieldCode = LookupDataAccess.Getdate(item.HireDate.Trim());
                    //foreach (CaseSnpEntity snpDate in caseSnpDetails)
                    //{
                    //    if (snpDate.HireDate != string.Empty)
                    //        if (Convert.ToDateTime(snpDate.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                    //        {
                    //            count = count + 1;
                    //        }
                    //}
                    break;
                case Consts.RankQues.SHourlyWage:
                    strFieldCode = item.HourlyWage.Trim();
                    //foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                    //{
                    //    if (snpNumeric.HourlyWage != string.Empty)
                    //        if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                    //        {
                    //            count = count + 1;
                    //        }
                    //}
                    break;
                case Consts.RankQues.SjobCategory:
                    strFieldCode = item.JobCategory.Trim();
                    // count = caseSnpDetails.FindAll(u => u.JobCategory.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SjobTitle:
                    strFieldCode = item.JobTitle.Trim();
                    // count = caseSnpDetails.FindAll(u => u.JobTitle.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SLastWorkDate:
                    strFieldCode = LookupDataAccess.Getdate(item.LastWorkDate.Trim());
                    //foreach (CaseSnpEntity snpDate in caseSnpDetails)
                    //{
                    //    if (snpDate.LastWorkDate != string.Empty)
                    //        if (Convert.ToDateTime(snpDate.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                    //        {
                    //            count = count + 1;
                    //        }
                    //}
                    break;
                case Consts.RankQues.SLegalTowork:
                    strFieldCode = item.LegalTowork.Trim();
                    //count = caseSnpDetails.FindAll(u => u.LegalTowork.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SMartialStatus:
                    strFieldCode = item.MaritalStatus.Trim();
                    // count = caseSnpDetails.FindAll(u => u.MaritalStatus.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SMemberCode:
                    strFieldCode = item.MemberCode.Trim();
                    //  count = caseSnpDetails.FindAll(u => u.MemberCode.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SNofcjob:
                    strFieldCode = item.NumberOfcjobs.Trim();
                    //foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                    //{
                    //    if (snpNumeric.NumberOfcjobs != string.Empty)
                    //        if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                    //        {
                    //            count = count + 1;
                    //        }
                    //}
                    break;
                case Consts.RankQues.SNofljobs:
                    strFieldCode = item.NumberofLvjobs.Trim();
                    //foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                    //{
                    //    if (snpNumeric.NumberofLvjobs != string.Empty)
                    //        if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                    //        {
                    //            count = count + 1;
                    //        }
                    //}
                    break;
                case Consts.RankQues.SPFrequency:
                    strFieldCode = item.PayFrequency.Trim();
                    //  count = caseSnpDetails.FindAll(u => u.PayFrequency.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SPregnant:
                    strFieldCode = item.Pregnant.Trim();
                    //  count = caseSnpDetails.FindAll(u => u.Pregnant.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SPThours:
                    strFieldCode = item.PartTimeHours.Trim();
                    //foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                    //{
                    //    if (snpNumeric.PartTimeHours != string.Empty)
                    //        if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                    //        {
                    //            count = count + 1;
                    //        }
                    //}
                    break;
                case Consts.RankQues.SRace:
                    strFieldCode = item.Race.Trim();
                    //  count = caseSnpDetails.FindAll(u => u.Race.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SRelitran:
                    strFieldCode = item.Relitran.Trim();
                    //   count = caseSnpDetails.FindAll(u => u.Relitran.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SResident:
                    strFieldCode = item.Resident.Trim();
                    //  count = caseSnpDetails.FindAll(u => u.Resident.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SRshift:
                    strFieldCode = item.RShift.Trim();
                    // count = caseSnpDetails.FindAll(u => u.RShift.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SSEmploy:
                    strFieldCode = item.SeasonalEmploy.Trim();
                    // count = caseSnpDetails.FindAll(u => u.SeasonalEmploy.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SSex:
                    strFieldCode = item.Sex.Trim();
                    // count = caseSnpDetails.FindAll(u => u.Sex.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SSnpVet:
                    strFieldCode = item.Vet.Trim();
                    //count = caseSnpDetails.FindAll(u => u.Vet.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SStatus:
                    strFieldCode = item.Status.Trim();
                    //count = caseSnpDetails.FindAll(u => u.Status.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.STranserv:
                    strFieldCode = item.Transerv.Trim();
                    // count = caseSnpDetails.FindAll(u => u.Transerv.Trim().Equals(item.RespCd)).Count;
                    break;
                case Consts.RankQues.SworkLimit:
                    strFieldCode = item.WorkLimit.Trim();
                    // count = caseSnpDetails.FindAll(u => u.WorkLimit.Trim().Equals(item.RespCd)).Count;
                    break;

            }

            return strFieldCode;

        }

        private int fillAlertNonCashBenCodes(string alertCodes, List<RNKCRIT2Entity> rnkSearchEntity, string FieldName)
        {
            int intAlertcode = 0;
            List<string> AlertList = new List<string>();
            if (alertCodes != null)
            {
                string[] NonCashBen = alertCodes.Split(',');
                for (int i = 0; i < NonCashBen.Length; i++)
                {
                    AlertList.Add(NonCashBen.GetValue(i).ToString());
                }
            }
            List<RNKCRIT2Entity> RnkAlertCode = rnkSearchEntity.FindAll(u => u.RankFldName.Trim() == FieldName);

            foreach (RNKCRIT2Entity rnkEntity in RnkAlertCode)
            {
                if (alertCodes != null && AlertList.Contains(rnkEntity.RespCd))
                {
                    intAlertcode = intAlertcode + Convert.ToInt32(rnkEntity.Points);
                }
            }
            return intAlertcode;
        }

        private int fillAlertHealthCodes(string alertCodes, List<RNKCRIT2Entity> rnkSearchEntity, string FieldName, string CountInd)
        {
            int intAlertcode = 0;
            List<string> AlertList = new List<string>();
            if (alertCodes != null)
            {
                string[] HealthCodes = alertCodes.Split(',');
                for (int i = 0; i < HealthCodes.Length; i++)
                {
                    AlertList.Add(HealthCodes.GetValue(i).ToString());
                }
            }
            List<RNKCRIT2Entity> RnkAlertCode = rnkSearchEntity.FindAll(u => u.RankFldName.Trim() == FieldName && u.CountInd.Trim() == CountInd);

            foreach (RNKCRIT2Entity rnkEntity in RnkAlertCode)
            {
                if (alertCodes != null && AlertList.Contains(rnkEntity.RespCd))
                {
                    intAlertcode = intAlertcode + Convert.ToInt32(rnkEntity.Points);
                }
            }
            return intAlertcode;
        }


        private string ApplicantCode(string strCode)
        {
            string strApplicationcode = string.Empty;
            switch (strCode)
            {

                case Consts.RankQues.MZip:
                    strApplicationcode = propMstRank.Zip.Trim();                   
                    break;
                case Consts.RankQues.MCounty:
                     strApplicationcode = propMstRank.County.Trim();
                       break;
                case Consts.RankQues.MLanguage:
                    strApplicationcode = propMstRank.Language.Trim();
                      break;
                case Consts.RankQues.MAlertCode:
                    strApplicationcode = propMstRank.AlertCodes.Trim();                    
                    break;
                case Consts.RankQues.MAboutUs:
                    strApplicationcode = propMstRank.AboutUs.Trim();
                      break;
                case Consts.RankQues.MAddressYear:
                    strApplicationcode = propMstRank.AddressYears.Trim();
                    break;
                case Consts.RankQues.MBestContact:
                    strApplicationcode = propMstRank.BestContact.Trim();
                       break;
                case Consts.RankQues.MCaseReviewDate:
                    strApplicationcode = propMstRank.CaseReviewDate.Trim();
                    break;
                case Consts.RankQues.MCaseType:
                    strApplicationcode = propMstRank.CaseType.Trim();
                    break;
                case Consts.RankQues.MCmi:
                   strApplicationcode = propMstRank.Cmi;
                    break;
                case Consts.RankQues.MEElectric:
                   strApplicationcode = propMstRank.ExpElectric;
                    break;
                case Consts.RankQues.MEDEBTCC:
                   strApplicationcode = propMstRank.Debtcc;
                    break;
                case Consts.RankQues.MEDEBTLoans:
                    strApplicationcode = propMstRank.DebtLoans;
                    break;
                case Consts.RankQues.MEDEBTMed:
                    strApplicationcode = propMstRank.DebtMed;
                    break;
                case Consts.RankQues.MEHeat:
                    strApplicationcode = propMstRank.ExpHeat;
                    break;
                case Consts.RankQues.MEligDate:
                   strApplicationcode = propMstRank.EligDate;
                    break;
                case Consts.RankQues.MELiveExpenses:
                    strApplicationcode = propMstRank.ExpLivexpense;
                    break;
                case Consts.RankQues.MERent:
                   strApplicationcode = propMstRank.ExpRent;
                    break;
                case Consts.RankQues.METotal:
                    strApplicationcode = propMstRank.ExpTotal;
                    break;
                case Consts.RankQues.MEWater:
                    strApplicationcode = propMstRank.ExpWater;
                    break;

                case Consts.RankQues.MExpCaseworker:
                    strApplicationcode = propMstRank.ExpCaseWorker.Trim();
                   
                    break;
                case Consts.RankQues.MFamilyType:
                    strApplicationcode = propMstRank.FamilyType.Trim();
                    break;
                case Consts.RankQues.MFamIncome:
                   
                        strApplicationcode = propMstRank.FamIncome.Trim();
                    
                    break;
                case Consts.RankQues.MHousing:
                    strApplicationcode = propMstRank.Housing.Trim();
                    break;

                case Consts.RankQues.MIncomeTypes:
                    strApplicationcode = propMstRank.IncomeTypes.Trim();
                    break;
                case Consts.RankQues.NonCashBenefits:
                   strApplicationcode = propMstRank.MstNCashBen.Trim();
                    break;
                case Consts.RankQues.MInitialDate:
                     strApplicationcode = propMstRank.InitialDate;
                    break;
                case Consts.RankQues.MIntakeDate:
                     strApplicationcode = propMstRank.IntakeDate;
                    break;
                case Consts.RankQues.MIntakeWorker:
                    strApplicationcode = propMstRank.IntakeWorker.Trim();
                    break;
                case Consts.RankQues.MJuvenile:
                     strApplicationcode = propMstRank.Juvenile.Trim();
                  break;
                case Consts.RankQues.MLanguageOt:
                     strApplicationcode = propMstRank.LanguageOt.Trim();
                    break;
                case Consts.RankQues.MNoInprog:
                    strApplicationcode = propMstRank.NoInProg;                   
                    break;
                case Consts.RankQues.Mpoverty:
                    strApplicationcode = propMstRank.Poverty;
                    break;
                case Consts.RankQues.MProgIncome:
                     strApplicationcode = propMstRank.ProgIncome;
                    break;
                case Consts.RankQues.MReverifyDate:
                     strApplicationcode = propMstRank.ReverifyDate;
                    break;
                case Consts.RankQues.MSECRET:
                     strApplicationcode = propMstRank.Secret.Trim();
                     break;
                case Consts.RankQues.MSenior:
                     strApplicationcode = propMstRank.Senior.Trim();
                    break;
                case Consts.RankQues.MSite:
                    strApplicationcode = propMstRank.Site.Trim();
                    break;
                case Consts.RankQues.MSMi:
                   strApplicationcode = propMstRank.Smi;                    
                    break;
                case Consts.RankQues.MVefiryCheckstub:
                   strApplicationcode = propMstRank.VerifyCheckStub.Trim();
                    break;
                case Consts.RankQues.MVerifier:
                   strApplicationcode = propMstRank.Verifier.Trim();
                    break;
                case Consts.RankQues.MVerifyW2:
                    strApplicationcode = propMstRank.VerifyW2.Trim();
                    break;
                case Consts.RankQues.MVeriTaxReturn:
                  strApplicationcode = propMstRank.VerifyTaxReturn.Trim();
                   break;
                case Consts.RankQues.MVerLetter:
                   strApplicationcode = propMstRank.VerifyLetter.Trim();
                   break;
                case Consts.RankQues.MVerOther:
                  strApplicationcode = propMstRank.VerifyOther.Trim();
                   break;
                case Consts.RankQues.MWaitList:
                   strApplicationcode = propMstRank.WaitList.Trim();
                    break;
                case Consts.RankQues.SEducation:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Education.ToString();
                    break;
                case Consts.RankQues.S1shift:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).IstShift.ToString();
                    break;
                case Consts.RankQues.S2ndshift:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).IIndShift.ToString();
                    break;
                case Consts.RankQues.S3rdShift:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).IIIrdShift.ToString();
                    break;
                case Consts.RankQues.SAge:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Age.ToString();
                    break;
                case Consts.RankQues.SAltBdate:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).AltBdate.ToString();
                    break;
                case Consts.RankQues.SDisable:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Disable.ToString();
                    break;
                case Consts.RankQues.SDrvlic:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Drvlic.ToString();
                    break;
                case Consts.RankQues.SEmployed:

                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Employed.ToString();
                    break;
                case Consts.RankQues.SEthinic:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Ethnic.ToString();
                    break;
                case Consts.RankQues.SExpireWorkDate:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).ExpireWorkDate.ToString();
                    break;
                case Consts.RankQues.SFarmer:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Farmer.ToString();
                    break;
                case Consts.RankQues.SFoodStamps:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).FootStamps.ToString();
                    break;
                case Consts.RankQues.SFThours:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).FullTimeHours.ToString();
                    break;
                case Consts.RankQues.SHealthIns:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).HealthIns.ToString();
                    break;
                case Consts.RankQues.SHireDate:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).HireDate.ToString();
                    break;
                case Consts.RankQues.SHourlyWage:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).HourlyWage.ToString();
                    break;
                case Consts.RankQues.SjobCategory:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).JobCategory.ToString();
                    break;
                case Consts.RankQues.SjobTitle:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).JobTitle.ToString();
                    break;
                case Consts.RankQues.SLastWorkDate:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).LastWorkDate.ToString();
                    break;
                case Consts.RankQues.SLegalTowork:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).LegalTowork.ToString();
                    break;
                case Consts.RankQues.SMartialStatus:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).MaritalStatus.ToString();
                    break;
                case Consts.RankQues.SMemberCode:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).MemberCode.ToString();
                    break;
                case Consts.RankQues.SNofcjob:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).NumberOfcjobs.ToString();
                    break;
                case Consts.RankQues.SNofljobs:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).NumberofLvjobs.ToString();
                    break;
                case Consts.RankQues.SPFrequency:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).PayFrequency.ToString();
                    break;
                case Consts.RankQues.SPregnant:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Pregnant.ToString();
                    break;
                case Consts.RankQues.SPThours:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).PartTimeHours.ToString();
                    break;
                case Consts.RankQues.SRace:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Race.ToString();
                    break;
                case Consts.RankQues.SRelitran:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Relitran.ToString();
                    break;
                case Consts.RankQues.SResident:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Resident.ToString();
                    break;
                case Consts.RankQues.SRshift:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).RShift.ToString();
                    break;
                case Consts.RankQues.SSchoolDistrict:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).SchoolDistrict.ToString();
                    break;
                case Consts.RankQues.SSEmploy:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Employed.ToString();
                    break;
                case Consts.RankQues.SSex:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Sex.ToString();
                    break;
                case Consts.RankQues.SSnpVet:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Vet.ToString();
                    break;
                case Consts.RankQues.SStatus:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Status.ToString();
                    break;
                case Consts.RankQues.STranserv:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Transerv.ToString();
                    break;
                case Consts.RankQues.SWic:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Wic.ToString();
                    break;
                case Consts.RankQues.SworkLimit:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).WorkLimit.ToString();
                    break;
                case Consts.RankQues.WorkStatus:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).WorkStatus.ToString();
                    break;
                case Consts.RankQues.DisconectYouth:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Youth.ToString();
                    break;
                case Consts.RankQues.MiltaryStatus:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).MilitaryStatus.ToString();
                    break;
                case Consts.RankQues.HealthCodes:
                    strApplicationcode = propCaseSnpEntity.Find(u => u.FamilySeq.Equals(propMstRank.FamilySeq)).Health_Codes.ToString();
                    break;

            }
            return strApplicationcode;
        }

        #endregion
    }
}