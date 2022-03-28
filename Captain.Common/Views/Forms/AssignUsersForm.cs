/************************************************************************************
 * Class Name    : AssignUsersForm
 * Author        : 
 * Created Date  : 
 * Version       : 1.0.0
 * Description   : This is AssignUsers class, which is used to add/overwrite the Users.
 ************************************************************************************/

#region Using

using Gizmox.WebGUI.Forms;
using Captain.Common.Utilities;
using Captain.Common.Views.Forms.Base;
using Captain.Common.Controllers;
using Captain.Common.Model.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using Gizmox.WebGUI.Common.Resources;
using System.Diagnostics;
using Captain.Common.Exceptions;

#endregion

namespace ViewPoint.Common.Views.Forms
{
    public partial class AssignUsersForm : Form
    {
        #region Variables

        private string _objectID = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="baseForm"></param>
        /// <param name="objectID"></param>
        public AssignUsersForm(BaseForm baseForm, string objectID)
        {
            InitializeComponent();

            BaseForm = baseForm;
            _objectID = objectID;

            CurrentItemsAssigned = new List<TreeNode>();
        }

        #endregion

        #region Properties

        public BaseForm BaseForm { get; set; }

        public TagClass SelectedNodeTagClass { get; set; }

         public List<TreeNode> CurrentItemsAssigned { get; set; }

        public List<ListItem> SelectedItems
        {
            get
            {
                List<ListItem> list = new List<ListItem>();
                List<TreeNode> nodes = tvwSelected.Nodes.Cast<TreeNode>().ToList();
                for (int nodeIndex = 0; nodeIndex < nodes.Count; nodeIndex++)
                {
                    list.Add(nodes[nodeIndex].Tag as ListItem);
                }
                return list;
            }
        }

