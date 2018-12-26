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
    /// <summary>
    /// The <c>AboutDialogBox</c> window contains only version information and the name of the creator.
    /// </summary>
    public partial class AboutDialogBox : Form
    {

        public AboutDialogBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the <c>AboutDialogBox</c> is loaded, the version number is retrieved and set.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void AboutDialogBox_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            versionLabel.Text = String.Format("{0}.{1}." + Version.Build.ToString(),
                 Version.Major.ToString(), Version.Minor.ToString(), Version.MinorRevision.ToString());
            //System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();


        }

        /// <summary>
        /// The current version of the product.
        /// </summary>
        private static Version version = new Version(Application.ProductVersion);

        /// <summary>
        /// A class for the version of the product
        /// </summary>
        public static Version Version
        {
            get
            {
                return version;
            }
        }
    }
}
