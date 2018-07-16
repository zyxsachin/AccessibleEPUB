using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Markdig;
using Gecko;
using System.IO;

using System.Net;

namespace markdigTest
{
    public partial class Form1 : Form
    {
        string site;

        public Form1()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            site = Path.Combine(System.Environment.CurrentDirectory, "web.html");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = Markdig.Markdown.ToHtml(richTextBox1.Text);
            
            File.WriteAllText(site, richTextBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //gw1.Visible = !gw1.Visible;
            panel1.Visible = !panel1.Visible;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //geckoWebBrowser1.Navigate("http://google.com");
            geckoWebBrowser1.Navigate(site);
        }
    }
}
