using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Captain.Common.Model.Objects
{
    class CaseMstSnpEntity
    {

        #region Constructors

        public CaseMstSnpEntity()
        {
             ApplNo = string.Empty;
             Ssno = string.Empty;
             NameixLast = string.Empty;
             NameixFi = string.Empty;
             NameixMi = string.Empty;
             Area = string.Empty;
             Phone = string.Empty;
             AltBdate = string.Empty;
             ExpireWorkDate = string.Empty;
             Hn = string.Empty;
             Street = string.Empty;
             City = string.Empty;
             State = string.Empty;
             Alias = string.Empty;
             Agency = string.Empty;
             Dept = string.Empty;
             Program = string.Empty;
             Year = string.Empty;
             FamilySeq = string.Empty;                       
        
        }

        public CaseMstSnpEntity(DataRow row)
        {
            if (row != null)
            {
                ApplNo = row["MST_APP_NO"].ToString();
                Ssno = row["SNP_SSNO"].ToString();
                NameixLast = row["SNP_NAME_IX_LAST"].ToString();
                NameixFi = row["SNP_NAME_IX_FI"].ToString();
                NameixMi = row["SNP_NAME_IX_MI"].ToString();
                Area = row["MST_AREA"].ToString();
                Phone = row["MST_PHONE"].ToString();
                AltBdate = row["SNP_ALT_BDATE"].ToString();
                ExpireWorkDate = row["SNP_EXPIRE_WORK_DATE"].ToString();
                Hn = row["MST_HN"].ToString();
                Street = row["MST_STREET"].ToString();
                City = row["MST_CITY"].ToString();
                State = row["MST_STATE"].ToString();
                Alias = row["SNP_ALIAS"].ToString();
                Agency = row["SNP_AGENCY"].ToString();
                Dept = row["SNP_DEPT"].ToString();
                Program = row["SNP_PROGRAM"].ToString();
                Year = row["SNP_YEAR"].ToString();               
                FamilySeq = row["SNP_FAMILY_SEQ"].ToString();
            }
        }

        #endregion

        #region Properties

        public string ApplNo { get; set; }
        public string Ssno { get; set; }
        public string NameixLast { get; set; }
        public string NameixFi { get; set; }
        public string NameixMi { get; set; }
        public string Area { get; set; }
        public string Phone { get; set; }
        public string AltBdate { get; set; }
        public string ExpireWorkDate { get; set; }
        public string Hn { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Alias { get; set; }
        public string Agency { get; set; }
        public string Dept { get; set; }
        public string Program { get; set; }
        public string Year { get; set; }
        public string FamilySeq { get; set; }    

         #endregion
    }
}
