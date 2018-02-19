using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using System.Diagnostics;
using System.Deployment.Application;

namespace AccessibleEPUB
{
    public partial class AboutDialogBox : Form
    {
        public AboutDialogBox()
        {
            InitializeComponent();
        }

        private void AboutDialogBox_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            versionLabel.Text = String.Format("{0}.{1}",
                 Version.Major.ToString(), Version.Minor.ToString());
            //System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();


        }

        private static Version version = new Version(Application.ProductVersion);

        public static Version Version
        {
            get
            {
                return version;
            }
        }
    }
}
