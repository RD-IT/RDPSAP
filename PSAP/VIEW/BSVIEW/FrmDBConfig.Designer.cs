namespace PSAP.VIEW.BSVIEW
{
    partial class FrmDBConfig
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnTestConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.textPassword = new DevExpress.XtraEditors.TextEdit();
            this.textUserID = new DevExpress.XtraEditors.TextEdit();
            this.textDataSource = new DevExpress.XtraEditors.TextEdit();
            this.labPassword = new DevExpress.XtraEditors.LabelControl();
            this.labUserID = new DevExpress.XtraEditors.LabelControl();
            this.labDataSource = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDataSource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnTestConnect);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.textPassword);
            this.panelControl1.Controls.Add(this.textUserID);
            this.panelControl1.Controls.Add(this.textDataSource);
            this.panelControl1.Controls.Add(this.labPassword);
            this.panelControl1.Controls.Add(this.labUserID);
            this.panelControl1.Controls.Add(this.labDataSource);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(284, 281);
            this.panelControl1.TabIndex = 0;
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.Location = new System.Drawing.Point(190, 189);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(75, 23);
            this.btnTestConnect.TabIndex = 5;
            this.btnTestConnect.TabStop = false;
            this.btnTestConnect.Text = "测试连接";
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(104, 189);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textPassword
            // 
            this.textPassword.EnterMoveNextControl = true;
            this.textPassword.Location = new System.Drawing.Point(119, 129);
            this.textPassword.Name = "textPassword";
            this.textPassword.Properties.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(132, 20);
            this.textPassword.TabIndex = 2;
            // 
            // textUserID
            // 
            this.textUserID.EnterMoveNextControl = true;
            this.textUserID.Location = new System.Drawing.Point(119, 95);
            this.textUserID.Name = "textUserID";
            this.textUserID.Size = new System.Drawing.Size(132, 20);
            this.textUserID.TabIndex = 1;
            // 
            // textDataSource
            // 
            this.textDataSource.EnterMoveNextControl = true;
            this.textDataSource.Location = new System.Drawing.Point(119, 60);
            this.textDataSource.Name = "textDataSource";
            this.textDataSource.Size = new System.Drawing.Size(132, 20);
            this.textDataSource.TabIndex = 0;
            // 
            // labPassword
            // 
            this.labPassword.Location = new System.Drawing.Point(30, 132);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(24, 14);
            this.labPassword.TabIndex = 2;
            this.labPassword.Text = "密码";
            // 
            // labUserID
            // 
            this.labUserID.Location = new System.Drawing.Point(30, 98);
            this.labUserID.Name = "labUserID";
            this.labUserID.Size = new System.Drawing.Size(36, 14);
            this.labUserID.TabIndex = 1;
            this.labUserID.Text = "用户名";
            // 
            // labDataSource
            // 
            this.labDataSource.Location = new System.Drawing.Point(30, 63);
            this.labDataSource.Name = "labDataSource";
            this.labDataSource.Size = new System.Drawing.Size(71, 14);
            this.labDataSource.TabIndex = 0;
            this.labDataSource.Text = "数据库IP地址";
            // 
            // FrmDBConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 281);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDBConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库配置";
            this.Load += new System.EventHandler(this.FrmDBConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDataSource.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit textDataSource;
        private DevExpress.XtraEditors.LabelControl labPassword;
        private DevExpress.XtraEditors.LabelControl labUserID;
        private DevExpress.XtraEditors.LabelControl labDataSource;
        private DevExpress.XtraEditors.TextEdit textUserID;
        private DevExpress.XtraEditors.TextEdit textPassword;
        private DevExpress.XtraEditors.SimpleButton btnTestConnect;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}