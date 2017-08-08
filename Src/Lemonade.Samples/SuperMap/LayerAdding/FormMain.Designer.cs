namespace Lemonade.Samples.SM.SampleCode.Mapping
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.m_toolStrip = new System.Windows.Forms.ToolStrip();
            this.m_toolStripComboBoxIsCustom = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.m_toolStripButtonPoint = new System.Windows.Forms.ToolStripButton();
            this.m_toolStripButtonLine = new System.Windows.Forms.ToolStripButton();
            this.m_toolStripButtonRegion = new System.Windows.Forms.ToolStripButton();
            this.m_toolStripButtonGrid = new System.Windows.Forms.ToolStripButton();
            this.m_toolStripButtonImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.m_toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_toolStrip
            // 
            this.m_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolStripComboBoxIsCustom,
            this.toolStripSeparator1,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButton5,
            this.m_toolStripButtonPoint,
            this.m_toolStripButtonLine,
            this.m_toolStripButtonRegion,
            this.m_toolStripButtonGrid,
            this.m_toolStripButtonImage,
            this.toolStripSeparator2,
            this.m_toolStripButtonClear});
            this.m_toolStrip.Location = new System.Drawing.Point(0, 0);
            this.m_toolStrip.Name = "m_toolStrip";
            this.m_toolStrip.Size = new System.Drawing.Size(626, 25);
            this.m_toolStrip.TabIndex = 0;
            this.m_toolStrip.Text = "toolStrip1";
            // 
            // m_toolStripComboBoxIsCustom
            // 
            this.m_toolStripComboBoxIsCustom.AutoSize = false;
            this.m_toolStripComboBoxIsCustom.Name = "m_toolStripComboBoxIsCustom";
            this.m_toolStripComboBoxIsCustom.Size = new System.Drawing.Size(100, 25);
            this.m_toolStripComboBoxIsCustom.SelectedIndexChanged += new System.EventHandler(this.m_toolStripComboBoxIsCustom_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(80, 22);
            this.toolStripButton4.Text = "4";
            this.toolStripButton4.ToolTipText = "在图层中添加点数据集";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(80, 22);
            this.toolStripButton3.Text = "3";
            this.toolStripButton3.ToolTipText = "在图层中添加点数据集";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(80, 22);
            this.toolStripButton2.Text = "2";
            this.toolStripButton2.ToolTipText = "在图层中添加点数据集";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(80, 22);
            this.toolStripButton1.Text = "1";
            this.toolStripButton1.ToolTipText = "在图层中添加点数据集";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(80, 22);
            this.toolStripButton5.Text = "完全移除";
            this.toolStripButton5.ToolTipText = "在图层中添加点数据集";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // m_toolStripButtonPoint
            // 
            this.m_toolStripButtonPoint.AutoSize = false;
            this.m_toolStripButtonPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_toolStripButtonPoint.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonPoint.Image")));
            this.m_toolStripButtonPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonPoint.Name = "m_toolStripButtonPoint";
            this.m_toolStripButtonPoint.Size = new System.Drawing.Size(80, 22);
            this.m_toolStripButtonPoint.Text = "添加点数据集";
            this.m_toolStripButtonPoint.ToolTipText = "在图层中添加点数据集";
            this.m_toolStripButtonPoint.Click += new System.EventHandler(this.m_toolStripButtonPoint_Click);
            // 
            // m_toolStripButtonLine
            // 
            this.m_toolStripButtonLine.AutoSize = false;
            this.m_toolStripButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_toolStripButtonLine.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonLine.Image")));
            this.m_toolStripButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonLine.Name = "m_toolStripButtonLine";
            this.m_toolStripButtonLine.Size = new System.Drawing.Size(80, 22);
            this.m_toolStripButtonLine.Text = "添加线数据集";
            this.m_toolStripButtonLine.ToolTipText = "在图层中添加线数据集";
            this.m_toolStripButtonLine.Click += new System.EventHandler(this.m_toolStripButtonLine_Click);
            // 
            // m_toolStripButtonRegion
            // 
            this.m_toolStripButtonRegion.AutoSize = false;
            this.m_toolStripButtonRegion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_toolStripButtonRegion.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonRegion.Image")));
            this.m_toolStripButtonRegion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonRegion.Name = "m_toolStripButtonRegion";
            this.m_toolStripButtonRegion.Size = new System.Drawing.Size(83, 22);
            this.m_toolStripButtonRegion.Text = "添加面数据集";
            this.m_toolStripButtonRegion.ToolTipText = "在图层中添加面数据集";
            this.m_toolStripButtonRegion.Click += new System.EventHandler(this.m_toolStripButtonRegion_Click);
            // 
            // m_toolStripButtonGrid
            // 
            this.m_toolStripButtonGrid.AutoSize = false;
            this.m_toolStripButtonGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_toolStripButtonGrid.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonGrid.Image")));
            this.m_toolStripButtonGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonGrid.Name = "m_toolStripButtonGrid";
            this.m_toolStripButtonGrid.Size = new System.Drawing.Size(95, 22);
            this.m_toolStripButtonGrid.Text = "添加栅格数据集";
            this.m_toolStripButtonGrid.ToolTipText = "在图层中添加栅格数据集";
            this.m_toolStripButtonGrid.Click += new System.EventHandler(this.m_toolStripButtonGrid_Click);
            // 
            // m_toolStripButtonImage
            // 
            this.m_toolStripButtonImage.AutoSize = false;
            this.m_toolStripButtonImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_toolStripButtonImage.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonImage.Image")));
            this.m_toolStripButtonImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonImage.Name = "m_toolStripButtonImage";
            this.m_toolStripButtonImage.Size = new System.Drawing.Size(90, 22);
            this.m_toolStripButtonImage.Text = "添加影像数据集";
            this.m_toolStripButtonImage.ToolTipText = "在图层中添加影像数据集";
            this.m_toolStripButtonImage.Click += new System.EventHandler(this.m_toolStripButtonImage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // m_toolStripButtonClear
            // 
            this.m_toolStripButtonClear.AutoSize = false;
            this.m_toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonClear.Image")));
            this.m_toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonClear.Name = "m_toolStripButtonClear";
            this.m_toolStripButtonClear.Size = new System.Drawing.Size(55, 22);
            this.m_toolStripButtonClear.Text = "清空图层";
            this.m_toolStripButtonClear.ToolTipText = "清空地图中的所有图层";
            this.m_toolStripButtonClear.Click += new System.EventHandler(this.m_toolStripButtonClear_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 573);
            this.Controls.Add(this.m_toolStrip);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 图层添加";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.m_toolStrip.ResumeLayout(false);
            this.m_toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip m_toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonPoint;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonLine;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonRegion;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonGrid;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonClear;
        private System.Windows.Forms.ToolStripComboBox m_toolStripComboBoxIsCustom;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;


    }
}
