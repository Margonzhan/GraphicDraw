using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SubBusContrainer;
namespace TreeviewContrainer
{
    public partial class treeviewContrainer: UserControl
    {
        private ProductContrainer productContrainer;
        public ProductContrainer ProductContrainer
        {
            get { return productContrainer; }
            set
            {
                if (value != null)
                {
                    productContrainer = value;
                    string _name = DateTime.Now.ToString("hh_mm_ss");
                    treeView_ProductInfo.Nodes.Add(_name);
                }
            }
        }
        public treeviewContrainer()
        {
            InitializeComponent();
           
        }

        private void treeView_ProductInfo_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (treeView_ProductInfo.SelectedNode == null)
                return;
            treeView_ProductInfo.DoDragDrop(treeView_ProductInfo.SelectedNode.Text, DragDropEffects.Copy);
        }

        private void treeView_ProductInfo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point point = this.treeView_ProductInfo.PointToScreen(e.Location);
                TreeNode _treeNode = this.treeView_ProductInfo.GetNodeAt(e.Location);
                if (_treeNode != null)
                {
                    if (_treeNode.Level == 0)
                        this.contextMenuStrip1.Show(point);
                    else
                        this.contextMenuStrip2.Show(point);
                    this.treeView_ProductInfo.SelectedNode = _treeNode;
                }
            }
            else
            {
                Point point = this.treeView_ProductInfo.PointToScreen(e.Location);
                TreeNode _treeNode = this.treeView_ProductInfo.GetNodeAt(e.Location);
                if (_treeNode != null)
                {
                    this.treeView_ProductInfo.SelectedNode = _treeNode;
                }
            }
        }

        private void treeView_ProductInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode _treeNode = this.treeView_ProductInfo.GetNodeAt(e.Location);
            this.treeView_ProductInfo.SelectedNode = _treeNode;
            if (_treeNode != null)
            {
                //if (_treeNode.Level == 0)
                //    MessageBox.Show("BusModel");
                //else
                //    MessageBox.Show("SubModel");
                productContrainer.ShowProperty(_treeNode.Text);
            }
        }

        private void tSMItem_BusModel_Property_Click(object sender, EventArgs e)
        {
            TreeNode _treenode = treeView_ProductInfo.SelectedNode;
            if (_treenode != null)
            {
                productContrainer.ShowProperty(_treenode.Text);
            }
        }

        private void tSMItem_SubModel_Property_Click(object sender, EventArgs e)
        {
            TreeNode _treenode = treeView_ProductInfo.SelectedNode;
            if (_treenode != null)
            {
                productContrainer.ShowProperty(_treenode.Text);
            }
        }

        private void tSMItem_BusMedel_Add_Click(object sender, EventArgs e)
        {
            TreeNode _treenode = treeView_ProductInfo.SelectedNode;
            if (_treenode != null)
            {
                string name = DateTime.Now.TimeOfDay.ToString();
                treeView_ProductInfo.SelectedNode.Nodes.Add(name, name);
                productContrainer.AddSubProduct(name);

            }
        }

        private void tSMItem_SubModel_Delete_Click(object sender, EventArgs e)
        {
            TreeNode _treenode = treeView_ProductInfo.SelectedNode;
            if (_treenode != null)
            {
                productContrainer.RemoveSubProduct(_treenode.Text);
                _treenode.Parent.Nodes.Remove(_treenode);


            }
        }
        public  void ProductContrainer_ControlBaseRemoveEvent(object sender, SubBusContrainer.ControlBaseRemoveEventArgs e)
        {
            TreeNode _treenode = treeView_ProductInfo.SelectedNode;
            if (_treenode != null)
            {
                if (_treenode.Level == 0)
                {
                    _treenode.Nodes.RemoveByKey(e.ControlName);

                }
                else
                    _treenode.Parent.Nodes.RemoveByKey(e.ControlName);
            }

        }
    }
}
