using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmSystem : DockContent
    {
        DevExpress.XtraEditors.SimpleButton simBtn;

        public FrmSystem()
        {
            InitializeComponent();
            simBtn = new DevExpress.XtraEditors.SimpleButton();
            simBtn.Name = "simBtn";
            simBtn.Text = "Panel构造代码创建";
            simBtn.Location = new System.Drawing.Point(200, 200);
            simBtn.Size = new System.Drawing.Size(75, 23);
            simBtn.TabIndex = 0;
            panelControl1.Controls.Add(simBtn);

            DevExpress.XtraEditors.SimpleButton simBtn123 = new DevExpress.XtraEditors.SimpleButton();
            simBtn123.Name = "simBtn123";
            simBtn123.Text = "构造代码创建";
            simBtn.Location = new System.Drawing.Point(200, 200);
            simBtn.Size = new System.Drawing.Size(75, 23);
            simBtn.TabIndex = 0;
            this.Controls.Add(simBtn123);
        }

        private void FrmSystem_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageHandler.ShowMessageBox(this.Name + ((DevExpress.XtraEditors.SimpleButton)sender).Name);

            MessageHandler.ShowMessageBox("SimpleButton_Click!!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageHandler.ShowMessageBox("Button_Click???");
            
        }

        protected void AddClick(object sender, EventArgs e)
        {
            MessageHandler.ShowMessageBox("I am Winner...");
        }
    }
}
