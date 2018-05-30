namespace PolBoot
{
    partial class FrmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.FLP_Selects = new System.Windows.Forms.FlowLayoutPanel();
            this.RdoJP = new System.Windows.Forms.RadioButton();
            this.RdoUS = new System.Windows.Forms.RadioButton();
            this.RdoEU = new System.Windows.Forms.RadioButton();
            this.FLP_Installed = new System.Windows.Forms.FlowLayoutPanel();
            this.LblPOL = new System.Windows.Forms.Label();
            this.LblFFXI = new System.Windows.Forms.Label();
            this.LblRoZ = new System.Windows.Forms.Label();
            this.LblCoP = new System.Windows.Forms.Label();
            this.LblToA = new System.Windows.Forms.Label();
            this.LblWoG = new System.Windows.Forms.Label();
            this.LblSoA = new System.Windows.Forms.Label();
            this.TxtPOLDir = new System.Windows.Forms.TextBox();
            this.TxtFFXIDir = new System.Windows.Forms.TextBox();
            this.BtnPOL = new System.Windows.Forms.Button();
            this.BtnPOLCfg = new System.Windows.Forms.Button();
            this.BtnFFXICfg = new System.Windows.Forms.Button();
            this.TLP_Main.SuspendLayout();
            this.FLP_Selects.SuspendLayout();
            this.FLP_Installed.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            resources.ApplyResources(this.TLP_Main, "TLP_Main");
            this.TLP_Main.Controls.Add(this.FLP_Selects, 0, 0);
            this.TLP_Main.Controls.Add(this.FLP_Installed, 0, 1);
            this.TLP_Main.Controls.Add(this.TxtPOLDir, 0, 2);
            this.TLP_Main.Controls.Add(this.TxtFFXIDir, 0, 3);
            this.TLP_Main.Controls.Add(this.BtnPOL, 0, 4);
            this.TLP_Main.Controls.Add(this.BtnPOLCfg, 0, 5);
            this.TLP_Main.Controls.Add(this.BtnFFXICfg, 0, 6);
            this.TLP_Main.Name = "TLP_Main";
            // 
            // FLP_Selects
            // 
            resources.ApplyResources(this.FLP_Selects, "FLP_Selects");
            this.FLP_Selects.Controls.Add(this.RdoJP);
            this.FLP_Selects.Controls.Add(this.RdoUS);
            this.FLP_Selects.Controls.Add(this.RdoEU);
            this.FLP_Selects.Name = "FLP_Selects";
            // 
            // RdoJP
            // 
            resources.ApplyResources(this.RdoJP, "RdoJP");
            this.RdoJP.Checked = true;
            this.RdoJP.Name = "RdoJP";
            this.RdoJP.TabStop = true;
            this.RdoJP.UseVisualStyleBackColor = true;
            this.RdoJP.CheckedChanged += new System.EventHandler(this.RdoJP_CheckedChanged);
            // 
            // RdoUS
            // 
            resources.ApplyResources(this.RdoUS, "RdoUS");
            this.RdoUS.Name = "RdoUS";
            this.RdoUS.UseVisualStyleBackColor = true;
            this.RdoUS.CheckedChanged += new System.EventHandler(this.RdoUS_CheckedChanged);
            // 
            // RdoEU
            // 
            resources.ApplyResources(this.RdoEU, "RdoEU");
            this.RdoEU.Name = "RdoEU";
            this.RdoEU.TabStop = true;
            this.RdoEU.UseVisualStyleBackColor = true;
            this.RdoEU.CheckedChanged += new System.EventHandler(this.RdoEU_CheckedChanged);
            // 
            // FLP_Installed
            // 
            resources.ApplyResources(this.FLP_Installed, "FLP_Installed");
            this.FLP_Installed.Controls.Add(this.LblPOL);
            this.FLP_Installed.Controls.Add(this.LblFFXI);
            this.FLP_Installed.Controls.Add(this.LblRoZ);
            this.FLP_Installed.Controls.Add(this.LblCoP);
            this.FLP_Installed.Controls.Add(this.LblToA);
            this.FLP_Installed.Controls.Add(this.LblWoG);
            this.FLP_Installed.Controls.Add(this.LblSoA);
            this.FLP_Installed.Name = "FLP_Installed";
            // 
            // LblPOL
            // 
            resources.ApplyResources(this.LblPOL, "LblPOL");
            this.LblPOL.Name = "LblPOL";
            // 
            // LblFFXI
            // 
            resources.ApplyResources(this.LblFFXI, "LblFFXI");
            this.LblFFXI.Name = "LblFFXI";
            // 
            // LblRoZ
            // 
            resources.ApplyResources(this.LblRoZ, "LblRoZ");
            this.LblRoZ.Name = "LblRoZ";
            // 
            // LblCoP
            // 
            resources.ApplyResources(this.LblCoP, "LblCoP");
            this.LblCoP.Name = "LblCoP";
            // 
            // LblToA
            // 
            resources.ApplyResources(this.LblToA, "LblToA");
            this.LblToA.Name = "LblToA";
            // 
            // LblWoG
            // 
            resources.ApplyResources(this.LblWoG, "LblWoG");
            this.LblWoG.Name = "LblWoG";
            // 
            // LblSoA
            // 
            resources.ApplyResources(this.LblSoA, "LblSoA");
            this.LblSoA.Name = "LblSoA";
            // 
            // TxtPOLDir
            // 
            resources.ApplyResources(this.TxtPOLDir, "TxtPOLDir");
            this.TxtPOLDir.Name = "TxtPOLDir";
            this.TxtPOLDir.ReadOnly = true;
            // 
            // TxtFFXIDir
            // 
            resources.ApplyResources(this.TxtFFXIDir, "TxtFFXIDir");
            this.TxtFFXIDir.Name = "TxtFFXIDir";
            this.TxtFFXIDir.ReadOnly = true;
            // 
            // BtnPOL
            // 
            resources.ApplyResources(this.BtnPOL, "BtnPOL");
            this.BtnPOL.Name = "BtnPOL";
            this.BtnPOL.UseVisualStyleBackColor = true;
            this.BtnPOL.Click += new System.EventHandler(this.BtnPOL_Click);
            // 
            // BtnPOLCfg
            // 
            resources.ApplyResources(this.BtnPOLCfg, "BtnPOLCfg");
            this.BtnPOLCfg.Name = "BtnPOLCfg";
            this.BtnPOLCfg.UseVisualStyleBackColor = true;
            this.BtnPOLCfg.Click += new System.EventHandler(this.BtnPOLCfg_Click);
            // 
            // BtnFFXICfg
            // 
            resources.ApplyResources(this.BtnFFXICfg, "BtnFFXICfg");
            this.BtnFFXICfg.Name = "BtnFFXICfg";
            this.BtnFFXICfg.UseVisualStyleBackColor = true;
            this.BtnFFXICfg.Click += new System.EventHandler(this.BtnFFXICfg_Click);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLP_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.TLP_Main.ResumeLayout(false);
            this.TLP_Main.PerformLayout();
            this.FLP_Selects.ResumeLayout(false);
            this.FLP_Selects.PerformLayout();
            this.FLP_Installed.ResumeLayout(false);
            this.FLP_Installed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.FlowLayoutPanel FLP_Selects;
        private System.Windows.Forms.RadioButton RdoJP;
        private System.Windows.Forms.RadioButton RdoUS;
        private System.Windows.Forms.RadioButton RdoEU;
        private System.Windows.Forms.FlowLayoutPanel FLP_Installed;
        private System.Windows.Forms.Label LblPOL;
        private System.Windows.Forms.Label LblFFXI;
        private System.Windows.Forms.Label LblRoZ;
        private System.Windows.Forms.Label LblCoP;
        private System.Windows.Forms.Label LblToA;
        private System.Windows.Forms.Label LblWoG;
        private System.Windows.Forms.Label LblSoA;
        private System.Windows.Forms.TextBox TxtPOLDir;
        private System.Windows.Forms.TextBox TxtFFXIDir;
        private System.Windows.Forms.Button BtnPOL;
        private System.Windows.Forms.Button BtnPOLCfg;
        private System.Windows.Forms.Button BtnFFXICfg;
    }
}

