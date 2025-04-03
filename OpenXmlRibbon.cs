using Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.VisualBasic;
using OpenXmlPowerTools;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;

namespace OpenXmlPowerToolsWordAddin
{
    public partial class OpenXmlRibbon
    {
        private string _xmlPath;

        private void OpenXmlRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnInsertTag_Click(object sender, RibbonControlEventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            var xpath = PromptUserForXPath("Enter the XPath for the data you'd like to be displayed");
            cc.Range.Text = $"<Content Select=\"{xpath}\" />";
        }

        private static string PromptUserForXPath(string prompt)
        {
            const string title = "Insert OpenXml content";

            var input = Interaction.InputBox(prompt, title);

            return string.IsNullOrWhiteSpace(input) ? null : input.Trim();
        }

        private void btnTestXML_Click(object sender, RibbonControlEventArgs e)
        {
            // Ask user to pick XML file
            var ofd = new OpenFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml",
                Title = "Select XML Data File"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            btnTestPreviousXml.Visible = true;

            _xmlPath = ofd.FileName;

            TestXmlFile();
        }

        private void TestXmlFile()
        {
            // Save current Word doc to a temp path
            var tempTemplatePath = Path.GetTempFileName() + ".docx";
            var doc = Globals.ThisAddIn.Application.ActiveDocument;

            doc.Save();
            File.Copy(doc.FullName, tempTemplatePath);

            // Load the XML
            var data = XElement.Load(_xmlPath);

            var templateStream = new MemoryStream();
            using (var fileStream = new FileStream(tempTemplatePath, FileMode.Open, FileAccess.Read))
            {
                fileStream.CopyTo(templateStream);
            }

            var resultPath = Path.Combine(Path.GetTempPath(), "Generated_" + Path.GetFileName(tempTemplatePath));

            // Run DocumentAssembler
            var template = new WmlDocument("Test Document", templateStream);

            var output = DocumentAssembler.AssembleDocument(template, data, out var templateError);
            if (templateError)
            {
                MessageBox.Show("At least one error occurred while assembling the document");
            }
            output.SaveAs(resultPath);

            // Open in Word
            var wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Open(resultPath);
        }

        private void btnTestPreviousXml_Click(object sender, RibbonControlEventArgs e)
        {
            TestXmlFile();
        }

        private void btnInsertTableSelect_Click(object sender, RibbonControlEventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            var xpath = PromptUserForXPath("Enter the XPath for the data you'd like to loop through in the following table");
            cc.Range.Text = $"<Table Select=\"{xpath}\" />";
        }

        private void btnInsertTableCell_Click(object sender, RibbonControlEventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            var xpath = PromptUserForXPath("Enter the XPath for the data within the current table to display in a cell");
            cc.Range.Text = xpath;
        }

        private void btnInsertRepeat_Click(object sender, RibbonControlEventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            var xpath = PromptUserForXPath("Enter the XPath for the data you'd like to loop through");
            cc.Range.Text = $"<Repeat Select=\"{xpath}\" />";
        }

        private void btnInsertEndRepeat_Click(object sender, RibbonControlEventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            cc.Range.Text = "<EndRepeat />";
        }

        private void btnInsertConditional_Click(object sender, RibbonControlEventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            var xpath = PromptUserForXPath("Enter the XPath for the true/false condition we should be conditionally rendering on");
            cc.Range.Text = $"<Conditional Select=\"{xpath}\" />";

        }

        private void btnInsertEndConditional_Click(object sender, RibbonControlEventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            cc.Range.Text = "<EndConditional />";
        }

        private void btnShowTokensPane_Click(object sender, RibbonControlEventArgs e)
        {
            var pane = Globals.ThisAddIn.CustomTaskPanes
                .FirstOrDefault(p => p.Control is XmlTreePane);

            if (pane != null)
            {
                pane.Visible = !pane.Visible;
            }
        }
    }
}
