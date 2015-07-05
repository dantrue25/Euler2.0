namespace Euler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripGraphTools = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSelectMoveVertex = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddVertex = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddEdge = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteVertex = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteEdge = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectArea = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddEdgeDirected = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBoxBasic = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBoxWolframAlpha = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBoxMatlab = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richTextBoxPower = new System.Windows.Forms.RichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBoxAdjPower = new System.Windows.Forms.ComboBox();
            this.labelAdjacencyPower = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.richTextBoxEigenVector = new System.Windows.Forms.RichTextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.richTextBoxEigenValue = new System.Windows.Forms.RichTextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelBottomLeftHint = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripRightClickPictureBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyGraphImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyGraphImageSubsectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStripGraphTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripRightClickPictureBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.analysisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1065, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // toolStripGraphTools
            // 
            this.toolStripGraphTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSelectMoveVertex,
            this.toolStripButtonAddVertex,
            this.toolStripButtonAddEdge,
            this.toolStripButtonDeleteVertex,
            this.toolStripButtonDeleteEdge,
            this.toolStripButtonSelectArea,
            this.toolStripButtonAddEdgeDirected});
            this.toolStripGraphTools.Location = new System.Drawing.Point(0, 24);
            this.toolStripGraphTools.Name = "toolStripGraphTools";
            this.toolStripGraphTools.Size = new System.Drawing.Size(1065, 25);
            this.toolStripGraphTools.TabIndex = 2;
            this.toolStripGraphTools.Text = "toolStrip1";
            // 
            // toolStripButtonSelectMoveVertex
            // 
            this.toolStripButtonSelectMoveVertex.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelectMoveVertex.Image")));
            this.toolStripButtonSelectMoveVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectMoveVertex.Name = "toolStripButtonSelectMoveVertex";
            this.toolStripButtonSelectMoveVertex.Size = new System.Drawing.Size(93, 22);
            this.toolStripButtonSelectMoveVertex.Text = "Select/Move";
            this.toolStripButtonSelectMoveVertex.Click += new System.EventHandler(this.toolStripButtonSelect_Click);
            // 
            // toolStripButtonAddVertex
            // 
            this.toolStripButtonAddVertex.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddVertex.Image")));
            this.toolStripButtonAddVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddVertex.Name = "toolStripButtonAddVertex";
            this.toolStripButtonAddVertex.Size = new System.Drawing.Size(84, 22);
            this.toolStripButtonAddVertex.Text = "Add Vertex";
            this.toolStripButtonAddVertex.Click += new System.EventHandler(this.toolStripButtonAddVertex_Click);
            // 
            // toolStripButtonAddEdge
            // 
            this.toolStripButtonAddEdge.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddEdge.Image")));
            this.toolStripButtonAddEdge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddEdge.Name = "toolStripButtonAddEdge";
            this.toolStripButtonAddEdge.Size = new System.Drawing.Size(78, 22);
            this.toolStripButtonAddEdge.Text = "Add Edge";
            this.toolStripButtonAddEdge.Click += new System.EventHandler(this.toolStripButtonAddEdge_Click);
            // 
            // toolStripButtonDeleteVertex
            // 
            this.toolStripButtonDeleteVertex.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteVertex.Image")));
            this.toolStripButtonDeleteVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteVertex.Name = "toolStripButtonDeleteVertex";
            this.toolStripButtonDeleteVertex.Size = new System.Drawing.Size(95, 22);
            this.toolStripButtonDeleteVertex.Text = "Delete Vertex";
            this.toolStripButtonDeleteVertex.Click += new System.EventHandler(this.toolStripButtonDeleteVertex_Click);
            // 
            // toolStripButtonDeleteEdge
            // 
            this.toolStripButtonDeleteEdge.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteEdge.Image")));
            this.toolStripButtonDeleteEdge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteEdge.Name = "toolStripButtonDeleteEdge";
            this.toolStripButtonDeleteEdge.Size = new System.Drawing.Size(89, 22);
            this.toolStripButtonDeleteEdge.Text = "Delete Edge";
            this.toolStripButtonDeleteEdge.Click += new System.EventHandler(this.toolStripButtonDeleteEdge_Click);
            // 
            // toolStripButtonSelectArea
            // 
            this.toolStripButtonSelectArea.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelectArea.Image")));
            this.toolStripButtonSelectArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectArea.Name = "toolStripButtonSelectArea";
            this.toolStripButtonSelectArea.Size = new System.Drawing.Size(85, 22);
            this.toolStripButtonSelectArea.Text = "Select Area";
            this.toolStripButtonSelectArea.Click += new System.EventHandler(this.toolStripButtonSelectArea_Click);
            // 
            // toolStripButtonAddEdgeDirected
            // 
            this.toolStripButtonAddEdgeDirected.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddEdgeDirected.Image")));
            this.toolStripButtonAddEdgeDirected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddEdgeDirected.Name = "toolStripButtonAddEdgeDirected";
            this.toolStripButtonAddEdgeDirected.Size = new System.Drawing.Size(133, 22);
            this.toolStripButtonAddEdgeDirected.Text = "Add Edge (Directed)";
            this.toolStripButtonAddEdgeDirected.Click += new System.EventHandler(this.toolStripButtonAddEdgeDirected_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1065, 615);
            this.splitContainer1.SplitterDistance = 749;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(15000, 15000);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(745, 611);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.propertyGrid1);
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(312, 615);
            this.splitContainer2.SplitterDistance = 354;
            this.splitContainer2.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 25);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(308, 325);
            this.propertyGrid1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(308, 25);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 230);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(308, 230);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBoxBasic);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(300, 204);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBoxBasic
            // 
            this.richTextBoxBasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxBasic.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxBasic.Name = "richTextBoxBasic";
            this.richTextBoxBasic.Size = new System.Drawing.Size(294, 198);
            this.richTextBoxBasic.TabIndex = 0;
            this.richTextBoxBasic.Text = "";
            this.richTextBoxBasic.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBoxWolframAlpha);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(296, 203);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "WolframAlpha";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBoxWolframAlpha
            // 
            this.richTextBoxWolframAlpha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxWolframAlpha.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxWolframAlpha.Name = "richTextBoxWolframAlpha";
            this.richTextBoxWolframAlpha.Size = new System.Drawing.Size(290, 197);
            this.richTextBoxWolframAlpha.TabIndex = 0;
            this.richTextBoxWolframAlpha.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBoxMatlab);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(300, 204);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Matlab";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBoxMatlab
            // 
            this.richTextBoxMatlab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMatlab.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxMatlab.Name = "richTextBoxMatlab";
            this.richTextBoxMatlab.Size = new System.Drawing.Size(294, 198);
            this.richTextBoxMatlab.TabIndex = 0;
            this.richTextBoxMatlab.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(300, 204);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Power";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.richTextBoxPower);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(294, 198);
            this.panel4.TabIndex = 1;
            // 
            // richTextBoxPower
            // 
            this.richTextBoxPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxPower.Location = new System.Drawing.Point(0, 28);
            this.richTextBoxPower.Name = "richTextBoxPower";
            this.richTextBoxPower.Size = new System.Drawing.Size(294, 170);
            this.richTextBoxPower.TabIndex = 0;
            this.richTextBoxPower.Text = "";
            this.richTextBoxPower.WordWrap = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBoxAdjPower);
            this.panel5.Controls.Add(this.labelAdjacencyPower);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(294, 28);
            this.panel5.TabIndex = 1;
            // 
            // comboBoxAdjPower
            // 
            this.comboBoxAdjPower.FormattingEnabled = true;
            this.comboBoxAdjPower.Items.AddRange(new object[] {
            "\"1\"",
            "\"2\"",
            "\"3\"",
            "\"4\"",
            "\"5\"",
            "\"6\"",
            "\"7\"",
            "\"8\"",
            "\"9\"",
            "\"10\"",
            "\"11\"",
            "\"12\"",
            "\"13\"",
            "\"14\"",
            "\"15\"",
            "\"16\"",
            "\"17\"",
            "\"18\"",
            "\"19\"",
            "\"20\""});
            this.comboBoxAdjPower.Location = new System.Drawing.Point(66, 3);
            this.comboBoxAdjPower.Name = "comboBoxAdjPower";
            this.comboBoxAdjPower.Size = new System.Drawing.Size(225, 21);
            this.comboBoxAdjPower.TabIndex = 1;
            this.comboBoxAdjPower.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelAdjacencyPower
            // 
            this.labelAdjacencyPower.AutoSize = true;
            this.labelAdjacencyPower.Location = new System.Drawing.Point(5, 6);
            this.labelAdjacencyPower.Name = "labelAdjacencyPower";
            this.labelAdjacencyPower.Size = new System.Drawing.Size(55, 13);
            this.labelAdjacencyPower.TabIndex = 0;
            this.labelAdjacencyPower.Text = "Exponent:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.richTextBoxEigenVector);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(300, 204);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Eigen Vector ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // richTextBoxEigenVector
            // 
            this.richTextBoxEigenVector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEigenVector.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxEigenVector.Name = "richTextBoxEigenVector";
            this.richTextBoxEigenVector.Size = new System.Drawing.Size(294, 198);
            this.richTextBoxEigenVector.TabIndex = 0;
            this.richTextBoxEigenVector.Text = "";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.richTextBoxEigenValue);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(300, 204);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Eigen Value";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // richTextBoxEigenValue
            // 
            this.richTextBoxEigenValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEigenValue.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxEigenValue.Name = "richTextBoxEigenValue";
            this.richTextBoxEigenValue.Size = new System.Drawing.Size(294, 198);
            this.richTextBoxEigenValue.TabIndex = 0;
            this.richTextBoxEigenValue.Text = "";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.pictureBox2);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(300, 204);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(294, 198);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 23);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adjacency Matrix";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelBottomLeftHint,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 664);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1065, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelBottomLeftHint
            // 
            this.toolStripStatusLabelBottomLeftHint.Name = "toolStripStatusLabelBottomLeftHint";
            this.toolStripStatusLabelBottomLeftHint.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelBottomLeftHint.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(814, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 50000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 200;
            // 
            // contextMenuStripRightClickPictureBox
            // 
            this.contextMenuStripRightClickPictureBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyGraphImageToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.copyGraphImageSubsectionToolStripMenuItem});
            this.contextMenuStripRightClickPictureBox.Name = "contextMenuStrip1";
            this.contextMenuStripRightClickPictureBox.Size = new System.Drawing.Size(235, 70);
            // 
            // copyGraphImageToolStripMenuItem
            // 
            this.copyGraphImageToolStripMenuItem.Name = "copyGraphImageToolStripMenuItem";
            this.copyGraphImageToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.copyGraphImageToolStripMenuItem.Text = "Copy Graph Image";
            this.copyGraphImageToolStripMenuItem.Click += new System.EventHandler(this.copyGraphImageToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // copyGraphImageSubsectionToolStripMenuItem
            // 
            this.copyGraphImageSubsectionToolStripMenuItem.Name = "copyGraphImageSubsectionToolStripMenuItem";
            this.copyGraphImageSubsectionToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.copyGraphImageSubsectionToolStripMenuItem.Text = "Copy Graph Image Subsection";
            this.copyGraphImageSubsectionToolStripMenuItem.Click += new System.EventHandler(this.copyGraphImageSubsectionToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 686);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripGraphTools);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Euler 2.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripGraphTools.ResumeLayout(false);
            this.toolStripGraphTools.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripRightClickPictureBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripGraphTools;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectMoveVertex;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddVertex;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddEdge;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteVertex;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteEdge;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBoxBasic;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBoxWolframAlpha;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBottomLeftHint;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBoxMatlab;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox richTextBoxPower;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox richTextBoxEigenVector;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRightClickPictureBox;
        private System.Windows.Forms.ToolStripMenuItem copyGraphImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectArea;
        private System.Windows.Forms.ToolStripMenuItem copyGraphImageSubsectionToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBoxAdjPower;
        private System.Windows.Forms.Label labelAdjacencyPower;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.RichTextBox richTextBoxEigenValue;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddEdgeDirected;
    }
}

