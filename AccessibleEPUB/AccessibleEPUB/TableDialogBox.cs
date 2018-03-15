using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Globalization;
using System.Threading;


using mshtml;

namespace AccessibleEPUB
{
    public partial class TableDialogBox : Form
    {
        private List<List<int>> table;
        private List<List<TextBox>> textBoxTable;
        DataGridView dgv = new DataGridView();
        IHTMLDocument2 doc;


        public TableDialogBox(IHTMLDocument2 mainWindowDoc)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());

            InitializeComponent();
            doc = mainWindowDoc;
        }



        private DataGridView CopyDataGridView(DataGridView dgv_org)
        {
            DataGridView dgv_copy = new DataGridView();
            try
            {
                if (dgv_copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgv_org.Columns)
                    {
                        dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_org.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgv_org.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_org.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dgv_copy.Rows.Add(row);
                }
                dgv_copy.AllowUserToAddRows = false;
                dgv_copy.Refresh();

            }
            catch (Exception ex)
            {
                //cf.ShowExceptionErrorMsg("Copy DataGridViw", ex);
            }
            return dgv_copy;
        }

        private void adjustTable()
        {

            //table.Capacity = int.Parse(rowTextBox.Text);
            //foreach (List<int> column in table)
            //{
            //    column.Capacity = int.Parse(columnTextBox.Text);

            //}
            tablePanel.Controls.Remove(dgv);
            tablePanel.Controls.Clear();
            dgv = CopyDataGridView(dgv);
            DataGridView dgv2 = CopyDataGridView(dgv);
            dgv.Dispose();

            dgv = CopyDataGridView(dgv2);



            //string[] r1 = new string[int.Parse(columnTextBox.Text)];

            dgv.RowCount = int.Parse(rowTextBox.Text);
            dgv.ColumnCount = int.Parse(columnTextBox.Text);
            dgv.Size = new System.Drawing.Size(0, 0);


            dgv.AutoSize = true;
            dgv.Location = new System.Drawing.Point(0, 0);
            dgv.BackgroundColor = SystemColors.Control;
            tablePanel.Controls.Add(dgv);


             
            //int x = 50;
            //int y = 80;

            //for (int col = 0; col < int.Parse(columnTextBox.Text); col++)
            //{
            //    Label cl = new Label();
            //    cl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //    cl.AutoSize = true;
            //    cl.Location = new System.Drawing.Point(x, 40);
            //    int clNumber = col + 1;
            //    cl.Text = clNumber.ToString();
            //    tablePanel.Controls.Add(cl);
            //    x += 80;
            //}

            //x = 50;

           

            ////for (int row = 0; row < 2; row++)
            //for (int row = 0; row < int.Parse(rowTextBox.Text); row++)
            //{
            //    //for (int col = 0; col < 2; col++)
            //    for (int col = 0; col < int.Parse(columnTextBox.Text); col++)
            //    {
            //        Label rl = new Label();
            //        rl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        rl.AutoSize = true;
            //        rl.Location = new System.Drawing.Point(0, y);
            //        int rlNumber = row + 1;
            //        rl.Text = rlNumber.ToString();
            //        tablePanel.Controls.Add(rl);
     

            //        TextBox tb = new TextBox();
            //        tb.Location = new System.Drawing.Point(x, y);
            //        tb.Size = new System.Drawing.Size(80, 40);
            //        tablePanel.Controls.Add(tb);
            //        x += 80;
                    
            //    }
                
            //    y += 40;
            //    x = 50;
            //}
        }

        private void adjustTableButton_Click(object sender, EventArgs e)
        {
            adjustTable();
        }

        private void insertTableButton_Click(object sender, EventArgs e)
        {
     
            string tableHTML = @"<TABLE title=""" + @titleTextBox.Text + @"""><TBODY>";

            for (int col = 0; col < dgv.ColumnCount; col++)
            {
                tableHTML += "\t<th>" + dgv[col, 0].Value + "</th>";
            }
            tableHTML += "</tr>";


            for (int row = 1; row < dgv.RowCount; row++)
            {
            
                tableHTML += "<tr>";

                tableHTML += "\t<th>" + dgv[0, row].Value + "</th>";

                for (int col = 1; col < dgv.ColumnCount; col++)
                {


                    tableHTML += "\t<td>" + dgv[col, row].Value + "</td>";
                }
                tableHTML += "</tr>";
            }

            //for (int row = 0; row < dgv.RowCount; row++)
            //{
            //    tableHTML += @"<TR>";
            //    for (int col = 0; col < dgv.ColumnCount; col++)
            //    {
            //        tableHTML += @"<TD>" + @dgv[col, row].Value.ToString() + @"</TD>";
            //    }
            //    tableHTML += @"</TR>";
            //}

            tableHTML += @"</TBODY> </TABLE>" + "\n";
            Console.WriteLine(tableHTML);
            dynamic currentLocation = doc.selection.createRange();
            currentLocation.pasteHTML(tableHTML);

            //doc.body.innerHTML += WebUtility.HtmlDecode(tableHTML);

            this.Hide();
            this.Dispose();


            
            //doc.body.innerText = tableHTML;

            /*
<table title="Table with information about the five rhino types">
<tbody><tr>
    <th>Rhino species</th>
      <th>White</th>
      <th>Black</th>
      <th>Indian</th>
      <th>Sumatran</th>
      <th>Javan</th>
    </tr>
    <tr>
      <th>Population</th>
      <td>20000</td>
      <td>5000</td>
      <td>3500</td>
      <td>100</td>
      <td>60</td>
    </tr>
    <tr>
      <th>Habitat</th>
      <td>Southern Africa</td>
      <td>Southern Africa</td>
      <td>India and Nepal</td>
      <td>Indonesia</td>
      <td>Indonesia</td>
    </tr>
    <tr>
      <th>Conservation Status</th>
      <td>Not threatened</td>
      <td>Critically endangered</td>
      <td>Vulnerable</td>
      <td>Critically endangered</td>
      <td>Critically endangered</td>
    </tr>
    <tr>
      <th>Number of horns</th>
      <td>2</td>
      <td>2</td>
      <td>1</td>
      <td>2</td>
      <td>1</td>
    </tr>
    <tr>
      <th>Weight (kg)</th>
      <td>1800-2700</td>
      <td>800-1350</td>
      <td>1800-2500</td>
      <td>600-950</td>
      <td>900-2300</td>
    </tr>
    <tr>
      <th>Height (m)</th>
      <td>1.5-1.8</td>
      <td>1.4-1.7</td>
      <td>1.75-2</td>
      <td>1.0-1.5</td>
      <td>1.5-1.7</td>
    </tr>
</tbody>
</table>
*/          
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void TableDialogBox_Shown(object sender, EventArgs e)
        {
            adjustTable();
        }

        private void rowTextBox_Leave(object sender, EventArgs e)
        {
            adjustTable();
        }

        private void columnTextBox_Leave(object sender, EventArgs e)
        {
            adjustTable();
        }
    }
}
