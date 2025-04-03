namespace OpenXmlPowerToolsWordAddin
{
    partial class OpenXmlRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public OpenXmlRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.menu1 = this.Factory.CreateRibbonMenu();
            this.btnInsertTableSelect = this.Factory.CreateRibbonButton();
            this.btnTestPreviousXml = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.btnInsertRepeat = this.Factory.CreateRibbonButton();
            this.btnInsertTableCell = this.Factory.CreateRibbonButton();
            this.btnInsertEndRepeat = this.Factory.CreateRibbonButton();
            this.btnInsertConditional = this.Factory.CreateRibbonButton();
            this.btnInsertEndConditional = this.Factory.CreateRibbonButton();
            this.btnInsertContent = this.Factory.CreateRibbonButton();
            this.btnTestXML = this.Factory.CreateRibbonButton();
            this.btnShowTokensPane = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnInsertContent);
            this.group1.Items.Add(this.menu1);
            this.group1.Items.Add(this.separator1);
            this.group1.Items.Add(this.btnTestXML);
            this.group1.Items.Add(this.btnTestPreviousXml);
            this.group1.Items.Add(this.btnShowTokensPane);
            this.group1.Label = "Eric White";
            this.group1.Name = "group1";
            // 
            // menu1
            // 
            this.menu1.Items.Add(this.btnInsertTableSelect);
            this.menu1.Items.Add(this.btnInsertTableCell);
            this.menu1.Items.Add(this.btnInsertRepeat);
            this.menu1.Items.Add(this.btnInsertEndRepeat);
            this.menu1.Items.Add(this.btnInsertConditional);
            this.menu1.Items.Add(this.btnInsertEndConditional);
            this.menu1.Label = "Insert other";
            this.menu1.Name = "menu1";
            // 
            // btnInsertTableSelect
            // 
            this.btnInsertTableSelect.Label = "Table";
            this.btnInsertTableSelect.Name = "btnInsertTableSelect";
            this.btnInsertTableSelect.ShowImage = true;
            this.btnInsertTableSelect.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnInsertTableSelect_Click);
            // 
            // btnTestPreviousXml
            // 
            this.btnTestPreviousXml.Label = "Retest last file";
            this.btnTestPreviousXml.Name = "btnTestPreviousXml";
            this.btnTestPreviousXml.Visible = false;
            this.btnTestPreviousXml.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnTestPreviousXml_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // btnInsertRepeat
            // 
            this.btnInsertRepeat.Label = "Repeat";
            this.btnInsertRepeat.Name = "btnInsertRepeat";
            this.btnInsertRepeat.ShowImage = true;
            this.btnInsertRepeat.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnInsertRepeat_Click);
            // 
            // btnInsertTableCell
            // 
            this.btnInsertTableCell.Label = "Table Cell";
            this.btnInsertTableCell.Name = "btnInsertTableCell";
            this.btnInsertTableCell.ShowImage = true;
            this.btnInsertTableCell.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnInsertTableCell_Click);
            // 
            // btnInsertEndRepeat
            // 
            this.btnInsertEndRepeat.Label = "End Repeat";
            this.btnInsertEndRepeat.Name = "btnInsertEndRepeat";
            this.btnInsertEndRepeat.ShowImage = true;
            this.btnInsertEndRepeat.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnInsertEndRepeat_Click);
            // 
            // btnInsertConditional
            // 
            this.btnInsertConditional.Label = "Conditional";
            this.btnInsertConditional.Name = "btnInsertConditional";
            this.btnInsertConditional.ShowImage = true;
            this.btnInsertConditional.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnInsertConditional_Click);
            // 
            // btnInsertEndConditional
            // 
            this.btnInsertEndConditional.Label = "End Conditional";
            this.btnInsertEndConditional.Name = "btnInsertEndConditional";
            this.btnInsertEndConditional.ShowImage = true;
            this.btnInsertEndConditional.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnInsertEndConditional_Click);
            // 
            // btnInsertContent
            // 
            this.btnInsertContent.Image = global::OpenXmlPowerToolsWordAddin.Properties.Resources.variable;
            this.btnInsertContent.Label = "Insert Content";
            this.btnInsertContent.Name = "btnInsertContent";
            this.btnInsertContent.ShowImage = true;
            this.btnInsertContent.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnInsertTag_Click);
            // 
            // btnTestXML
            // 
            this.btnTestXML.Image = global::OpenXmlPowerToolsWordAddin.Properties.Resources.fileCode;
            this.btnTestXML.Label = "Test with XML";
            this.btnTestXML.Name = "btnTestXML";
            this.btnTestXML.ShowImage = true;
            this.btnTestXML.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnTestXML_Click);
            // 
            // btnShowTokensPane
            // 
            this.btnShowTokensPane.Label = "Toggle Tokens Pane";
            this.btnShowTokensPane.Name = "btnShowTokensPane";
            this.btnShowTokensPane.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnShowTokensPane_Click);
            // 
            // OpenXmlRibbon
            // 
            this.Name = "OpenXmlRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.OpenXmlRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertContent;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTestXML;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertTableSelect;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTestPreviousXml;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertRepeat;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertTableCell;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertEndRepeat;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertConditional;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertEndConditional;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnShowTokensPane;
    }

    partial class ThisRibbonCollection
    {
        internal OpenXmlRibbon OpenXmlRibbon
        {
            get { return this.GetRibbon<OpenXmlRibbon>(); }
        }
    }
}