        /// <summary>
        /// To get the role name
        /// </summary>
        public string Role
        {
            get
            {
                string returnValue = string.Empty;

                if (cmbRole.SelectedIndex > 0)
                {
                    returnValue = ((ListItem)cmbRole.SelectedItem).Text;
                }

                return returnValue;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Populate the roles dropdown
        /// </summary>
        private void PopulateRoles()
        {
            try
            {
                CheckButtonsState();

            }
            catch (Exception ex)
            {
                StackFrame stackframe = new StackFrame(true);
                ExceptionLogger.LogException(stackframe, ex, ExceptionSeverityLevel.High);
            }
        }

 
        /// <summary>
        /// Sets the enalbed state of the buttons
        /// </summary>
        private void CheckButtonsState()
        {
            btnOK.Enabled = SelectedItems.Count > 0;
            btnMoveAllLeftToRight.Enabled = tvwAvailable.Nodes.Count > 0;
            btnMoveAllRightToLeft.Enabled = tvwSelected.Nodes.Count > 0;
            btnMoveLeftRight.Enabled = tvwAvailable.SelectedNode != null;
            btnMoveRightToLeft.Enabled = tvwSelected.SelectedNode != null;
        }

        /// <summary>
        /// Removes items on the available list that are in the selected list.
        /// </summary>
        /// <param name="removedNodeName"></param>
        private void RemoveSelectedTreeNodeFromAvailableTree(string removedNodeName)
        {
            for (int availableIndex = 0; availableIndex < tvwAvailable.Nodes.Count; availableIndex++)
            {
                TreeNode node = tvwAvailable.Nodes[availableIndex];
                if (node.Text.Equals(removedNodeName))
                {
                    tvwAvailable.SelectedNode = null;
                    tvwAvailable.Nodes.Remove(node);
                }
                else if (node.HasNodes)
                {
                    for (int availableSubIndex = 0; availableSubIndex < node.Nodes.Count; availableSubIndex++)
                    {
                        TreeNode subNode = subNode = node.Nodes[availableSubIndex];
                        if (subNode.Text.Equals(removedNodeName))
                        {
                            tvwAvailable.SelectedNode = null;
                            node.Nodes.Remove(subNode);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// get the user Full name.
        /// </summary>
        /// <returns></returns>
        private string GetUserFullName(UserEntity user)
        {
            string returnValue = string.Empty;

            if (user != null)
            {
            }
            return returnValue;
        }

        #endregion

        #region Handled Events

        /// <summary>
        /// Handles form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssignUsersFormLoad(object sender, EventArgs e)
        {
            PopulateRoles();

            if (CurrentItemsAssigned != null && CurrentItemsAssigned.Count > 0)
            {
                TreeNode parentNode = null;
                ListItem item = null;
                UserEntity user = null;

                for (int currentItemIndex = 0; currentItemIndex < CurrentItemsAssigned.Count; currentItemIndex++)
                {
                    item =(ListItem)CurrentItemsAssigned[currentItemIndex].Tag;
                    if (item.ID.Equals(Consts.Common.UserGroup))
                    {
                        parentNode = new TreeNode() { Text = item.Text, Image = new IconResourceHandle(Consts.Icons16x16.Users), Tag=item };


                        
                        tvwSelected.Nodes.Add(parentNode);
                    }
                    else
                    {
                        tvwSelected.Nodes.Add(CurrentItemsAssigned[currentItemIndex]);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the ok button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKClick(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles the Cancel button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelClick(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Handles the selected index change event of the roles dropdown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedIndex > 0)
            {
                ListItem listItem = cmbRole.SelectedItem as ListItem;

                if (listItem != null)
                {
                    tvwAvailable.Nodes.Clear();
                    //BindUsersAndGroupsBasedOnRoleID(listItem.ID);
                }

                CheckButtonsState();
            }
        }

        /// <summary>
        /// Move all list items from the list of available modules to list of selected modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveAllItemsLeftToRight(object sender, System.EventArgs e)
        {
            if (tvwAvailable.Nodes.Count > 0)
            {
                tvwSelected.SuspendLayout();

                List<TreeNode> nodeList = tvwAvailable.Nodes.Cast<TreeNode>().ToList();

                for (int nodeIndex = 0; nodeIndex < nodeList.Count; nodeIndex++)
                {
                    TreeNode treeNode = nodeList[nodeIndex];
                    if (treeNode.HasNodes)
                    {
                        TreeNode newTreeNode = new TreeNode() { Text = treeNode.Text, Tag = treeNode.Tag, Image = treeNode.Image };
                        treeNode = newTreeNode;
                    }

                    tvwSelected.Nodes.Add(treeNode);
                }

                tvwSelected.ResumeLayout(false);

                tvwAvailable.Nodes.Clear();
                tvwSelected.Sort();
                tvwSelected.Update();
                tvwAvailable.SelectedNode = null;
                tvwAvailable.Update();
            }

            CheckButtonsState();
        }

        /// <summary>
        /// Move all list items from the list of selected modules to list of modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveAllItemsRightToLeft(object sender, System.EventArgs e)
        {
            tvwSelected.Nodes.Clear();
            tvwSelected.SelectedNode = null;
            tvwSelected.Update();

            RoleSelectedIndexChanged(sender, e);
            CheckButtonsState();
        }

        /// <summary>
        /// Move all selected items from the list of selected modules to list of modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void MoveSelectedItemsRightToLeft(object sender, System.EventArgs e)
        {
            if (tvwSelected.Nodes.Count > 0)
            {
                TreeNode node = null;

                tvwSelected.SuspendLayout();
                for (int selectedIndex = 0; selectedIndex < tvwSelected.Nodes.Count; selectedIndex++)
                {
                    node = tvwSelected.Nodes[selectedIndex];
                    if (node.IsSelected)
                    {
                        tvwSelected.SelectedNode = null;
                        tvwSelected.Nodes.Remove(node);
                        selectedIndex--;
                    }
                }

                tvwSelected.ResumeLayout(false);
                RoleSelectedIndexChanged(sender, e);
                CheckButtonsState();
            }
        }

        /// <summary>
        /// Move all selected items from the list of available modules to list of selected modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveSelectedItemsLeftToRight(object sender, System.EventArgs e)
        {
            if (tvwAvailable.Nodes.Count > 0)
            {
                tvwAvailable.SuspendLayout();
                tvwSelected.SuspendLayout();
                string removedNodeName = string.Empty;

                for (int availableIndex = 0; availableIndex < tvwAvailable.Nodes.Count; availableIndex++)
                {
                    TreeNode treeNode = tvwAvailable.Nodes[availableIndex];
                    if (treeNode.IsSelected)
                    {
                        tvwAvailable.SelectedNode = null;
                        if (treeNode.HasNodes)
                        {
                            TreeNode newTreeNode = new TreeNode() { Text = treeNode.Text, Tag = treeNode.Tag, Image = treeNode.Image };
                            treeNode = newTreeNode;
                        }
                        tvwSelected.Nodes.Add(treeNode);
                        removedNodeName = treeNode.Text;
                        tvwAvailable.Nodes.Remove(treeNode);
                        break;
                    }
                    else if (treeNode.HasNodes)
                    {
                        for (int availableSubIndex = 0; availableSubIndex < treeNode.Nodes.Count; availableSubIndex++)
                        {
                            TreeNode subTreeNode = treeNode.Nodes[availableSubIndex];
                            if (subTreeNode.IsSelected)
                            {
                                tvwAvailable.SelectedNode = null;
                                tvwSelected.Nodes.Add(subTreeNode);
                                removedNodeName = subTreeNode.Text;
                                treeNode.Nodes.Remove(subTreeNode);
                                break;
                            }
                        }

                        if (!string.IsNullOrEmpty(removedNodeName)) { break; }
                    }
                }

                if (!string.IsNullOrEmpty(removedNodeName))
                {
                    RemoveSelectedTreeNodeFromAvailableTree(removedNodeName);
                }

                tvwAvailable.ResumeLayout(false);
                tvwSelected.ResumeLayout(false);
                CheckButtonsState();
            }
        }

        /// <summary>
        /// Handles both treeview click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewNodeClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            CheckButtonsState();
        }

        #endregion
    }
}