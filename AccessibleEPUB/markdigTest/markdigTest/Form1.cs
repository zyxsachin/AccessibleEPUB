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
using System.Text.RegularExpressions;

using ReverseMarkdown;

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
            ReverseMarkdown.Converter converter = new ReverseMarkdown.Converter();

            string parsed = parseMarkdown(richTextBox1.Text);

            richTextBox2.Text = Markdig.Markdown.ToHtml(parsed);
            //richTextBox2.Text = converter.Convert(richTextBox1.Text);

            //File.WriteAllText(site, richTextBox2.Text);
        }

        private string parseMarkdown(string toParse)
        {
            string locationParameter;


            string result = toParse;

            Regex toParseRegex = new Regex(@"\$\$image\s*\n*\{[^\}]*\}");
            Regex locationRegex = new Regex(@"\$\$location\s*:\s*([^\n]*)");
            Regex titleRegex = new Regex(@"\$\$title\s*:\s*([^\n]*)");
            Regex altRegex = new Regex(@"\$\$alt\s*:\s*([^\n]*)");
            Regex captionRegex = new Regex(@"\$\$caption\s*:\s*([^\n]*)");
            Regex tagRegex = new Regex(@"\$\$tag\s*:\s*([^\n]*)");
            Regex widthRegex = new Regex(@"\$\$width\s*:\s*([^\n]*)");
            Regex heightRegex = new Regex(@"\$\$height\s*:\s*([^\n]*)");
            Regex altImageRegex = new Regex(@"\$\$altImage\s*:\s*([^\n]*)");
            Regex alignRegex = new Regex(@"\$\$align\s*:\s*([^\n]*)");


            string imageBlock = toParseRegex.Match(toParse).ToString();
            Console.WriteLine(imageBlock);

            string locationString = locationRegex.Match(imageBlock).ToString();
            MatchCollection locationMatches = locationRegex.Matches(imageBlock);
            Match locationMatch = locationRegex.Match(imageBlock);

            locationParameter = locationMatch.Groups[1].Value;

            Console.WriteLine(locationString);

            //foreach (Match m in locationMatches)
            //{
            //    locationParameter = m.Groups[1].Value);
            //}





            //if (images.Count > 0)
            //{

            //}


            return result;
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
