using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Net;

using System.Globalization;
using System.Threading;



using mshtml;

namespace AccessibleEPUB
{
    public partial class MathDialogBox : Form
    {
        WpfMath.Controls.FormulaControl formula = new WpfMath.Controls.FormulaControl();
        IHTMLDocument2 doc;
        private WpfMath.TexFormulaParser formulaParser = new WpfMath.TexFormulaParser();
        private string svgFile;
        //private string pngFile;

        string imageFolderPath;
        


        //string initialPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
        string initialPath = Directory.GetCurrentDirectory();
        //string ip = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
        string ip = Environment.CurrentDirectory.ToString();

        string accEpubFolderName = Path.Combine(Path.GetTempPath(), "AccessibleEPUB");


        public MathDialogBox(IHTMLDocument2 mainWindowDoc, string imagePath)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());
            InitializeComponent();

            doc = mainWindowDoc;

            host.Dock = DockStyle.Fill;
            host.Child = formula;

            System.Windows.Media.Brush br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            formula.BorderBrush = br;
            formula.BorderThickness = new Thickness(3, 3, 3, 3);

            imageFolderPath = imagePath;
            noneRadioButton.Checked = true;
        }

        public MathDialogBox(IHTMLDocument2 mainWindowDoc, string imagePath, string mathCode, string title, string figCaption, string floatValue)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());
            InitializeComponent();

            doc = mainWindowDoc;

            host.Dock = DockStyle.Fill;
            host.Child = formula;

            System.Windows.Media.Brush br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            formula.BorderBrush = br;
            formula.BorderThickness = new Thickness(3, 3, 3, 3);

            inputTextBox.Text = mathCode;
            titleTextBox.Text = title;
            captionTextBox.Text = figCaption;

            imageFolderPath = imagePath;


            if (floatValue == "none")
            {
                noneRadioButton.Checked = true;
            }
            else if (floatValue == "left")
            {
                leftRadioButton.Checked = true;
            }
            else if (floatValue == "right")
            {
                rightRadioButton.Checked = true;
            }


        }



        private void insertFormulaButton_Click(object sender, EventArgs e)
        {
            if (formula.HasError)
            {
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.invalidFormulaContent, Resource_MessageBox.invalidFormulaTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }




            string pandoc = Path.Combine(ip, "pandoc-2.1");
            string currentDic = Directory.GetCurrentDirectory();


            string accFile = Path.Combine(accEpubFolderName, "accEpub.txt");
            string formulaResult = Path.Combine(accEpubFolderName, "formulaResult.txt");

            Directory.SetCurrentDirectory(pandoc);

            if (inputTextBox.Text == "")
            {
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.noFormulaContent, Resource_MessageBox.noFormulaTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            
            string title;
            string titleTag;
            if (!(titleTextBox.Text == ""))
            {
                title = titleTextBox.Text;
                titleTag = @""" title=""" + titleTextBox.Text + "\"";
            }
            else
            {
                do
                {
                    title = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                } while (File.Exists(Path.Combine(imageFolderPath, title + ".svg")));                            
                titleTag = "";
            }

            string caption;
            string captionTag;

            if (!(captionTextBox.Text == "")) {
                caption = captionTextBox.Text;
                captionTag = "<figcaption style=\"text-align:left\">" + caption + @"</figcaption>";
            }
            else
            {
                captionTag = "";
            }

            string styleTag = "";

            if (noneRadioButton.Checked == true)
            {

            }
            else if (leftRadioButton.Checked == true)
            {
                styleTag = " style=\"float:left;\" ";
            }
            else if (rightRadioButton.Checked == true)
            {
                styleTag = " style=\"float:right;\" ";
            }



            //if (titleTextBox.Text == "")
            //{
            //    System.Windows.Forms.MessageBox.Show("Please enter a title.", "Missing title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}


            System.IO.File.WriteAllText(accFile, "$" + inputTextBox.Text + "$");
            //Console.WriteLine(System.IO.File.ReadAllText(accFile));
            //string imagesFolder = Path.Combine(imageFolderPath, "images");
            string imagesFolder = imageFolderPath;

            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            string imagePath = Path.Combine(imagesFolder, title + ".svg");
            svgFile = imagePath;

            saveSVG(inputTextBox.Text, svgFile, title);
            imagePath = svgFile;
            Directory.SetCurrentDirectory(pandoc);
            //Console.WriteLine(svgFile);
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //FileName = "pandoc", //Path.Combine(pandoc, "pandoc"),
                    FileName = @"c:\windows\system32\cmd.exe",
                    Arguments = @"/c pandoc --mathml " + accFile + " > " + formulaResult,
                    //UseShellExecute = false,
                    //RedirectStandardOutput = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            
            
            proc.Start();
            proc.WaitForExit();
            string math = "";
            //while (!proc.StandardOutput.EndOfStream)
            //{
            //    math += proc.StandardOutput.ReadLine();
            //    // do something with line
            //}
            math = System.IO.File.ReadAllText(formulaResult);
            //math += proc.StandardOutput.ReadToEnd();
            
            string result = Path.Combine(accEpubFolderName, "result.txt");

            //Console.WriteLine(proc.StartInfo.FileName.ToString());
            //Console.WriteLine(proc.StartInfo.Arguments.ToString());
            System.IO.File.WriteAllText(result, math);
            string split = "<semantics>";
            string split2 = "</semantics>";
            string mathResult = math.Substring(math.IndexOf(split));
            //Console.WriteLine(math);
            //Console.WriteLine(mathResult.LastIndexOf(split2));
            //Console.WriteLine(mathResult);
            mathResult = mathResult.Substring(0, mathResult.LastIndexOf(split2) + split2.Length);

            bool encodeMode = false;
      
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < mathResult.Length; i++)
            {
                string toAdd = "";
                if (mathResult[i] == '>')
                {
                    encodeMode = true;
                    toAdd = ">";
                }
                else if (mathResult[i] == '<')
                {
                    encodeMode = false;
                    toAdd = "<";
                } 
                else
                {
                    toAdd = WebUtility.HtmlEncode(mathResult[i]+"");
                }
                sb.Append(toAdd);
                //Console.WriteLine(mathResult[i] + "     " + WebUtility.HtmlEncode(mathResult[i] + ""));
            }



            string mathFinalResult = sb.ToString();
            //Console.WriteLine(mathFinalResult);

            //if (!Directory.Exists(imageFolderPath))
            //{
            //    Directory.CreateDirectory(imageFolderPath);
            //}

            //string imagesFolder = Path.Combine(imageFolderPath, "images");
            //string imagePath = Path.Combine(imagesFolder, title + ".svg");

            //if (File.Exists(imagePath))
            //{
            //    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Formula with same title already exists in the document. Should the file be overwritten?", "Overwrite file", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        System.IO.File.Copy(svgFile, imagePath, true);
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        return;
            //    }
            //}

            //svgFile = imagePath;



            //string imagePath = Path.Combine(imagesFolder, Path.GetFileName(svgFile));

            //try { 
            //    System.IO.File.Copy(svgFile, imagePath);
            //}
            //catch (IOException ie)
            //{
            //    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Formula with same title already exists in the document. Should the file be overwritten?", "Overwrite file", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        System.IO.File.Copy(svgFile, imagePath, true);
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        return;
            //    }
            //}
     
            string formulaToAdd = "";

            formulaToAdd += "\n<figure>";

            // titleTag = @""" title=""" + titleTextBox.Text
            string mathHeader = @"<div" + styleTag + @" role=""math"" class=""math""><math xmlns=""http://www.w3.org/1998/Math/MathML"" altimg=""" + imagePath +  titleTag + @""" alttext=""" + inputTextBox.Text + @""">" + "" + "<mstyle>";

            string mathHeaderImpaired = @"<div" + styleTag + @" role=""math"" class=""mathImpaired""><math xmlns=""http://www.w3.org/1998/Math/MathML"" altimg=""" + imagePath + titleTag + @""" alttext=""" + inputTextBox.Text + @""">" + "" + "<mstyle scriptsizemultiplier=\"1\" lspace=\"20%\" rspace=\"20%\" mathvariant=\"sans-serif\">";

            
            string mathEnd = "</mstyle></math>";


            formulaToAdd += "" + (@"<!--RemoveThis--><img class=""toRemove"" " + titleTag + @"src =""" + imagePath + @""" alt =""" + inputTextBox.Text + @""" //><!--RemoveEnd-->");

            string divEnd = "</div>";
            //formulaToAdd += divEnd;



            dynamic currentLocation = doc.selection.createRange();
            //r.pasteHTML(mathHeader + mathResult + mathEnd);
            formulaToAdd += mathHeader + mathFinalResult + mathEnd + divEnd;

            formulaToAdd += mathHeaderImpaired + mathFinalResult + mathEnd + divEnd;

            string altTextParagraph = "<p class=\"transparent\">$" + inputTextBox.Text + "$</p>";

            formulaToAdd += altTextParagraph + captionTag + "</figure>\n"; ;

            //doc.body.innerHTML += formulaToAdd;

           
            currentLocation.pasteHTML(formulaToAdd);

            //doc.body.innerHTML += "</figure>\n";

            Directory.SetCurrentDirectory(currentDic);


            //doc.body.innerHTML = doc.body.innerHTML.Replace("<br>", "");
            //doc.body.innerHTML = doc.body.innerHTML.Replace("<BR>", "");
            //doc.body.innerHTML = doc.body.innerHTML.Replace("<p></p>", "");
            //doc.body.innerHTML = doc.body.innerHTML.Replace("<P></P>", "");
            //doc.body.innerHTML = doc.body.innerHTML.Replace("&nbsp;", "");

            //doc.body.innerHTML = "<br>" + doc.body.innerHTML;
            //doc.body.innerHTML = doc.body.innerHTML + "<br>";
            //doc.body.innerHTML = doc.body.innerHTML.Replace("<figure>", "<br><figure>");
            //doc.body.innerHTML = doc.body.innerHTML.Replace("</figure>", "</figure><br>");
            
            this.DialogResult = DialogResult.OK;
            this.Hide();
            this.Dispose();
   
            //doc.body.innerText += math;
            //formula.HorizontalAlignment

            //         doc.body.innerHTML += @"<div role=""math"" class=""math"">
            //<math xmlns = ""http://www.w3.org/1998/Math/MathML"" id = ""Formula"" title = ""Quadratic Formula"" alttext = ""{ x = \frac{{ - b \pm \sqrt {b^2 - 4ac} }}{{2a}}}"">

            //         <mrow>

            //          <mi> x </mi>

            //          <mo>=</mo>

            //          <mfrac>

            //            <mrow>

            //              <mrow>

            //                <mo> -</mo>

            //                <mi> b </mi>

            //              </mrow>

            //              <mo>±</mo>

            //                <msqrt>

            //                  <mrow>

            //                    <msup>

            //                      <mi> b </mi>

            //                      <mn> 2 </mn>

            //                    </msup>

            //                    <mo> -</mo>

            //                    <mrow>

            //                      <mn> 4 </mn>

            //                      <mo>⁢</mo>

            //                        <mi> a </mi>

            //                        <mo>⁢</mo>

            //                          <mi> c </mi>

            //                        </mrow>

            //                      </mrow>

            //                    </msqrt>

            //                  </mrow>

            //                  <mrow>

            //                    <mn> 2 </mn>

            //                    <mo>⁢</mo>

            //                      <mi> a </mi>

            //                    </mrow>

            //                  </mfrac>

            //                 </mrow>

            //                </math>
            //            </div> ";
        }


        private WpfMath.TexFormula ParseFormula(string input)
        {
            // Create formula object from input text.
            WpfMath.TexFormula formula = null;
            try
            {
                formula = formulaParser.Parse(input);
            }
            catch (Exception ex)
            {
                //System.Windows.MessageBox.Show("An error occurred while parsing the given input:" + Environment.NewLine +
                //    Environment.NewLine + ex.Message, "Accessible EPUB", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Windows.MessageBox.Show(Resource_MessageBox.parseInputContent + Environment.NewLine +
                    Environment.NewLine + ex.Message, "Accessible EPUB", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return formula;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Choose file
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "SVG Files (*.svg)|*.svg|PNG Files (*.png)|*.png"
            };
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.Abort) return;

            // Create formula object from input text.
            WpfMath.TexFormula formula = ParseFormula(inputTextBox.Text);
            if (formula == null) return;
            var renderer = formula.GetRenderer(WpfMath.TexStyle.Display, this.formula.Scale, "Arial");
            // Open stream
            var filename = saveFileDialog.FileName;
            using (var stream = new FileStream(filename, FileMode.Create))
            {
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        var geometry = renderer.RenderToGeometry(0, 0);
                        var converter = new WpfMath.SVGConverter();
                        var svgPathText = converter.ConvertGeometry(geometry);
                        var svgText = AddSVGHeader(svgPathText);
                        using (var writer = new StreamWriter(stream))
                            writer.WriteLine(svgText);
                        break;
                    case 2:
                        var bitmap = renderer.RenderToBitmap(0, 0);
                        var encoder = new PngBitmapEncoder
                        {
                            Frames = { BitmapFrame.Create(bitmap) }
                        };
                        encoder.Save(stream);
                        break;
                    default:
                        return;
                }
            }
        }

        private void saveSVG(string input, string filePath, string title)
        {
            //string imagesFolder = Path.Combine(imageFolderPath, "images");
            string imagesFolder = imageFolderPath;
            if (!File.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }
            //Console.WriteLine(filePath);
            string currentDic = Directory.GetCurrentDirectory();

            System.IO.DirectoryInfo di = new DirectoryInfo(imagesFolder);

            //foreach (FileInfo file in di.GetFiles())
            //{
            //    file.Delete();
            //}
            //foreach (DirectoryInfo dir in di.GetDirectories())
            //{
            //    dir.Delete(true);
            //}
            //while (di.GetDirectories().Length != 0 || di.GetFiles().Length != 0)
            //{
            //    var result = System.Windows.Forms.MessageBox.Show("Could not delete all files in temp folder", "Error Title", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            //    if (result == DialogResult.Retry)
            //    {
            //        foreach (FileInfo file in di.GetFiles())
            //        {
            //            file.Delete();
            //        }
            //        foreach (DirectoryInfo dir in di.GetDirectories())
            //        {
            //            dir.Delete(true);
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            Directory.SetCurrentDirectory(imagesFolder);

            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            //string imagesFolder = Path.Combine(imageFolderPath, "images");
            string imagePath = Path.Combine(imagesFolder, title + ".svg");

            if (File.Exists(imagePath))
            {
                //DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Formula with same title already exists in the document. Should the file be overwritten?", "Overwrite file", MessageBoxButtons.YesNo);
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(Resource_MessageBox.formulaOverwriteContent , Resource_MessageBox.formulaOverwriteTitle, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //System.IO.File.Delete(svgFile);
                    //System.IO.File.Copy(svgFile, imagePath, true);
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            svgFile = imagePath;



            WpfMath.TexFormula formula = ParseFormula(input);
            if (formula == null) return;
            var renderer = formula.GetRenderer(WpfMath.TexStyle.Display, this.formula.Scale, "Arial");
            // Open stream
            //var pngFilename = Path.Combine(imagesFolder, titleTextBox.Text + ".png");
            //var svgFilename = Path.Combine(imagesFolder, titleTextBox.Text + ".svg");
            //svgFile = svgFilename;
            //pngFile = pngFilename;

            //using (var stream = new FileStream(pngFilename, FileMode.Create))
            //{
               
            //    //var geometry = renderer.RenderToGeometry(0, 0);
            //    //var converter = new WpfMath.SVGConverter();
            //    //var svgPathText = converter.ConvertGeometry(geometry);
            //    //var svgText = this.AddSVGHeader(svgPathText);
            //    //using (var writer = new StreamWriter(stream))
            //    //    writer.WriteLine(svgText);

            //    var bitmap = renderer.RenderToBitmap(0, 0);
            //    var encoder = new PngBitmapEncoder
            //    {
            //        Frames = { BitmapFrame.Create(bitmap) }
            //    };
            //    encoder.Save(stream);

            //}

            using (var stream = new FileStream(svgFile, FileMode.Create))
            {

                var geometry = renderer.RenderToGeometry(0, 0);
                var converter = new WpfMath.SVGConverter();
                var svgPathText = converter.ConvertGeometry(geometry);
                var svgText = this.AddSVGHeader(svgPathText);
                using (var writer = new StreamWriter(stream))
                    writer.WriteLine(svgText);


            }
            Directory.SetCurrentDirectory(currentDic);

        }

        private string AddSVGHeader(string svgText)
        {

            var builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>")
                .AppendLine("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" >")
                .AppendLine(svgText)
                .AppendLine("</svg>");

            return builder.ToString();
        }



        private void MathDialogBox_Load(object sender, EventArgs e)
        {
            //this.formulaParser = new WpfMath.TexFormulaParser();

            //var testFormula1 = "\\int_0^{\\infty}{x^{2n} e^{-a x^2} dx} = \\frac{2n-1}{2a} \\int_0^{\\infty}{x^{2(n-1)} e^{-a x^2} dx} = \\frac{(2n-1)!!}{2^{n+1}} \\sqrt{\\frac{\\pi}{a^{2n+1}}}";
            //var testFormula2 = "\\int_a^b{f(x) dx} = (b - a) \\sum_{n = 1}^{\\infty}  {\\sum_{m = 1}^{2^n  - 1} { ( { - 1} )^{m + 1} } } 2^{ - n} f(a + m ( {b - a}  )2^{-n} )";
            //var testFormula3 = @"L = \int_a^b \sqrt[4]{ \left| \sum_{i,j=1}^ng_{ij}\left(\gamma(t)\right) \left[\frac{d}{dt}x^i\circ\gamma(t) \right] \left{\frac{d}{dt}x^j\circ\gamma(t) \right} \right|}dt";
            //this.inputTextBox.Text = testFormula3;
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            string lastFormula = this.formula.Formula;
            
            this.formula.Formula = inputTextBox.Text;

            if (this.formula.HasError)
            {
                System.Windows.Media.Brush br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                formula.BorderBrush = br;
                formula.BorderThickness = new Thickness(3, 3, 3, 3);                
                this.formula.Formula = lastFormula;
            }
            else
            {
                System.Windows.Media.Brush br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                formula.BorderBrush = br;
                formula.BorderThickness = new Thickness(3, 3, 3, 3);

               
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
            this.Dispose();
        }
    }
}
