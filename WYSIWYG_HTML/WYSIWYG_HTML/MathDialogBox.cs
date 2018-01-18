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


using mshtml;

namespace WYSIWYG_HTML
{
    public partial class MathDialogBox : Form
    {
        WpfMath.Controls.FormulaControl formula = new WpfMath.Controls.FormulaControl();
        IHTMLDocument2 doc;
        private WpfMath.TexFormulaParser formulaParser;



        string initialPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();

        

        public MathDialogBox(IHTMLDocument2 mainWindowDoc)
        {
            InitializeComponent();
            doc = mainWindowDoc;

            host.Dock = DockStyle.Fill;
            host.Child = formula;

        }



        private void insertFormulaButton_Click(object sender, EventArgs e)
        {

            string pandoc = Path.Combine(initialPath, "pandoc-2.1");
            string currentDic = Directory.GetCurrentDirectory();

            Directory.SetCurrentDirectory(pandoc);

            if (inputTextBox.Text == "")
            {
                return;
            }

            System.IO.File.WriteAllText(Path.Combine(pandoc, "accEpub.txt"), "$" + inputTextBox.Text + "$");



            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //FileName = "pandoc", //Path.Combine(pandoc, "pandoc"),
                    FileName = @"c:\windows\system32\cmd.exe",
                    Arguments = @"/c pandoc --mathml accEpub.txt> formulaResult.txt",
                    //UseShellExecute = false,
                    //RedirectStandardOutput = false,
                    CreateNoWindow = true
                }
            };
            
            string math = "";
            proc.Start();
            proc.WaitForExit();
            //while (!proc.StandardOutput.EndOfStream)
            //{
            //    math += proc.StandardOutput.ReadLine();
            //    // do something with line
            //}
            math = System.IO.File.ReadAllText("formulaResult.txt");
            //math += proc.StandardOutput.ReadToEnd();
            
            //Console.WriteLine(proc.StartInfo.FileName.ToString());
            //Console.WriteLine(proc.StartInfo.Arguments.ToString());
            System.IO.File.WriteAllText(Path.Combine(pandoc, "result.txt"), math);
            string split = "<mrow>";
            string split2 = "</mrow>";
            string mathResult = math.Substring(math.IndexOf(split));
            //Console.WriteLine(math);
            //Console.WriteLine(mathResult.LastIndexOf(split2));
            Console.WriteLine(mathResult);
            mathResult = mathResult.Substring(0, mathResult.LastIndexOf(split2) + split2.Length);

            string mathHeader = @"
            <div role = ""math"" class=""math"">
                <math xmlns=""http://www.w3.org/1998/Math/MathML"" title="""" alttext=""" + inputTextBox.Text + @""">";
            string mathEnd = @"
                </math>
            </div>";

            //dynamic r = doc.selection.createRange();
            //r.pasteHTML(mathHeader + mathResult + mathEnd);
            doc.body.innerHTML += mathHeader + mathResult + mathEnd;

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
                formula = this.formulaParser.Parse(input);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred while parsing the given input:" + Environment.NewLine +
                    //Environment.NewLine + ex.Message, "WPF-Math Example", MessageBoxButton.OK, MessageBoxImage.Error);
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
            this.formula.Formula = inputTextBox.Text;

        }
    }
}
