using System;
using System.Windows.Forms;

namespace PolBoot
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            RdoJP.Checked = true;
        }

        private void RdoJP_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoJP.Checked) UpdateInfo(PlatformType.JP);
        }

        private void RdoUS_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoUS.Checked) UpdateInfo(PlatformType.US);
        }

        private void RdoEU_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoEU.Checked) UpdateInfo(PlatformType.EU);
        }

        private void UpdateInfo(PlatformType type)
        {
            if (Program.PolTool == null) return;

            LblPOL.Enabled = Program.PolTool[type].POL_Installed;
            LblFFXI.Enabled = Program.PolTool[type].FFXI_Installed;
            LblRoZ.Enabled = Program.PolTool[type].FFXI_RoZ_Installed;
            LblCoP.Enabled = Program.PolTool[type].FFXI_CoP_Installed;
            LblToA.Enabled = Program.PolTool[type].FFXI_ToA_Installed;
            LblWoG.Enabled = Program.PolTool[type].FFXI_WoG_Installed;
            LblSoA.Enabled = Program.PolTool[type].FFXI_SoA_Installed;

            if (Program.PolTool[type].POL_Installed)
            {
                TxtPOLDir.Text = Program.PolTool[type].POL_Dir;
                BtnPOL.Enabled = true;
                BtnPOLCfg.Enabled = true;
            }
            else
            {
                TxtPOLDir.Text = "(POL Not Installed)";
                BtnPOL.Enabled = false;
                BtnPOLCfg.Enabled = false;
            }

            if (Program.PolTool[type].FFXI_Installed)
            {
                TxtFFXIDir.Text = Program.PolTool[type].FFXI_Dir;
                BtnFFXICfg.Enabled = true;
            }
            else
            {
                TxtFFXIDir.Text = "(FFXI Not Installed)";
                BtnFFXICfg.Enabled = false;
            }
        }

        private void BtnPOL_Click(object sender, EventArgs e)
        {
            if (RdoUS.Checked)
            {
                ExecPol(PlatformType.US);
            }
            else if (RdoEU.Checked)
            {
                ExecPol(PlatformType.EU);
            }
            else
            {
                ExecPol(PlatformType.JP);
            }
        }

        private void BtnPOLCfg_Click(object sender, EventArgs e)
        {
            if (RdoUS.Checked)
            {
                ExecPolCfg(PlatformType.US);
            }
            else if (RdoEU.Checked)
            {
                ExecPolCfg(PlatformType.EU);
            }
            else
            {
                ExecPolCfg(PlatformType.JP);
            }
        }

        private void BtnFFXICfg_Click(object sender, EventArgs e)
        {
            if (RdoUS.Checked)
            {
                ExecFfxiCfg(PlatformType.US);
            }
            else if (RdoEU.Checked)
            {
                ExecFfxiCfg(PlatformType.EU);
            }
            else
            {
                ExecFfxiCfg(PlatformType.JP);
            }
        }

        private Regsvr32FailedCallbackResult Regsvr32FailedCallback(string s)
        {
            switch (MessageBox.Show("Regsvr32 Failed: " + s, "ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1))
            {
                case DialogResult.Abort:
                    return Regsvr32FailedCallbackResult.Abort;
                case DialogResult.Retry:
                    return Regsvr32FailedCallbackResult.Retry;
                case DialogResult.Ignore:
                    return Regsvr32FailedCallbackResult.Ignore;
                default:
                    return Regsvr32FailedCallbackResult.Abort;
            }
        }

        private void ExecPol(PlatformType type)
        {
            if (!Program.PolTool[type].POL_Installed)
            {
                MessageBox.Show("POL Not Installed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Program.PolTool[type].FFXI_Installed)
            {
                if (!Program.PolTool.ExecRegsvr32(type, Regsvr32FailedCallback))
                {
                    MessageBox.Show("Regsvr32 Failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var proc = Program.PolTool.ExecPol(type);
            if (proc == null)
            {
                MessageBox.Show("POL Boot Failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Hide();
                Program.PolTool.WaitForExitPol(type);
                Show();
            }
        }

        private void ExecPolCfg(PlatformType type)
        {
            if (!Program.PolTool[type].POL_Installed)
            {
                MessageBox.Show("POL Not Installed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var proc = Program.PolTool.ExecPolCfg(type);
            if (proc == null)
            {
                MessageBox.Show("POL Config Boot Failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Hide();
                proc.WaitForExit();
                Show();
            }
        }

        private void ExecFfxiCfg(PlatformType type)
        {
            if (!Program.PolTool[type].FFXI_Installed)
            {
                MessageBox.Show("FFXI Not Installed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var proc = Program.PolTool.ExecFfxiCfg(type);
            if (proc == null)
            {
                MessageBox.Show("FFXI Config Boot Failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Hide();
                proc.WaitForExit();
                Show();
            }
        }
    }
}
