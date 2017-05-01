using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Core;

using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace GenerateSSTCase
{
    public partial class GenerateSSTCase : Form
    {
        private bool bIsSelectedViewpointFile = false;
        private bool bIsSelectedSSTFile = false;
        public GenerateSSTCase()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool isExistSheet(string sheetName, Excel.Sheets wSheets)
        {
            foreach (Excel.Worksheet wSheet in wSheets)
            {
                if (sheetName.Equals(wSheet.Name))
                {
                    return true;
                }
            }
            return false;
        }

        private void copyTestCaseFromTemplate(string templateFilePath, string viewpointFilePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBookTemplate = null;
            Excel.Worksheet xlWorkSheetTemplate = null;

            Excel.Workbook xlWorkBookViewpoint = null;
            Excel.Worksheet xlWorkSheetTestCase = null;
            try
            {
                xlWorkBookTemplate = xlApp.Workbooks.Open(templateFilePath);
                string templateSheet = ConfigurationManager.AppSettings["Template_SheetName"];
                if (!this.isExistSheet(templateSheet, xlWorkBookTemplate.Worksheets))
                {
                    throw new Exception("Sheet \"" + templateSheet + "\" does not exist.");
                }

                xlWorkBookViewpoint = xlApp.Workbooks.Open(viewpointFilePath);
                string testCaseSheet = ConfigurationManager.AppSettings["TestCase_SheetName"];
                if (this.isExistSheet(testCaseSheet, xlWorkBookViewpoint.Worksheets))
                {
                    throw new Exception("Sheet \"" + testCaseSheet + "\" areadly existed.");
                }

                xlWorkSheetTemplate = xlWorkBookTemplate.Worksheets[templateSheet];

                // Copy sheet
                xlWorkSheetTemplate.Copy(xlWorkBookViewpoint.Worksheets[2]);

                // Fill data to new sheet
                xlWorkSheetTestCase = xlWorkBookViewpoint.Worksheets[2];

                xlWorkSheetTestCase.Name = testCaseSheet;

                // Copy all data

                xlWorkBookViewpoint.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((xlWorkBookTemplate == null) && (xlWorkBookViewpoint == null))
                {
                    xlApp.Quit();
                }
                else
                {
                    if (xlWorkBookTemplate != null)
                    {
                        xlWorkBookTemplate.Close();
                    }

                    if (xlWorkBookViewpoint != null)
                    {
                        xlWorkBookViewpoint.Close();
                    }

                    // Kill process of tmp file
                    int tmpPsId;
                    GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), out tmpPsId);
                    Process psTmp = Process.GetProcessById(Convert.ToInt16(tmpPsId));
                    if (psTmp != null)
                    {
                        psTmp.Kill();
                    }
                }
            }
        }

        private void getAllViewpoint(string filePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = null;
            //Excel.Worksheet xlDicSheet;
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                string excelColumn = ConfigurationManager.AppSettings["ExcelColumn"];
                string excelRow = ConfigurationManager.AppSettings["ExcelRow"];
                string[] strDicName = ConfigurationManager.AppSettings["Dic"].Split(',');
                xlWorkBook = xlApp.Workbooks.Open(filePath);
                //xlDicSheet = xlWorkBook.Worksheets["Dic"];

                //Dictionary<string, string> dicTranslateStatus = null;

                //dic = this.findTranslate(xlDicSheet, excelColumn, excelRow, dic, out dicTranslateStatus);

                foreach (Excel.Worksheet wSheet in xlWorkBook.Worksheets)
                {
                    if ("Dic".Equals(wSheet.Name) || "Template".Equals(wSheet.Name) || strDicName.Any(items => items.Equals(wSheet.Name)))
                    {
                        continue;
                    }
                    //this.writeAToAllSheet(xlWorkBook, dic, dicTranslateStatus, wSheet.Name, excelColumn, int.Parse(excelRow));
                }
                MessageBox.Show("Replace message to all sheet is success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when get Dictionary sheet" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (xlWorkBook != null)
                {
                    xlWorkBook.Close();

                    // Kill process of tmp file
                    int tmpPsId;
                    GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), out tmpPsId);
                    Process psTmp = Process.GetProcessById(Convert.ToInt16(tmpPsId));
                    if (psTmp != null)
                    {
                        psTmp.Kill();
                    }
                }
                else
                {
                    xlApp.Quit();
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.btnBrowseSSTFile.Enabled = false;
            try
            {
                // Copy sheet Template to viewpoint file
                copyTestCaseFromTemplate(this.txtSSTFilePath.Text, this.txtViewPointFilePath.Text);

                // Get all viewpoint
                //getAllViewpoint(this.txtViewPointFilePath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Template File invalid: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.btnBrowseSSTFile.Enabled = true;
        }

        private void btnBrowseViewpointFile_Click(object sender, EventArgs e)
        {
            openFileDialogViewPoint.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (openFileDialogViewPoint.ShowDialog() == DialogResult.OK)
            {
                txtViewPointFilePath.Text = openFileDialogViewPoint.FileName;
                bIsSelectedViewpointFile = true;
                btnGenerate.Enabled = bIsSelectedSSTFile;
                return;
            }

            txtViewPointFilePath.Text = "";
            bIsSelectedViewpointFile = false;

            btnGenerate.Enabled = false;
        }

        private void btnBrowseSSTFile_Click(object sender, EventArgs e)
        {
            openFileDialogSST.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (openFileDialogSST.ShowDialog() == DialogResult.OK)
            {
                txtSSTFilePath.Text = openFileDialogSST.FileName;
                bIsSelectedSSTFile = true;
                btnGenerate.Enabled = bIsSelectedViewpointFile;
                return;
            }

            txtSSTFilePath.Text = "";
            bIsSelectedSSTFile = false;

            btnGenerate.Enabled = false;
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
    }
}
