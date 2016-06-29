using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSTSCLib;

namespace RDP_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(btnConnect.Text=="链接")
            {
                //MessageBox.Show("正在准备链接...");
                //if()
                if(string.IsNullOrEmpty(cbxserver.Text) || string.IsNullOrEmpty(cbxusername.Text) || string.IsNullOrEmpty(txtpassword.Text))
                {
                    MessageBox.Show("请输入一个有效的远程连接信息———主机IP，端口号，用户名，密码！", "登录失败提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    rdpClient.Server = cbxserver.Text;
                    rdpClient.UserName = cbxusername.Text;
                    rdpClient.AdvancedSettings2.RDPPort = 3389;
                    rdpClient.AdvancedSettings2.SmartSizing = true;

                    rdpClient.AdvancedSettings9.NegotiateSecurityLayer = true;

                    IMsTscNonScriptable secured = (IMsTscNonScriptable)rdpClient.GetOcx();
                    secured.ClearTextPassword = txtpassword.Text;
                    rdpClient.AdvancedSettings5.ClearTextPassword = txtpassword.Text;

                    rdpClient.ColorDepth = 24;

                    //rdpClient.Width = this.Size.Width;
                    //rdpClient.Height = this.Size.Height;
                    //rdpClient.DesktopWidth = this.Size.Width;
                    //rdpClient.DesktopHeight = this.Size.Height;
                    //rdpClient.FullScreenTitle = "this is test";

                    rdpClient.Connect();

                    btnConnect.Text = "Disconnect";
                    btnConnect.BackColor = Color.Red;
                }
            }

            else
            {
                btnConnect.Text = "Connect";
                btnConnect.BackColor = Color.PaleGreen;
                try
                {
                    rdpClient.Disconnect();
                }
                catch(Exception)
                {

                }

                rdpClient.Refresh();
            }
        }
     

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            rdpClient.FullScreen = !rdpClient.FullScreen;
            //rdpClient.Width = this.Size.Width;
            //rdpClient.Height = this.Size.Height;
            //rdpClient.DesktopWidth = this.Size.Width;
            //rdpClient.DesktopHeight = this.Size.Height;
        }
    }
}
