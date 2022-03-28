/**********************************************************************************************************
 * Class Name   : TreeViewController
 * Author       : Chittibabu Bellamkonda
 * Created Date : 
 * Version      : 
 * Description  : Used to manipulate the treeview for all modules.
 **********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;
using Captain.Common.Utilities;
using Captain.Common.Views.Forms.Base;
using Gizmox.WebGUI.Common.Resources;
using System.Web;
using Captain.Common.Interfaces;
using Captain.Common.Model.Parameters;
using Captain.Common.Model.Data;
using Captain.Common.Model.Objects;

namespace Captain.Common.Controllers
{
    public class TreeViewController
    {
        #region Variables

        private TagClass _lastDraggedTagClass = null;
        private TagClass _lastDroppedOntoTagClass = null;
        private TreeNode _clipboardSourceNode = null;
        private TreeNode _clipboardTargetNode = null;

        #endregion

        #region Constructor

        public TreeViewController(IBaseForm baseForm)
        {
            BaseForm = baseForm;
            // Model = baseForm.Model;

        }

        #endregion

        #region Properties

        public IBaseForm BaseForm { get; set; }

        public TreeView TreeView { get; set; }

        public string CurrentView { get; set; }

        public string BusinessModuleID { get; set; }

        public string HIE { get; set; }

        public TagClass ExpectedRootNode { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the tree.
        /// </summary>
        /// <param name="treeViewParameter"></param>
        /// <returns></returns>
        public bool Initialize(TreeViewControllerParameter treeViewParameter)
        {
            bool results = false;
            TreeView = treeViewParameter.TreeView;
            TreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            BusinessModuleID = treeViewParameter.BusinessModuleID;
            HIE = treeViewParameter.Hierarchy;

            switch (treeViewParameter.TreeType)
            {
                case TreeType.Administration:
                    PopulateAdministrationTree(Consts.Applications.Code.Administration);
                    break;
                case TreeType.HeadStart:
                    PopulateTreeMenu(Consts.Applications.Code.HeadStart);
                    break;
                case TreeType.CaseManagement:
                    PopulateTreeMenu(Consts.Applications.Code.CaseManagement);
                    break;
                case TreeType.EnergyRI:
                    PopulateTreeMenu(Consts.Applications.Code.EnergyRI);
                    break;
                case TreeType.EnergyCT:
                    PopulateTreeMenu(Consts.Applications.Code.EnergyCT);
                    break;
                case TreeType.AccountsReceivable:
                    PopulateTreeMenu(Consts.Applications.Code.AccountsReceivable);
                    break;
                case TreeType.HousingWeatherization:
                    PopulateTreeMenu(Consts.Applications.Code.HousingWeatherization);
                    break;
                case TreeType.EmergencyAssistance:
                    PopulateTreeMenu(Consts.Applications.Code.EmergencyAssistance);
                    break;
                case TreeType.DashBoard:
                    PopulateTreeMenu(Consts.Applications.Code.DashBoard);
                    break;
                case TreeType.HealthyStart:
                    PopulateTreeMenu(Consts.Applications.Code.HealthyStart);
                    break;
                case TreeType.AgencyPartner:
                    PopulateTreeMenu(Consts.Applications.Code.AgencyPartner);
                    break;
            }



            return results;
        }

        /// <summary>
        /// Used to get and populate the Screens & Reports.
        /// </summary>
        /// <param name="parentTreeNode"></param>
        /// <param name="parentTagClass"></param>
        /// <param name="hasCheckBox"></param>
        /// <param name="isChecked"></param>
        /// <param name="useCachedValues"></param>
        /// <param name="countryFilterList"></param>
        /// <returns></returns>
        public bool PopulateAdministrationTree(string code)
        {
            string view = string.Empty;
            TreeNode parentNode ;
            //parentNode.Image = new IconResourceHandle(Consts.Icons16x16.AddItem);
            CaptainModel model = new CaptainModel();
            List<PrivilegeEntity> userPrivilege = model.UserProfileAccess.GetScreensByUserID(code, BaseForm.UserID, string.Empty);

            List<MenuBranchEntity> menubranhlist = model.UserProfileAccess.GetMenuBranches();
            if (menubranhlist.Count > 0)
            {
                foreach (MenuBranchEntity menuitem in menubranhlist)
                {

                    parentNode = new TreeNode(menuitem.MemberDesc.Trim());
                    parentNode.Image = new IconResourceHandle(Consts.Icons16x16.AddItem);
                    parentNode.IsExpanded = true;
                    if (code == "01" && BaseForm.UserID.ToUpper() == "JAKE")
                    {
                        PrivilegeEntity privilegeAdmn12 = new PrivilegeEntity();
                        privilegeAdmn12.UserID = BaseForm.UserID;
                        privilegeAdmn12.ModuleCode = "01";
                        privilegeAdmn12.Program = "ADMN0012";
                        privilegeAdmn12.Hierarchy = "******";
                        privilegeAdmn12.AddPriv = "true";
                        privilegeAdmn12.ChangePriv = "true";
                        privilegeAdmn12.DelPriv = "true";
                        privilegeAdmn12.ViewPriv = "true";
                        privilegeAdmn12.PrivilegeName = "Agency Control File Maintenance";
                        privilegeAdmn12.DateLSTC = string.Empty;
                        privilegeAdmn12.LSTCOperator = BaseForm.UserID;
                        privilegeAdmn12.DateAdd = string.Empty;
                        privilegeAdmn12.AddOperator = BaseForm.UserID;
                        privilegeAdmn12.ModuleName = string.Empty;
                        privilegeAdmn12.showMenu = "Y";
                        privilegeAdmn12.screenType = "SCREEN";
                        userPrivilege.Insert(0, privilegeAdmn12);




                        privilegeAdmn12 = new PrivilegeEntity();
                        privilegeAdmn12.UserID = BaseForm.UserID;
                        privilegeAdmn12.ModuleCode = "01";
                        privilegeAdmn12.Program = "TRIGPARA";
                        privilegeAdmn12.Hierarchy = "******";
                        privilegeAdmn12.AddPriv = "true";
                        privilegeAdmn12.ChangePriv = "true";
                        privilegeAdmn12.DelPriv = "true";
                        privilegeAdmn12.ViewPriv = "true";
                        privilegeAdmn12.PrivilegeName = "Trigger Parameters";
                        privilegeAdmn12.DateLSTC = string.Empty;
                        privilegeAdmn12.LSTCOperator = BaseForm.UserID;
                        privilegeAdmn12.DateAdd = string.Empty;
                        privilegeAdmn12.AddOperator = BaseForm.UserID;
                        privilegeAdmn12.ModuleName = string.Empty;
                        privilegeAdmn12.showMenu = "Y";
                        privilegeAdmn12.screenType = "SCREEN";
                        userPrivilege.Insert(0, privilegeAdmn12);



                    }
                    if (code == "01" && BaseForm.UserID.ToUpper() == "CAPLOGICS")
                    {
                        PrivilegeEntity privilegeAdmn12 = new PrivilegeEntity();
                        privilegeAdmn12.UserID = BaseForm.UserID;
                        privilegeAdmn12.ModuleCode = "01";
                        privilegeAdmn12.Program = "ADMN0014";
                        privilegeAdmn12.Hierarchy = "******";
                        privilegeAdmn12.AddPriv = "true";
                        privilegeAdmn12.ChangePriv = "true";
                        privilegeAdmn12.DelPriv = "true";
                        privilegeAdmn12.ViewPriv = "true";
                        privilegeAdmn12.PrivilegeName = "CAP LOGICS Settings";
                        privilegeAdmn12.DateLSTC = string.Empty;
                        privilegeAdmn12.LSTCOperator = BaseForm.UserID;
                        privilegeAdmn12.DateAdd = string.Empty;
                        privilegeAdmn12.AddOperator = BaseForm.UserID;
                        privilegeAdmn12.ModuleName = string.Empty;
                        privilegeAdmn12.showMenu = "Y";
                        privilegeAdmn12.screenType = "SCREEN";
                        userPrivilege.Insert(0, privilegeAdmn12);
                    }

                    List<PrivilegeEntity> screentypewiselist = userPrivilege.FindAll(u => u.screenType.Trim() == menuitem.MemberCode.Trim());

                    if (screentypewiselist != null && screentypewiselist.Count > 0)
                    {
                        screentypewiselist = screentypewiselist.FindAll(u => u.showMenu.ToString().ToUpper() == "Y");
                        screentypewiselist = screentypewiselist.OrderBy(u => u.PrivilegeName).ToList();
                        foreach (PrivilegeEntity privilegeEntity in screentypewiselist)
                        {
                            TreeNode childNode = new TreeNode(privilegeEntity.PrivilegeName);
                            childNode.Image = new IconResourceHandle(Consts.Icons16x16.Entry);
                            childNode.IsExpanded = false;
                            childNode.Tag = privilegeEntity;
                            parentNode.Nodes.Add(childNode);
                        }
                        TreeView.Nodes.Add(parentNode);
                    }
                }
            }


           
            //if (userPrivilege != null && userPrivilege.Count > 0)
            //{
            //    userPrivilege = userPrivilege.FindAll(u => u.showMenu.ToString().ToUpper() == "Y");
            //    userPrivilege = userPrivilege.OrderBy(u => u.PrivilegeName).ToList();

            //    foreach (PrivilegeEntity privilegeEntity in userPrivilege)
            //    {
            //        parentNode.Image = new IconResourceHandle(Consts.Icons16x16.AddItem);
            //        parentNode.IsExpanded = true;
            //        TreeNode childNode = new TreeNode(privilegeEntity.PrivilegeName);
            //        childNode.Image = new IconResourceHandle(Consts.Icons16x16.Entry);
            //        childNode.IsExpanded = false;
            //        childNode.Tag = privilegeEntity;
            //        parentNode.Nodes.Add(childNode);
            //    }
            //    TreeView.Nodes.Add(parentNode);
            //}

            userPrivilege.Clear();
            parentNode = new TreeNode("Reports");
            parentNode.Image = new IconResourceHandle(Consts.Icons16x16.AddItem);
            userPrivilege = model.UserProfileAccess.GetReportsByUserID(code, BaseForm.UserID);
            if (userPrivilege != null && userPrivilege.Count > 0)
            {
                userPrivilege = userPrivilege.OrderBy(u => u.PrivilegeName).ToList();
                foreach (PrivilegeEntity privilegeEntity in userPrivilege)
                {
                    parentNode.Image = new IconResourceHandle(Consts.Icons16x16.AddItem);
                    parentNode.IsExpanded = true;
                    TreeNode childNode = new TreeNode(privilegeEntity.PrivilegeName);
                    childNode.Image = new IconResourceHandle(Consts.Icons16x16.Entry);
                    childNode.IsExpanded = false;
                    childNode.Tag = privilegeEntity;
                    parentNode.Nodes.Add(childNode);
                }
                TreeView.Nodes.Add(parentNode);
            }

            userPrivilege.Clear();
            parentNode = new TreeNode("User Report Maintenance");
            parentNode.Image = new IconResourceHandle(Consts.Icons16x16.AddItem);
            parentNode.IsExpanded = true;
            userPrivilege = model.UserProfileAccess.GetUserReportMaintenanceByserID(code, BaseForm.UserID);
            if (userPrivilege != null && userPrivilege.Count > 0)
            {
                //if (code != "01")
                //{
                //    userPrivilege = userPrivilege.FindAll(u => u.Hierarchy.Equals(BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg));
                //}
                userPrivilege = userPrivilege.OrderBy(u => u.PrivilegeName).ToList();
                foreach (PrivilegeEntity privilegeEntity in userPrivilege)
                {
                    TreeNode childNode = new TreeNode(privilegeEntity.PrivilegeName);
                    childNode.Image = new IconResourceHandle(Consts.Icons16x16.Entry);
                    childNode.IsExpanded = false;
                    childNode.Tag = privilegeEntity;
                    parentNode.Nodes.Add(childNode);
                }
                TreeView.Nodes.Add(parentNode);
            }

            return true;
        }

        /// <summary>
        /// Used to get and populate the Screens & Reports.
        /// </summary>
        /// <param name="parentTreeNode"></param>
        /// <param name="parentTagClass"></param>
        /// <param name="hasCheckBox"></param>
        /// <param name="isChecked"></param>
        /// <param name="useCachedValues"></param>
        /// <param name="countryFilterList"></param>
        /// <returns></returns>
        public bool PopulateTreeMenu(string code)
        {
            string view = string.Empty;
            TreeView.Nodes.Clear();
            TreeNode parentNode;
            CaptainModel model = new CaptainModel();
            List<PrivilegeEntity> userPrivilege = model.UserProfileAccess.GetScreensByUserID(code, BaseForm.UserID, HIE);

            List<MenuBranchEntity> menubranhlist = model.UserProfileAccess.GetMenuBranches();
            if (menubranhlist.Count > 0)
            {
                foreach (MenuBranchEntity menuitem in menubranhlist)
                {
                    
                    parentNode = new TreeNode(menuitem.MemberDesc.Trim());
                    parentNode.Image = new IconResourceHandle(Consts.Icons16x16.AddItem);
                    parentNode.IsExpanded = true;

                    List<PrivilegeEntity> screentypewiselist = userPrivilege.FindAll(u => u.screenType.Trim() == menuitem.MemberCode.Trim());

                    if (screentypewiselist != null && screentypewiselist.Count > 0)
                    {
                        screentypewiselist = screentypewiselist.FindAll(u => u.showMenu.ToString().ToUpper() == "Y");
                        screentypewiselist = screentypewiselist.OrderBy(u => u.PrivilegeName).ToList();
                        foreach (PrivilegeEntity privilegeEntity in screentypewiselist)
                        {
                            TreeNode childNode = new TreeNode(privilegeEntity.PrivilegeName);
                            childNode.Image = new IconResourceHandle(Consts.Icons16x16.Entry);
                            childNode.IsExpanded = false;
                            childNode.Tag = privilegeEntity;
                            parentNode.Nodes.Add(childNode);
                        }
                        TreeView.Nodes.Add(parentNode);
                    }
                }
            }

            userPrivilege.Clear();
            parentNode = new TreeNode("Reports");
            parentNode.Image = new IconResourceHandle(Consts.Icons16x16.AddItem);
            parentNode.IsExpanded = true;
            userPrivilege = model.UserProfileAccess.GetReportsByUserID(code, BaseForm.UserID);
            if (userPrivilege != null && userPrivilege.Count > 0)
            {
                //if (code != "01")
                //{
                //    userPrivilege = userPrivilege.FindAll(u => u.Hierarchy.Equals(BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg));
                //}
                userPrivilege = userPrivilege.OrderBy(u => u.PrivilegeName).ToList();
                foreach (PrivilegeEntity privilegeEntity in userPrivilege)
                {
                    TreeNode childNode = new TreeNode(privilegeEntity.PrivilegeName);
                    childNode.Image = new IconResourceHandle(Consts.Icons16x16.Entry);
                    childNode.IsExpanded = false;
                    childNode.Tag = privilegeEntity;
                    parentNode.Nodes.Add(childNode);
                }
                TreeView.Nodes.Add(parentNode);
            }

            userPrivilege.Clear();
            parentNode = new TreeNode("User Report Maintenance");
            parentNode.Image = new IconResourceHandle(Consts.Icons16x16.AddItem);
            parentNode.IsExpanded = true;
            userPrivilege = model.UserProfileAccess.GetUserReportMaintenanceByserID(code, BaseForm.UserID);
            if (userPrivilege != null && userPrivilege.Count > 0)
            {
                //if (code != "01")
                //{
                //    userPrivilege = userPrivilege.FindAll(u => u.Hierarchy.Equals(BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg));
                //}
                userPrivilege = userPrivilege.OrderBy(u => u.PrivilegeName).ToList();
                foreach (PrivilegeEntity privilegeEntity in userPrivilege)
                {
                    TreeNode childNode = new TreeNode(privilegeEntity.PrivilegeName);
                    childNode.Image = new IconResourceHandle(Consts.Icons16x16.Entry);
                    childNode.IsExpanded = false;
                    childNode.Tag = privilegeEntity;
                    parentNode.Nodes.Add(childNode);
                }
                TreeView.Nodes.Add(parentNode);
            }

            TreeView.Update();
            TreeView.ResumeLayout();
            return true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Generates the tree for administration.
        /// </summary>
        /// <returns>Returns the true if successfull. Otherwise, returns false</returns>
        private bool PopulateAdministrationChildrenNodes()
        {
            return true;
        }

        /// <summary>
        /// Generates a tree from RelatedViewNodeType list
        /// </summary>
        /// <param name="parentTreeNode"></param>
        /// <param name="nodeTypeList"></param>
        /// <param name="hasCheckBox"></param>
        /// <param name="isChecked"></param>
        private void PopulateChildrenNodeType(TreeNode parentTreeNode, List<TagClass> nodeTypeList, bool hasCheckBox, bool isChecked)
        {
            StringBuilder timesBuilder = new StringBuilder();
            timesBuilder.AppendLine(DateTime.Now.ToString());
            TreeNodeCollection nodes = TreeView.Nodes;


            timesBuilder.AppendLine("End Update: " + DateTime.Now.ToString());
        }

        /// <summary>
        /// Generates the top tree for submission manager.
        /// </summary>
        /// <returns>Returns the true if successfull. Otherwise, returns false</returns>
        private bool PopulateTopTreeNodes()
        {
            bool result = false;

            return result;
        }

        /// <summary>
        /// Moves the current ClipboardNode.
        /// </summary>
        private void MoveClipboardNode()
        {
            if (_clipboardSourceNode == null)
            {
                _clipboardTargetNode = null;
                return;
            }

            if (_clipboardTargetNode == null)
            {
                _clipboardSourceNode = null;
                return;
            }

            BaseForm.RefreshNode(_clipboardSourceNode.Parent);

            _clipboardSourceNode = null;
            _clipboardTargetNode = null;
        }

        #endregion

    }
}
