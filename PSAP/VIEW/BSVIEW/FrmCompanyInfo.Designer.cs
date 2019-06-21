namespace PSAP.VIEW.BSVIEW
{
    partial class FrmCompanyInfo
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
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.dataSet_CompanyInfo = new System.Data.DataSet();
            this.TableCompanyInfo = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColCompanyName = new System.Data.DataColumn();
            this.dataColCompanyAddress = new System.Data.DataColumn();
            this.dataColCompanyLR = new System.Data.DataColumn();
            this.bindingSource_CompanyInfo = new System.Windows.Forms.BindingSource(this.components);
            this.dataColCompanyLicense = new System.Data.DataColumn();
            this.dataColZipCode = new System.Data.DataColumn();
            this.dataColPhoneNo = new System.Data.DataColumn();
            this.dataColFaxNo = new System.Data.DataColumn();
            this.dataColE_mail = new System.Data.DataColumn();
            this.dataColWebSite = new System.Data.DataColumn();
            this.labCompanyName = new DevExpress.XtraEditors.LabelControl();
            this.textCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.textCompanyAddress = new DevExpress.XtraEditors.TextEdit();
            this.labCompanyAddress = new DevExpress.XtraEditors.LabelControl();
            this.textCompanyLR = new DevExpress.XtraEditors.TextEdit();
            this.labCompanyLR = new DevExpress.XtraEditors.LabelControl();
            this.textCompanyLicense = new DevExpress.XtraEditors.TextEdit();
            this.labCompanyLicense = new DevExpress.XtraEditors.LabelControl();
            this.textZipCode = new DevExpress.XtraEditors.TextEdit();
            this.labZipCode = new DevExpress.XtraEditors.LabelControl();
            this.textPhoneNo = new DevExpress.XtraEditors.TextEdit();
            this.labPhoneNo = new DevExpress.XtraEditors.LabelControl();
            this.textFaxNo = new DevExpress.XtraEditors.TextEdit();
            this.labFaxNo = new DevExpress.XtraEditors.LabelControl();
            this.textE_mail = new DevExpress.XtraEditors.TextEdit();
            this.labE_mail = new DevExpress.XtraEditors.LabelControl();
            this.textWebSite = new DevExpress.XtraEditors.TextEdit();
            this.labWebSite = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_CompanyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableCompanyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_CompanyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCompanyAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCompanyLR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCompanyLicense.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textZipCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPhoneNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textFaxNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textE_mail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWebSite.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.BtnSave);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(877, 40);
            this.pnlTop.TabIndex = 2;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(10, 9);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pnlEdit
            // 
            this.pnlEdit.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlEdit.Appearance.Options.UseBackColor = true;
            this.pnlEdit.Controls.Add(this.textWebSite);
            this.pnlEdit.Controls.Add(this.labWebSite);
            this.pnlEdit.Controls.Add(this.textE_mail);
            this.pnlEdit.Controls.Add(this.labE_mail);
            this.pnlEdit.Controls.Add(this.textFaxNo);
            this.pnlEdit.Controls.Add(this.labFaxNo);
            this.pnlEdit.Controls.Add(this.textPhoneNo);
            this.pnlEdit.Controls.Add(this.labPhoneNo);
            this.pnlEdit.Controls.Add(this.textZipCode);
            this.pnlEdit.Controls.Add(this.labZipCode);
            this.pnlEdit.Controls.Add(this.textCompanyLicense);
            this.pnlEdit.Controls.Add(this.labCompanyLicense);
            this.pnlEdit.Controls.Add(this.textCompanyLR);
            this.pnlEdit.Controls.Add(this.labCompanyLR);
            this.pnlEdit.Controls.Add(this.textCompanyAddress);
            this.pnlEdit.Controls.Add(this.labCompanyAddress);
            this.pnlEdit.Controls.Add(this.textCompanyName);
            this.pnlEdit.Controls.Add(this.labCompanyName);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEdit.Location = new System.Drawing.Point(0, 40);
            this.pnlEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlEdit.LookAndFeel.UseWindowsXPTheme = true;
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(877, 495);
            this.pnlEdit.TabIndex = 1;
            // 
            // dataSet_CompanyInfo
            // 
            this.dataSet_CompanyInfo.DataSetName = "NewDataSet";
            this.dataSet_CompanyInfo.Tables.AddRange(new System.Data.DataTable[] {
            this.TableCompanyInfo});
            // 
            // TableCompanyInfo
            // 
            this.TableCompanyInfo.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColCompanyName,
            this.dataColCompanyAddress,
            this.dataColCompanyLR,
            this.dataColCompanyLicense,
            this.dataColZipCode,
            this.dataColPhoneNo,
            this.dataColFaxNo,
            this.dataColE_mail,
            this.dataColWebSite});
            this.TableCompanyInfo.TableName = "CompanyInfo";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(System.Guid);
            // 
            // dataColCompanyName
            // 
            this.dataColCompanyName.Caption = "公司名称";
            this.dataColCompanyName.ColumnName = "CompanyName";
            // 
            // dataColCompanyAddress
            // 
            this.dataColCompanyAddress.Caption = "公司地址";
            this.dataColCompanyAddress.ColumnName = "CompanyAddress";
            // 
            // dataColCompanyLR
            // 
            this.dataColCompanyLR.Caption = "法人";
            this.dataColCompanyLR.ColumnName = "CompanyLR";
            // 
            // bindingSource_CompanyInfo
            // 
            this.bindingSource_CompanyInfo.DataMember = "CompanyInfo";
            this.bindingSource_CompanyInfo.DataSource = this.dataSet_CompanyInfo;
            // 
            // dataColCompanyLicense
            // 
            this.dataColCompanyLicense.Caption = "组织机构代码";
            this.dataColCompanyLicense.ColumnName = "CompanyLicense";
            // 
            // dataColZipCode
            // 
            this.dataColZipCode.Caption = "邮政编码";
            this.dataColZipCode.ColumnName = "ZipCode";
            // 
            // dataColPhoneNo
            // 
            this.dataColPhoneNo.Caption = "电话";
            this.dataColPhoneNo.ColumnName = "PhoneNo";
            // 
            // dataColFaxNo
            // 
            this.dataColFaxNo.Caption = "传真";
            this.dataColFaxNo.ColumnName = "FaxNo";
            // 
            // dataColE_mail
            // 
            this.dataColE_mail.Caption = "邮箱";
            this.dataColE_mail.ColumnName = "E_mail";
            // 
            // dataColWebSite
            // 
            this.dataColWebSite.Caption = "网站";
            this.dataColWebSite.ColumnName = "WebSite";
            // 
            // labCompanyName
            // 
            this.labCompanyName.Location = new System.Drawing.Point(37, 28);
            this.labCompanyName.Name = "labCompanyName";
            this.labCompanyName.Size = new System.Drawing.Size(48, 14);
            this.labCompanyName.TabIndex = 0;
            this.labCompanyName.Text = "公司名称";
            // 
            // textCompanyName
            // 
            this.textCompanyName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_CompanyInfo, "CompanyName", true));
            this.textCompanyName.EnterMoveNextControl = true;
            this.textCompanyName.Location = new System.Drawing.Point(123, 25);
            this.textCompanyName.Name = "textCompanyName";
            this.textCompanyName.Properties.MaxLength = 100;
            this.textCompanyName.Size = new System.Drawing.Size(300, 20);
            this.textCompanyName.TabIndex = 0;
            // 
            // textCompanyAddress
            // 
            this.textCompanyAddress.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_CompanyInfo, "CompanyAddress", true));
            this.textCompanyAddress.EnterMoveNextControl = true;
            this.textCompanyAddress.Location = new System.Drawing.Point(123, 63);
            this.textCompanyAddress.Name = "textCompanyAddress";
            this.textCompanyAddress.Properties.MaxLength = 300;
            this.textCompanyAddress.Size = new System.Drawing.Size(510, 20);
            this.textCompanyAddress.TabIndex = 2;
            // 
            // labCompanyAddress
            // 
            this.labCompanyAddress.Location = new System.Drawing.Point(37, 66);
            this.labCompanyAddress.Name = "labCompanyAddress";
            this.labCompanyAddress.Size = new System.Drawing.Size(48, 14);
            this.labCompanyAddress.TabIndex = 2;
            this.labCompanyAddress.Text = "公司地址";
            // 
            // textCompanyLR
            // 
            this.textCompanyLR.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_CompanyInfo, "CompanyLR", true));
            this.textCompanyLR.EnterMoveNextControl = true;
            this.textCompanyLR.Location = new System.Drawing.Point(508, 25);
            this.textCompanyLR.Name = "textCompanyLR";
            this.textCompanyLR.Properties.MaxLength = 50;
            this.textCompanyLR.Size = new System.Drawing.Size(125, 20);
            this.textCompanyLR.TabIndex = 1;
            // 
            // labCompanyLR
            // 
            this.labCompanyLR.Location = new System.Drawing.Point(457, 28);
            this.labCompanyLR.Name = "labCompanyLR";
            this.labCompanyLR.Size = new System.Drawing.Size(24, 14);
            this.labCompanyLR.TabIndex = 4;
            this.labCompanyLR.Text = "法人";
            // 
            // textCompanyLicense
            // 
            this.textCompanyLicense.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_CompanyInfo, "CompanyLicense", true));
            this.textCompanyLicense.EnterMoveNextControl = true;
            this.textCompanyLicense.Location = new System.Drawing.Point(123, 101);
            this.textCompanyLicense.Name = "textCompanyLicense";
            this.textCompanyLicense.Properties.MaxLength = 30;
            this.textCompanyLicense.Size = new System.Drawing.Size(200, 20);
            this.textCompanyLicense.TabIndex = 3;
            // 
            // labCompanyLicense
            // 
            this.labCompanyLicense.Location = new System.Drawing.Point(37, 104);
            this.labCompanyLicense.Name = "labCompanyLicense";
            this.labCompanyLicense.Size = new System.Drawing.Size(72, 14);
            this.labCompanyLicense.TabIndex = 6;
            this.labCompanyLicense.Text = "组织机构代码";
            // 
            // textZipCode
            // 
            this.textZipCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_CompanyInfo, "ZipCode", true));
            this.textZipCode.EnterMoveNextControl = true;
            this.textZipCode.Location = new System.Drawing.Point(433, 101);
            this.textZipCode.Name = "textZipCode";
            this.textZipCode.Properties.MaxLength = 20;
            this.textZipCode.Size = new System.Drawing.Size(200, 20);
            this.textZipCode.TabIndex = 4;
            // 
            // labZipCode
            // 
            this.labZipCode.Location = new System.Drawing.Point(365, 104);
            this.labZipCode.Name = "labZipCode";
            this.labZipCode.Size = new System.Drawing.Size(48, 14);
            this.labZipCode.TabIndex = 8;
            this.labZipCode.Text = "邮政编码";
            // 
            // textPhoneNo
            // 
            this.textPhoneNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_CompanyInfo, "PhoneNo", true));
            this.textPhoneNo.EnterMoveNextControl = true;
            this.textPhoneNo.Location = new System.Drawing.Point(123, 139);
            this.textPhoneNo.Name = "textPhoneNo";
            this.textPhoneNo.Properties.MaxLength = 20;
            this.textPhoneNo.Size = new System.Drawing.Size(200, 20);
            this.textPhoneNo.TabIndex = 5;
            // 
            // labPhoneNo
            // 
            this.labPhoneNo.Location = new System.Drawing.Point(37, 142);
            this.labPhoneNo.Name = "labPhoneNo";
            this.labPhoneNo.Size = new System.Drawing.Size(24, 14);
            this.labPhoneNo.TabIndex = 10;
            this.labPhoneNo.Text = "电话";
            // 
            // textFaxNo
            // 
            this.textFaxNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_CompanyInfo, "FaxNo", true));
            this.textFaxNo.EnterMoveNextControl = true;
            this.textFaxNo.Location = new System.Drawing.Point(433, 139);
            this.textFaxNo.Name = "textFaxNo";
            this.textFaxNo.Properties.MaxLength = 30;
            this.textFaxNo.Size = new System.Drawing.Size(200, 20);
            this.textFaxNo.TabIndex = 6;
            // 
            // labFaxNo
            // 
            this.labFaxNo.Location = new System.Drawing.Point(365, 142);
            this.labFaxNo.Name = "labFaxNo";
            this.labFaxNo.Size = new System.Drawing.Size(24, 14);
            this.labFaxNo.TabIndex = 12;
            this.labFaxNo.Text = "传真";
            // 
            // textE_mail
            // 
            this.textE_mail.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_CompanyInfo, "E_mail", true));
            this.textE_mail.EnterMoveNextControl = true;
            this.textE_mail.Location = new System.Drawing.Point(123, 177);
            this.textE_mail.Name = "textE_mail";
            this.textE_mail.Properties.MaxLength = 50;
            this.textE_mail.Size = new System.Drawing.Size(200, 20);
            this.textE_mail.TabIndex = 7;
            // 
            // labE_mail
            // 
            this.labE_mail.Location = new System.Drawing.Point(37, 180);
            this.labE_mail.Name = "labE_mail";
            this.labE_mail.Size = new System.Drawing.Size(24, 14);
            this.labE_mail.TabIndex = 14;
            this.labE_mail.Text = "邮箱";
            // 
            // textWebSite
            // 
            this.textWebSite.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_CompanyInfo, "WebSite", true));
            this.textWebSite.EnterMoveNextControl = true;
            this.textWebSite.Location = new System.Drawing.Point(433, 177);
            this.textWebSite.Name = "textWebSite";
            this.textWebSite.Properties.MaxLength = 50;
            this.textWebSite.Size = new System.Drawing.Size(200, 20);
            this.textWebSite.TabIndex = 8;
            // 
            // labWebSite
            // 
            this.labWebSite.Location = new System.Drawing.Point(365, 180);
            this.labWebSite.Name = "labWebSite";
            this.labWebSite.Size = new System.Drawing.Size(24, 14);
            this.labWebSite.TabIndex = 16;
            this.labWebSite.Text = "网站";
            // 
            // FrmCompanyInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(877, 535);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmCompanyInfo";
            this.TabText = "公司信息";
            this.Text = "公司信息";
            this.Load += new System.EventHandler(this.FrmCompanyInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_CompanyInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableCompanyInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_CompanyInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCompanyAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCompanyLR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCompanyLicense.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textZipCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPhoneNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textFaxNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textE_mail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWebSite.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private System.Data.DataSet dataSet_CompanyInfo;
        private System.Data.DataTable TableCompanyInfo;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColCompanyName;
        private System.Data.DataColumn dataColCompanyAddress;
        private System.Data.DataColumn dataColCompanyLR;
        private System.Data.DataColumn dataColCompanyLicense;
        private System.Data.DataColumn dataColZipCode;
        private System.Data.DataColumn dataColPhoneNo;
        private System.Data.DataColumn dataColFaxNo;
        private System.Data.DataColumn dataColE_mail;
        private System.Data.DataColumn dataColWebSite;
        private System.Windows.Forms.BindingSource bindingSource_CompanyInfo;
        private DevExpress.XtraEditors.LabelControl labCompanyName;
        private DevExpress.XtraEditors.TextEdit textCompanyName;
        private DevExpress.XtraEditors.TextEdit textWebSite;
        private DevExpress.XtraEditors.LabelControl labWebSite;
        private DevExpress.XtraEditors.TextEdit textE_mail;
        private DevExpress.XtraEditors.LabelControl labE_mail;
        private DevExpress.XtraEditors.TextEdit textFaxNo;
        private DevExpress.XtraEditors.LabelControl labFaxNo;
        private DevExpress.XtraEditors.TextEdit textPhoneNo;
        private DevExpress.XtraEditors.LabelControl labPhoneNo;
        private DevExpress.XtraEditors.TextEdit textZipCode;
        private DevExpress.XtraEditors.LabelControl labZipCode;
        private DevExpress.XtraEditors.TextEdit textCompanyLicense;
        private DevExpress.XtraEditors.LabelControl labCompanyLicense;
        private DevExpress.XtraEditors.TextEdit textCompanyLR;
        private DevExpress.XtraEditors.LabelControl labCompanyLR;
        private DevExpress.XtraEditors.TextEdit textCompanyAddress;
        private DevExpress.XtraEditors.LabelControl labCompanyAddress;
    }
}