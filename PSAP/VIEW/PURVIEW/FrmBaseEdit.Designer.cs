﻿namespace PSAP.VIEW.BSVIEW
{
    partial class FrmBaseEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaseEdit));
            this.pnlButton = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnCollapse = new DevExpress.XtraEditors.SimpleButton();
            this.btnExpand = new DevExpress.XtraEditors.SimpleButton();
            this.labContent = new DevExpress.XtraEditors.LabelControl();
            this.textContent = new DevExpress.XtraEditors.TextEdit();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButton)).BeginInit();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textContent.Properties)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnSaveExcel);
            this.pnlButton.Controls.Add(this.btnRefresh);
            this.pnlButton.Controls.Add(this.btnDelete);
            this.pnlButton.Controls.Add(this.btnCancel);
            this.pnlButton.Controls.Add(this.btnSave);
            this.pnlButton.Controls.Add(this.btnNew);
            this.pnlButton.Controls.Add(this.btnCollapse);
            this.pnlButton.Controls.Add(this.btnExpand);
            this.pnlButton.Controls.Add(this.labContent);
            this.pnlButton.Controls.Add(this.textContent);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButton.Location = new System.Drawing.Point(0, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(1091, 57);
            this.pnlButton.TabIndex = 0;
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.AllowFocus = false;
            this.btnSaveExcel.Location = new System.Drawing.Point(415, 9);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveExcel.TabIndex = 18;
            this.btnSaveExcel.TabStop = false;
            this.btnSaveExcel.Text = "存为Excel";
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AllowFocus = false;
            this.btnRefresh.Location = new System.Drawing.Point(334, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "查询";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AllowFocus = false;
            this.btnDelete.Location = new System.Drawing.Point(253, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AllowFocus = false;
            this.btnCancel.Location = new System.Drawing.Point(172, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AllowFocus = false;
            this.btnSave.Location = new System.Drawing.Point(91, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "修改";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.AllowFocus = false;
            this.btnNew.Location = new System.Drawing.Point(10, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.AllowFocus = false;
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(1056, 9);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(26, 23);
            this.btnCollapse.TabIndex = 202;
            this.btnCollapse.Text = "+";
            this.btnCollapse.ToolTip = "查找下一个";
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.AllowFocus = false;
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(1024, 9);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(26, 23);
            this.btnExpand.TabIndex = 201;
            this.btnExpand.TabStop = false;
            this.btnExpand.Text = "-";
            this.btnExpand.ToolTip = "查找上一个";
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // labContent
            // 
            this.labContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labContent.Location = new System.Drawing.Point(841, 13);
            this.labContent.Name = "labContent";
            this.labContent.Size = new System.Drawing.Size(48, 14);
            this.labContent.TabIndex = 1;
            this.labContent.Text = "查找定位";
            // 
            // textContent
            // 
            this.textContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textContent.EnterMoveNextControl = true;
            this.textContent.Location = new System.Drawing.Point(898, 10);
            this.textContent.Name = "textContent";
            this.textContent.Size = new System.Drawing.Size(120, 20);
            this.textContent.TabIndex = 200;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiEdit});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(100, 22);
            this.tsmiSave.Text = "保存";
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(100, 22);
            this.tsmiEdit.Text = "修改";
            // 
            // FrmBaseEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1091, 57);
            this.Controls.Add(this.pnlButton);
            this.Name = "FrmBaseEdit";
            this.TabText = "基础资料基类窗体";
            this.Text = "基础资料基类窗体";
            this.Load += new System.EventHandler(this.FrmProjectList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlButton)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.pnlButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textContent.Properties)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlButton;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        public DevExpress.XtraEditors.SimpleButton btnSaveExcel;
        private DevExpress.XtraEditors.LabelControl labContent;
        private DevExpress.XtraEditors.TextEdit textContent;
        private DevExpress.XtraEditors.SimpleButton btnExpand;
        private DevExpress.XtraEditors.SimpleButton btnCollapse;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        internal System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        public DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}