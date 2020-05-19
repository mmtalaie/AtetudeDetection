namespace angeldetector
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.fpsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.restStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.glyphCollectionsList = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.glyphCollectionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.glyphList = new System.Windows.Forms.ListView();
            this.glyphCollectionContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGlyphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGlyphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGlyphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.klmNoiseY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.klmNoiseX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Copy = new System.Windows.Forms.Button();
            this.chbafter = new System.Windows.Forms.CheckBox();
            this.chbuseit = new System.Windows.Forms.CheckBox();
            this.tbx22 = new System.Windows.Forms.TextBox();
            this.tbx21 = new System.Windows.Forms.TextBox();
            this.tbx20 = new System.Windows.Forms.TextBox();
            this.tbx12 = new System.Windows.Forms.TextBox();
            this.tbx11 = new System.Windows.Forms.TextBox();
            this.tbx10 = new System.Windows.Forms.TextBox();
            this.tbx02 = new System.Windows.Forms.TextBox();
            this.tbx01 = new System.Windows.Forms.TextBox();
            this.tbx00 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.focalLen = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.poseGroupBox = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.estimatedTransformationMatrixControl3 = new angeldetector.MatrixControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.estimatedTransformationMatrixControl2 = new angeldetector.MatrixControl();
            this.estimatedTransformationMatrixControl1 = new angeldetector.MatrixControl();
            this.alternatePoseButton = new System.Windows.Forms.Button();
            this.bestPoseButton = new System.Windows.Forms.Button();
            this.focalLengthBox = new System.Windows.Forms.TextBox();
            this.focalLengthLabel = new System.Windows.Forms.Label();
            this.copositRadio = new System.Windows.Forms.RadioButton();
            this.positRadio = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.PARchk = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.yawChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pitchChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rollChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.glyphCollectionsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.glyphCollectionContextMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.poseGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yawChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollChart)).BeginInit();
            this.SuspendLayout();
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer.Location = new System.Drawing.Point(226, 10);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(445, 312);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.Text = "videoSourcePlayer";
            this.videoSourcePlayer.VideoSource = null;
            this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_NewFrame);
            this.videoSourcePlayer.PlayingFinished += new AForge.Video.PlayingFinishedEventHandler(this.videoSourcePlayer_PlayingFinished);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Title = "Opem movie";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fpsLabel,
            this.restStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 718);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1362, 24);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip";
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = false;
            this.fpsLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.fpsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(100, 19);
            // 
            // restStatusLabel
            // 
            this.restStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.restStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.restStatusLabel.Name = "restStatusLabel";
            this.restStatusLabel.Size = new System.Drawing.Size(1247, 19);
            this.restStatusLabel.Spring = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.glyphCollectionsList);
            this.groupBox1.Location = new System.Drawing.Point(3, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 120);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Glyph Collections";
            // 
            // glyphCollectionsList
            // 
            this.glyphCollectionsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glyphCollectionsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.sizeHeader});
            this.glyphCollectionsList.ContextMenuStrip = this.glyphCollectionsContextMenu;
            this.glyphCollectionsList.FullRowSelect = true;
            this.glyphCollectionsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.glyphCollectionsList.HideSelection = false;
            this.glyphCollectionsList.LabelEdit = true;
            this.glyphCollectionsList.Location = new System.Drawing.Point(4, 19);
            this.glyphCollectionsList.MultiSelect = false;
            this.glyphCollectionsList.Name = "glyphCollectionsList";
            this.glyphCollectionsList.Size = new System.Drawing.Size(419, 94);
            this.glyphCollectionsList.TabIndex = 0;
            this.glyphCollectionsList.UseCompatibleStateImageBehavior = false;
            this.glyphCollectionsList.View = System.Windows.Forms.View.Details;
            this.glyphCollectionsList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.glyphCollectionsList_AfterLabelEdit);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 120;
            // 
            // sizeHeader
            // 
            this.sizeHeader.Text = "Size";
            // 
            // glyphCollectionsContextMenu
            // 
            this.glyphCollectionsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activateToolStripMenuItem,
            this.toolStripSeparator1,
            this.newToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.glyphCollectionsContextMenu.Name = "glyphCollectionsContextMenu";
            this.glyphCollectionsContextMenu.Size = new System.Drawing.Size(118, 98);
            // 
            // activateToolStripMenuItem
            // 
            this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
            this.activateToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.activateToolStripMenuItem.Text = "&Activate";
            this.activateToolStripMenuItem.Click += new System.EventHandler(this.activateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripMenuItem.Text = "&Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer.Location = new System.Drawing.Point(0, 383);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.videoSourcePlayer);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer.Size = new System.Drawing.Size(1362, 335);
            this.splitContainer.SplitterDistance = 902;
            this.splitContainer.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.glyphList);
            this.groupBox2.Location = new System.Drawing.Point(7, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 175);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Glyphs";
            // 
            // glyphList
            // 
            this.glyphList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glyphList.ContextMenuStrip = this.glyphCollectionContextMenu;
            this.glyphList.HideSelection = false;
            this.glyphList.Location = new System.Drawing.Point(5, 20);
            this.glyphList.MultiSelect = false;
            this.glyphList.Name = "glyphList";
            this.glyphList.Size = new System.Drawing.Size(414, 152);
            this.glyphList.TabIndex = 0;
            this.glyphList.UseCompatibleStateImageBehavior = false;
            // 
            // glyphCollectionContextMenu
            // 
            this.glyphCollectionContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGlyphToolStripMenuItem,
            this.editGlyphToolStripMenuItem,
            this.deleteGlyphToolStripMenuItem,
            this.toolStripMenuItem4,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem});
            this.glyphCollectionContextMenu.Name = "glyphCollectionContextMenu";
            this.glyphCollectionContextMenu.Size = new System.Drawing.Size(144, 120);
            // 
            // newGlyphToolStripMenuItem
            // 
            this.newGlyphToolStripMenuItem.Name = "newGlyphToolStripMenuItem";
            this.newGlyphToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newGlyphToolStripMenuItem.Text = "&New";
            this.newGlyphToolStripMenuItem.Click += new System.EventHandler(this.newGlyphToolStripMenuItem_Click);
            // 
            // editGlyphToolStripMenuItem
            // 
            this.editGlyphToolStripMenuItem.Name = "editGlyphToolStripMenuItem";
            this.editGlyphToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.editGlyphToolStripMenuItem.Text = "&Edit";
            this.editGlyphToolStripMenuItem.Click += new System.EventHandler(this.editGlyphToolStripMenuItem_Click);
            // 
            // deleteGlyphToolStripMenuItem
            // 
            this.deleteGlyphToolStripMenuItem.Name = "deleteGlyphToolStripMenuItem";
            this.deleteGlyphToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteGlyphToolStripMenuItem.Text = "&Delete";
            this.deleteGlyphToolStripMenuItem.Click += new System.EventHandler(this.deleteGlyphToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(140, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1372, 376);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.focalLen);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.poseGroupBox);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.PARchk);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1364, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Setings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(11, 176);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(507, 23);
            this.button5.TabIndex = 35;
            this.button5.Text = "Start To Write";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(101, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "label8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(101, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "label6";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.klmNoiseY);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.klmNoiseX);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.Copy);
            this.groupBox3.Controls.Add(this.chbafter);
            this.groupBox3.Controls.Add(this.chbuseit);
            this.groupBox3.Controls.Add(this.tbx22);
            this.groupBox3.Controls.Add(this.tbx21);
            this.groupBox3.Controls.Add(this.tbx20);
            this.groupBox3.Controls.Add(this.tbx12);
            this.groupBox3.Controls.Add(this.tbx11);
            this.groupBox3.Controls.Add(this.tbx10);
            this.groupBox3.Controls.Add(this.tbx02);
            this.groupBox3.Controls.Add(this.tbx01);
            this.groupBox3.Controls.Add(this.tbx00);
            this.groupBox3.Location = new System.Drawing.Point(1032, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 331);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "matrix";
            // 
            // klmNoiseY
            // 
            this.klmNoiseY.Location = new System.Drawing.Point(116, 220);
            this.klmNoiseY.Name = "klmNoiseY";
            this.klmNoiseY.Size = new System.Drawing.Size(85, 20);
            this.klmNoiseY.TabIndex = 16;
            this.klmNoiseY.Text = "0.5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "KalmanNoiseY : ";
            // 
            // klmNoiseX
            // 
            this.klmNoiseX.Location = new System.Drawing.Point(116, 185);
            this.klmNoiseX.Name = "klmNoiseX";
            this.klmNoiseX.Size = new System.Drawing.Size(85, 20);
            this.klmNoiseX.TabIndex = 14;
            this.klmNoiseX.Text = "0.5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "KalmanNoiseX : ";
            // 
            // Copy
            // 
            this.Copy.Location = new System.Drawing.Point(15, 23);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(186, 23);
            this.Copy.TabIndex = 12;
            this.Copy.Text = "Copy Inverse";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // chbafter
            // 
            this.chbafter.AutoSize = true;
            this.chbafter.Location = new System.Drawing.Point(79, 60);
            this.chbafter.Name = "chbafter";
            this.chbafter.Size = new System.Drawing.Size(67, 17);
            this.chbafter.TabIndex = 11;
            this.chbafter.Text = "Mul after";
            this.chbafter.UseVisualStyleBackColor = true;
            // 
            // chbuseit
            // 
            this.chbuseit.AutoSize = true;
            this.chbuseit.Location = new System.Drawing.Point(15, 60);
            this.chbuseit.Name = "chbuseit";
            this.chbuseit.Size = new System.Drawing.Size(68, 17);
            this.chbuseit.TabIndex = 10;
            this.chbuseit.Text = "Use This";
            this.chbuseit.UseVisualStyleBackColor = true;
            // 
            // tbx22
            // 
            this.tbx22.Location = new System.Drawing.Point(143, 144);
            this.tbx22.Name = "tbx22";
            this.tbx22.Size = new System.Drawing.Size(58, 20);
            this.tbx22.TabIndex = 8;
            this.tbx22.Text = "1";
            // 
            // tbx21
            // 
            this.tbx21.Location = new System.Drawing.Point(79, 144);
            this.tbx21.Name = "tbx21";
            this.tbx21.Size = new System.Drawing.Size(58, 20);
            this.tbx21.TabIndex = 7;
            this.tbx21.Text = "0";
            // 
            // tbx20
            // 
            this.tbx20.Location = new System.Drawing.Point(15, 144);
            this.tbx20.Name = "tbx20";
            this.tbx20.Size = new System.Drawing.Size(58, 20);
            this.tbx20.TabIndex = 6;
            this.tbx20.Text = "0";
            // 
            // tbx12
            // 
            this.tbx12.Location = new System.Drawing.Point(143, 118);
            this.tbx12.Name = "tbx12";
            this.tbx12.Size = new System.Drawing.Size(58, 20);
            this.tbx12.TabIndex = 5;
            this.tbx12.Text = "0";
            // 
            // tbx11
            // 
            this.tbx11.Location = new System.Drawing.Point(79, 118);
            this.tbx11.Name = "tbx11";
            this.tbx11.Size = new System.Drawing.Size(58, 20);
            this.tbx11.TabIndex = 4;
            this.tbx11.Text = "1";
            // 
            // tbx10
            // 
            this.tbx10.Location = new System.Drawing.Point(15, 118);
            this.tbx10.Name = "tbx10";
            this.tbx10.Size = new System.Drawing.Size(58, 20);
            this.tbx10.TabIndex = 3;
            this.tbx10.Text = "0";
            // 
            // tbx02
            // 
            this.tbx02.Location = new System.Drawing.Point(143, 92);
            this.tbx02.Name = "tbx02";
            this.tbx02.Size = new System.Drawing.Size(58, 20);
            this.tbx02.TabIndex = 2;
            this.tbx02.Text = "0";
            // 
            // tbx01
            // 
            this.tbx01.Location = new System.Drawing.Point(79, 92);
            this.tbx01.Name = "tbx01";
            this.tbx01.Size = new System.Drawing.Size(58, 20);
            this.tbx01.TabIndex = 1;
            this.tbx01.Text = "0";
            // 
            // tbx00
            // 
            this.tbx00.Location = new System.Drawing.Point(15, 92);
            this.tbx00.Name = "tbx00";
            this.tbx00.Size = new System.Drawing.Size(58, 20);
            this.tbx00.TabIndex = 0;
            this.tbx00.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(101, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "label5";
            // 
            // focalLen
            // 
            this.focalLen.Location = new System.Drawing.Point(337, 50);
            this.focalLen.Name = "focalLen";
            this.focalLen.Size = new System.Drawing.Size(75, 23);
            this.focalLen.TabIndex = 29;
            this.focalLen.Text = "focal";
            this.focalLen.UseVisualStyleBackColor = true;
            this.focalLen.Click += new System.EventHandler(this.focalLen_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(418, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 28;
            this.textBox1.Text = "640";
            // 
            // poseGroupBox
            // 
            this.poseGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.poseGroupBox.Controls.Add(this.label9);
            this.poseGroupBox.Controls.Add(this.estimatedTransformationMatrixControl3);
            this.poseGroupBox.Controls.Add(this.label4);
            this.poseGroupBox.Controls.Add(this.label3);
            this.poseGroupBox.Controls.Add(this.estimatedTransformationMatrixControl2);
            this.poseGroupBox.Controls.Add(this.estimatedTransformationMatrixControl1);
            this.poseGroupBox.Controls.Add(this.alternatePoseButton);
            this.poseGroupBox.Controls.Add(this.bestPoseButton);
            this.poseGroupBox.Controls.Add(this.focalLengthBox);
            this.poseGroupBox.Controls.Add(this.focalLengthLabel);
            this.poseGroupBox.Controls.Add(this.copositRadio);
            this.poseGroupBox.Controls.Add(this.positRadio);
            this.poseGroupBox.Location = new System.Drawing.Point(524, 6);
            this.poseGroupBox.Name = "poseGroupBox";
            this.poseGroupBox.Size = new System.Drawing.Size(483, 363);
            this.poseGroupBox.TabIndex = 27;
            this.poseGroupBox.TabStop = false;
            this.poseGroupBox.Text = "matrixes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(365, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "3";
            // 
            // estimatedTransformationMatrixControl3
            // 
            this.estimatedTransformationMatrixControl3.Location = new System.Drawing.Point(251, 221);
            this.estimatedTransformationMatrixControl3.Name = "estimatedTransformationMatrixControl3";
            this.estimatedTransformationMatrixControl3.Size = new System.Drawing.Size(230, 110);
            this.estimatedTransformationMatrixControl3.TabIndex = 14;
            this.estimatedTransformationMatrixControl3.Title = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(352, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "1";
            // 
            // estimatedTransformationMatrixControl2
            // 
            this.estimatedTransformationMatrixControl2.Location = new System.Drawing.Point(251, 60);
            this.estimatedTransformationMatrixControl2.Name = "estimatedTransformationMatrixControl2";
            this.estimatedTransformationMatrixControl2.Size = new System.Drawing.Size(230, 110);
            this.estimatedTransformationMatrixControl2.TabIndex = 6;
            this.estimatedTransformationMatrixControl2.Title = "";
            // 
            // estimatedTransformationMatrixControl1
            // 
            this.estimatedTransformationMatrixControl1.Location = new System.Drawing.Point(6, 60);
            this.estimatedTransformationMatrixControl1.Name = "estimatedTransformationMatrixControl1";
            this.estimatedTransformationMatrixControl1.Size = new System.Drawing.Size(230, 110);
            this.estimatedTransformationMatrixControl1.TabIndex = 5;
            this.estimatedTransformationMatrixControl1.Title = "";
            // 
            // alternatePoseButton
            // 
            this.alternatePoseButton.Location = new System.Drawing.Point(408, 21);
            this.alternatePoseButton.Name = "alternatePoseButton";
            this.alternatePoseButton.Size = new System.Drawing.Size(20, 20);
            this.alternatePoseButton.TabIndex = 2;
            this.alternatePoseButton.Text = "&A";
            this.alternatePoseButton.UseVisualStyleBackColor = true;
            this.alternatePoseButton.Visible = false;
            // 
            // bestPoseButton
            // 
            this.bestPoseButton.Location = new System.Drawing.Point(382, 22);
            this.bestPoseButton.Name = "bestPoseButton";
            this.bestPoseButton.Size = new System.Drawing.Size(20, 20);
            this.bestPoseButton.TabIndex = 1;
            this.bestPoseButton.Text = "&B";
            this.bestPoseButton.UseVisualStyleBackColor = true;
            this.bestPoseButton.Visible = false;
            // 
            // focalLengthBox
            // 
            this.focalLengthBox.Location = new System.Drawing.Point(278, 19);
            this.focalLengthBox.Name = "focalLengthBox";
            this.focalLengthBox.Size = new System.Drawing.Size(85, 20);
            this.focalLengthBox.TabIndex = 4;
            this.focalLengthBox.Visible = false;
            // 
            // focalLengthLabel
            // 
            this.focalLengthLabel.AutoSize = true;
            this.focalLengthLabel.Location = new System.Drawing.Point(193, 22);
            this.focalLengthLabel.Name = "focalLengthLabel";
            this.focalLengthLabel.Size = new System.Drawing.Size(68, 13);
            this.focalLengthLabel.TabIndex = 3;
            this.focalLengthLabel.Text = "Focal length:";
            this.focalLengthLabel.Visible = false;
            // 
            // copositRadio
            // 
            this.copositRadio.AutoSize = true;
            this.copositRadio.Location = new System.Drawing.Point(80, 23);
            this.copositRadio.Name = "copositRadio";
            this.copositRadio.Size = new System.Drawing.Size(102, 17);
            this.copositRadio.TabIndex = 2;
            this.copositRadio.TabStop = true;
            this.copositRadio.Text = "Coplanar POSIT";
            this.copositRadio.UseVisualStyleBackColor = true;
            this.copositRadio.Visible = false;
            // 
            // positRadio
            // 
            this.positRadio.AutoSize = true;
            this.positRadio.Location = new System.Drawing.Point(10, 23);
            this.positRadio.Name = "positRadio";
            this.positRadio.Size = new System.Drawing.Size(57, 17);
            this.positRadio.TabIndex = 1;
            this.positRadio.TabStop = true;
            this.positRadio.Text = "POSIT";
            this.positRadio.UseVisualStyleBackColor = true;
            this.positRadio.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(202, 47);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 26;
            this.button4.Text = "Zero";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // PARchk
            // 
            this.PARchk.AutoSize = true;
            this.PARchk.Location = new System.Drawing.Point(202, 30);
            this.PARchk.Name = "PARchk";
            this.PARchk.Size = new System.Drawing.Size(48, 17);
            this.PARchk.TabIndex = 25;
            this.PARchk.Text = "PAR";
            this.PARchk.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "label1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(92, 47);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "ShowBoarder";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "VideoFile";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Camera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.yawChart);
            this.tabPage2.Controls.Add(this.pitchChart);
            this.tabPage2.Controls.Add(this.rollChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1364, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chart";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // yawChart
            // 
            chartArea1.Name = "ChartArea1";
            this.yawChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.yawChart.Legends.Add(legend1);
            this.yawChart.Location = new System.Drawing.Point(6, 167);
            this.yawChart.Name = "yawChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.yawChart.Series.Add(series1);
            this.yawChart.Size = new System.Drawing.Size(585, 177);
            this.yawChart.TabIndex = 2;
            this.yawChart.Text = "chart3";
            // 
            // pitchChart
            // 
            chartArea2.Name = "ChartArea1";
            this.pitchChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.pitchChart.Legends.Add(legend2);
            this.pitchChart.Location = new System.Drawing.Point(642, 6);
            this.pitchChart.Name = "pitchChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.pitchChart.Series.Add(series2);
            this.pitchChart.Size = new System.Drawing.Size(585, 177);
            this.pitchChart.TabIndex = 1;
            this.pitchChart.Text = "chart2";
            // 
            // rollChart
            // 
            chartArea3.Name = "ChartArea1";
            this.rollChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.rollChart.Legends.Add(legend3);
            this.rollChart.Location = new System.Drawing.Point(8, 15);
            this.rollChart.Name = "rollChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.rollChart.Series.Add(series3);
            this.rollChart.Size = new System.Drawing.Size(585, 159);
            this.rollChart.TabIndex = 0;
            this.rollChart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 742);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.glyphCollectionsContextMenu.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.glyphCollectionContextMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.poseGroupBox.ResumeLayout(false);
            this.poseGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yawChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel fpsLabel;
        private System.Windows.Forms.ToolStripStatusLabel restStatusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView glyphCollectionsList;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader sizeHeader;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ContextMenuStrip glyphCollectionsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView glyphList;
        private System.Windows.Forms.ContextMenuStrip glyphCollectionContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newGlyphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGlyphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGlyphToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox klmNoiseY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox klmNoiseX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.CheckBox chbafter;
        private System.Windows.Forms.CheckBox chbuseit;
        private System.Windows.Forms.TextBox tbx22;
        private System.Windows.Forms.TextBox tbx21;
        private System.Windows.Forms.TextBox tbx20;
        private System.Windows.Forms.TextBox tbx12;
        private System.Windows.Forms.TextBox tbx11;
        private System.Windows.Forms.TextBox tbx10;
        private System.Windows.Forms.TextBox tbx02;
        private System.Windows.Forms.TextBox tbx01;
        private System.Windows.Forms.TextBox tbx00;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button focalLen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox poseGroupBox;
        private System.Windows.Forms.Label label9;
        private MatrixControl estimatedTransformationMatrixControl3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private MatrixControl estimatedTransformationMatrixControl2;
        private MatrixControl estimatedTransformationMatrixControl1;
        private System.Windows.Forms.Button alternatePoseButton;
        private System.Windows.Forms.Button bestPoseButton;
        private System.Windows.Forms.TextBox focalLengthBox;
        private System.Windows.Forms.Label focalLengthLabel;
        private System.Windows.Forms.RadioButton copositRadio;
        private System.Windows.Forms.RadioButton positRadio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart yawChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart pitchChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart rollChart;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox PARchk;
    }
}

