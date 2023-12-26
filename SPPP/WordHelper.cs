using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace SPPP
{
    internal class WordHelper
    {
        public bool WordTemplate(string date, string model, string durationOfTheTests, string numberOfTestCyclec, string location, string typeOfStand)
        {
            Word.Document doc = null;
            if (typeOfStand.Trim().Equals("0") || typeOfStand.Trim().Equals("2"))
            {
                string patch = System.Windows.Forms.Application.StartupPath.ToString() + "\\ШаблонСРПП.docx";
                try
                {
                    Word._Application app = new Word.Application();
                    doc = app.Documents.Open(patch);
                    doc.Activate();
                    doc.Bookmarks["numberOfTestCyclec"].Range.Text = numberOfTestCyclec;
                    doc.Bookmarks["durationOfTheTests"].Range.Text = durationOfTheTests;
                    doc.Bookmarks["model"].Range.Text = model;
                    doc.Bookmarks["dateTime"].Range.Text = date;

                    doc.SaveAs(location);
                    doc.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return false;
        }
    }
}
