namespace TreeviewContrainer
{
    partial class treeviewContrainer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView_ProductInfo = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMItem_BusMedel_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMItem_BusModel_Property = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMItem_SubModel_Property = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMItem_SubModel_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_ProductInfo
            // 
            this.treeView_ProductInfo.AllowDrop = true;
            this.treeView_ProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_ProductInfo.Location = new System.Drawing.Point(0, 0);
            this.treeView_ProductInfo.Name = "treeView_ProductInfo";
            this.treeView_ProductInfo.Size = new System.Drawing.Size(253, 499);
            this.treeView_ProductInfo.TabIndex = 0;
            this.treeView_ProductInfo.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ProductInfo_ItemDrag);
            this.treeView_ProductInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView_ProductInfo_MouseClick);
            this.treeView_ProductInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_ProductInfo_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMItem_BusMedel_Add,
            this.tSMItem_BusModel_Property});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 60);
            // 
            // tSMItem_BusMedel_Add
            // 
            this.tSMItem_BusMedel_Add.Name = "tSMItem_BusMedel_Add";
            this.tSMItem_BusMedel_Add.Size = new System.Drawing.Size(240, 28);
            this.tSMItem_BusMedel_Add.Text = "添加";
            this.tSMItem_BusMedel_Add.Click += new System.EventHandler(this.tSMItem_BusMedel_Add_Click);
            // 
            // tSMItem_BusModel_Property
            // 
            this.tSMItem_BusModel_Property.Name = "tSMItem_BusModel_Property";
            this.tSMItem_BusModel_Property.Size = new System.Drawing.Size(240, 28);
            this.tSMItem_BusModel_Property.Text = "属性";
            this.tSMItem_BusModel_Property.Click += new System.EventHandler(this.tSMItem_BusModel_Property_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMItem_SubModel_Property,
            this.tSMItem_SubModel_Delete});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(241, 93);
            // 
            // tSMItem_SubModel_Property
            // 
            this.tSMItem_SubModel_Property.Name = "tSMItem_SubModel_Property";
            this.tSMItem_SubModel_Property.Size = new System.Drawing.Size(240, 28);
            this.tSMItem_SubModel_Property.Text = "属性";
            this.tSMItem_SubModel_Property.Click += new System.EventHandler(this.tSMItem_SubModel_Property_Click);
            // 
            // tSMItem_SubModel_Delete
            // 
            this.tSMItem_SubModel_Delete.Name = "tSMItem_SubModel_Delete";
            this.tSMItem_SubModel_Delete.Size = new System.Drawing.Size(240, 28);
            this.tSMItem_SubModel_Delete.Text = "删除";
            this.tSMItem_SubModel_Delete.Click += new System.EventHandler(this.tSMItem_SubModel_Delete_Click);
            // 
            // treeviewContrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView_ProductInfo);
            this.Name = "treeviewContrainer";
            this.Size = new System.Drawing.Size(253, 499);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_ProductInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tSMItem_BusMedel_Add;
        private System.Windows.Forms.ToolStripMenuItem tSMItem_BusModel_Property;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tSMItem_SubModel_Property;
        private System.Windows.Forms.ToolStripMenuItem tSMItem_SubModel_Delete;
    }
}
