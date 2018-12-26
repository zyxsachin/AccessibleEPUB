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
    /// <summary>
    /// The <c>MathDialogBox</c> is used to add images to the EPUB file, which will be inside a figure, and it will 
    /// contain LaTeX code for blind users as simple text.
    /// </summary>
    public partial class MathDialogBox : Form
    {
        /// <summary>
        /// The display showing the parsed LaTeX code of the formula.
        /// </summary>
        WpfMath.Controls.FormulaControl formula = new WpfMath.Controls.FormulaControl();

        /// <summary>
        /// The HTML document to which the figure with the math is added to.
        /// </summary>
        IHTMLDocument2 doc;

        /// <summary>
        /// The parser which parses LaTeX math code so it can be shown visually.
        /// </summary>
        private WpfMath.TexFormulaParser formulaParser = new WpfMath.TexFormulaParser();

        /// <summary>
        /// The path to the SVG file.
        /// </summary>
        private string svgFile;
        //private string pngFile;

        /// <summary>
        /// The path to the temp image folder of the EPUB file.
        /// </summary>
        string imageFolderPath;
        


        //string initialPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();

        
        //string initialPath = Directory.GetCurrentDirectory();
        //string ip = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
        //string ip = Environment.CurrentDirectory.ToString();

        /// <summary>
        /// The path where Accessible EPUB is being executed.
        /// </summary>
        string ip = System.Windows.Forms.Application.StartupPath;

        /// <summary>
        /// The name of the folder in the <c>tempFolder</c>, which Accessible EPUB uses.
        /// </summary>
        string accEpubFolderName = Path.Combine(Path.GetTempPath(), "AccessibleEPUB");

        /// <summary>
        /// The constructor which is used to transfer information about the current EPUB file and editor
        /// to the <c>MathDialogBox</c>.
        /// </summary>
        /// <param name="mainWindowDoc">The HTML document of the current file in the editor.</param>
        /// <param name="imagePath">The temp path to the images folder.</param>
        public MathDialogBox(IHTMLDocument2 mainWindowDoc, string imagePath)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());
            InitializeComponent();

            doc = mainWindowDoc;

            /* The display showing the parsed formula is set up. */
            host.Dock = DockStyle.Fill;
            host.Child = formula;

            System.Windows.Media.Brush br = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            formula.BorderBrush = br;
            formula.BorderThickness = new Thickness(3, 3, 3, 3);

            imageFolderPath = imagePath;
            noneRadioButton.Checked = true;
        }

        /// <summary>
        /// The constructor used when an image is edited. All the important informatmathion is transferred as parameters.
        /// </summary>
        /// <param name="mainWindowDoc">The HTML document of the current file in the editor.</param>
        /// <param name="imagePath">The temp path to the images folder.</param>
        /// <param name="mathCode">The LaTeX code of the formula.</param>
        /// <param name="title">The title of the formula.</param>
        /// <param name="figCaption">The caption of the figure.</param>
        /// <param name="floatValue">The alignment of the figure.</param>
        public MathDialogBox(IHTMLDocument2 mainWindowDoc, string imagePath, string mathCode, string title, string figCaption, string floatValue)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());
            InitializeComponent();

            doc = mainWindowDoc;

            /* The display showing the parsed formula is set up. */
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


        /// <summary>
        /// Inserts a figure with a mathematic formula inside. A SVG is also there so that the formula can be shown 
        /// in the WYSIWYG editor. 
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void insertFormulaButton_Click(object sender, EventArgs e)
        {
            /* Checks if the parser override checkbox is checked, as the WPFMath parser does not support all LaTeX math features. */
            if (overrideParserCheckBox.Checked == false)
            {
                if (this.formula.HasError)
                {
                    System.Windows.Forms.MessageBox.Show(Resource_MessageBox.invalidFormulaContent, Resource_MessageBox.invalidFormulaTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }




            string pandoc = Path.Combine(ip, "pandoc-2.1");
            string currentDic = Directory.GetCurrentDirectory();

            /* accFile is how Accessible EPUB passes the LaTeX math code to pandoc. */
            string accFile = Path.Combine(accEpubFolderName, "accEpub.txt");
            /* formulaResult is the result from pandoc. */
            string formulaResult = Path.Combine(accEpubFolderName, "formulaResult.txt");

            Directory.SetCurrentDirectory(pandoc);

            if (inputTextBox.Text == "")
            {
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.noFormulaContent, Resource_MessageBox.noFormulaTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            
            string title;
            string titleTag;

            //TODO Check that there are no special characters in the title.
            /* The title of the formula is used to get a file name for the SVG. */
            if (!(titleTextBox.Text == ""))
            {
                title = titleTextBox.Text;
                titleTag = @""" title=""" + titleTextBox.Text + "\"";
            }
            /* If no title is given, then a random file name is chosen instead. */
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
                //caption = captionTextBox.Text.Replace("\"", "\\\"");
                captionTag = "<figcaption style=\"text-align:left\">" + caption + @"</figcaption>";
            }
            else
            {
                captionTag = "";
            }

            string styleTag = "";

            //if (noneRadioButton.Checked == true)
            //{

            //}
            if (leftRadioButton.Checked == true)
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

            /* Adds dollar signs, as pandoc needs these to recognized it as LaTeX math. */
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
            if (overrideParserCheckBox.Checked == false)
            {
                saveSVG(inputTextBox.Text, svgFile, title);
            }
           
            imagePath = svgFile;
            Directory.SetCurrentDirectory(pandoc);
            //Console.WriteLine(svgFile);

            /* Pandoc has to be called up indirectly via cmd (Windows command prompt) to avoid encoding errors with certain characters, 
             * which appear if it is called up directly. */
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


            //This is maybe why lines get added
            //math = math.Replace("<p>", "");
            //math = math.Replace("</p>", "");
           
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


            //TODO Should just "<annotation" be checked for instead of also including the "encoding"
            // characteristic
            string annoStart = "<annotation encoding=\"application/x-tex\">";
            string annoEnd = "</annotation>";

            while (mathResult.Contains(annoStart) && mathResult.Contains(annoEnd))
            {
                int start = mathResult.IndexOf(annoStart);
                int end = mathResult.IndexOf(annoEnd) + annoEnd.Length;

                mathResult = mathResult.Replace(mathResult.Substring(start, end - start), "");
            }

            /* MathML does not care about HTML entities, so the greater than (>) and less than (<) 
             * have to be converted to their usual symbols. */
            mathResult = mathResult.Replace("&lt;", "<");
            mathResult = mathResult.Replace("&gt;", ">");
    
            //bool encodeMode = false;
      
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < mathResult.Length; i++)
            {
                string toAdd = "";
                if (mathResult[i] == '>')
                {
                    //encodeMode = true;
                    toAdd = ">";
                }
                else if (mathResult[i] == '<')
                {
                    //encodeMode = false;
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

            /* Pieces together the math in the figure. */
            string formulaToAdd = "";

            formulaToAdd += "\n<figure>";

            string encodedInputForAlt = inputTextBox.Text.Replace("<", "&lt;");
            encodedInputForAlt = encodedInputForAlt.Replace(">", "&gt;");
            //encodedInputForAlt = "";

            // titleTag = @""" title=""" + titleTextBox.Text
            string mathHeader = @"<div" + styleTag + @" role=""math"" class=""math""><math xmlns=""http://www.w3.org/1998/Math/MathML"" altimg=""" + imagePath +  titleTag  + @""">"  + "<mstyle>";
      
            string mathHeaderImpaired = @"<div" + styleTag + @" role=""math"" class=""mathImpaired""><math xmlns=""http://www.w3.org/1998/Math/MathML"" altimg=""" + imagePath + titleTag + @""">"  + "<mstyle scriptsizemultiplier=\"1\" lspace=\"20%\" rspace=\"20%\" mathvariant=\"sans-serif\">";
           
            
            string mathEnd = "</mstyle></math>";


            formulaToAdd += "" + (@"<!--RemoveThis--><img class=""toRemove"" " + titleTag + @"src =""" + imagePath + @""" /><!--RemoveEnd-->");
            
            string divEnd = "</div>";
            //formulaToAdd += divEnd;



            dynamic currentLocation = doc.selection.createRange();
            //r.pasteHTML(mathHeader + mathResult + mathEnd);
            formulaToAdd += mathHeader + mathFinalResult + mathEnd + divEnd;
            formulaToAdd += mathHeaderImpaired + mathFinalResult + mathEnd + divEnd;

            string altTextParagraph = "<p class=\"transparent\">$" + encodedInputForAlt + "$</p>";
            formulaToAdd += altTextParagraph + captionTag + "</figure>\n";

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

        /// <summary>
        /// Converts LaTeX math code to <c>WpfMath.TexFormula</c> which is displayed in the formula view.
        /// </summary>
        /// <param name="input">The LaTeX math formula which will be parsed</param>
        /// <returns>The parsed formula which is then displayed in the formula view.</returns>
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

        /// <summary>
        /// Allows user to explicitly save a SVG of the currently entered math formula, without adding it to the EPUB document. 
        /// This button was removed and the feature deactivated to simplify the layout.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Saves an SVG of the math formula which is used in the WYSIWYG editor.
        /// </summary>
        /// <param name="input">LaTeX math code of the formula.</param>The 
        /// <param name="filePath">Path where the svg will be located.</param>
        /// <param name="title">The title of the math formula.</param>
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

        /// <summary>
        /// Adds a SVG header which has to added as an HTML tag.
        /// </summary>
        /// <param name="svgText">The code of the SVG image.</param>
        /// <returns>The code of the SVG image in an appropriate tags.</returns>
        private string AddSVGHeader(string svgText)
        {

            var builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>")
                .AppendLine("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" >")
                .AppendLine(svgText)
                .AppendLine("</svg>");

            return builder.ToString();
        }



        //private void MathDialogBox_Load(object sender, EventArgs e)
        //{
        //    //this.formulaParser = new WpfMath.TexFormulaParser();

        //    //var testFormula1 = "\\int_0^{\\infty}{x^{2n} e^{-a x^2} dx} = \\frac{2n-1}{2a} \\int_0^{\\infty}{x^{2(n-1)} e^{-a x^2} dx} = \\frac{(2n-1)!!}{2^{n+1}} \\sqrt{\\frac{\\pi}{a^{2n+1}}}";
        //    //var testFormula2 = "\\int_a^b{f(x) dx} = (b - a) \\sum_{n = 1}^{\\infty}  {\\sum_{m = 1}^{2^n  - 1} { ( { - 1} )^{m + 1} } } 2^{ - n} f(a + m ( {b - a}  )2^{-n} )";
        //    //var testFormula3 = @"L = \int_a^b \sqrt[4]{ \left| \sum_{i,j=1}^ng_{ij}\left(\gamma(t)\right) \left[\frac{d}{dt}x^i\circ\gamma(t) \right] \left{\frac{d}{dt}x^j\circ\gamma(t) \right} \right|}dt";
        //    //this.inputTextBox.Text = testFormula3;
        //}

        /// <summary>
        /// Every change in the math input is parsed and immediately shown in the formula view.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Closes the window properly and sets <c>DialogResult.Cancel</c>, which tells the main form that the math formula should not be edited 
        /// and there should not be any changes to it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
            this.Dispose();
        }
    }
}
