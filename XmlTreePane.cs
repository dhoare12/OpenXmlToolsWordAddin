using Microsoft.Office.Interop.Word;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OpenXmlPowerToolsWordAddin
{
    public partial class XmlTreePane : UserControl
    {
        public XmlTreePane()
        {
            InitializeComponent();
        }

        private void btnLoadXmlFile_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml",
                Title = "Select XML Data File"
            };

            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            LoadXmlIntoTreeView(fileDialog.FileName);
        }

        public void LoadXmlIntoTreeView(string xmlPath)
        {
            var root = XElement.Load(xmlPath);

            treeTokens.BeginUpdate();
            treeTokens.Nodes.Clear();

            var rootNode = CreateNodeWithXPath(root, "/" + root.Name.LocalName);
            treeTokens.Nodes.Add(rootNode);

            treeTokens.EndUpdate();
            treeTokens.ExpandAll();
        }

        private TreeNode CreateNodeWithXPath(XElement element, string path)
        {
            var nodeName = element.HasElements 
                ? element.Name.LocalName 
                : element.Name.LocalName + $" ({element.Value.UpTo(30)})";

            var node = new TreeNode(nodeName)
            {
                Tag = path
            };

            var index = 1;
            foreach (var child in element.Elements())
            {
                // If same-named siblings exist, index them
                var siblingPath = path + "/" + child.Name.LocalName;
                if (element.Elements(child.Name).Count() > 1)
                {
                    siblingPath += $"[{index++}]";
                }

                node.Nodes.Add(CreateNodeWithXPath(child, siblingPath));
            }

            return node;
        }

        private void treeTokens_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;

            var xpath = node.Tag.ToString();

            // .NET xpath begins with /Root, Eric White Expects ./
            xpath = "./" + xpath.Substring(6);

            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            cc.Range.Text = $"<Content Select=\"{xpath}\" />";
        }

        private void treeTokens_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var node = e.Node;
                var xpath = node.Tag.ToString();
                // .NET xpath begins with /Root, Eric White Expects ./
                xpath = "./" + xpath.Substring(6);
                contextMenu.Tag = xpath;
                contextMenu.Show(treeTokens, e.Location);
            }
        }

        private void insertContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            cc.Range.Text = $"<Content Select=\"{contextMenu.Tag}\" />";
        }

        private void insertRepeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            cc.Range.Text = $"<Repeat Select=\"{contextMenu.Tag}\" />";
        }

        private void insertTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var cc = doc.ContentControls.Add(WdContentControlType.wdContentControlText);
            cc.Range.Text = $"<Table Select=\"{contextMenu.Tag}\" />";
        }
    }

    public static class StringExtensions
    {
        public static string UpTo(this string str, int maxChars)
        {
            return str.Length > maxChars ? str.Substring(0, maxChars) : str;
        }
    }
}
