namespace GEDemo4
{
    partial class GEDemo4
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GEDemo4));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGEViewr = new System.Windows.Forms.TabPage();
            this.tabXPViewer = new System.Windows.Forms.TabPage();
            this.btnAppx = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnStartGE = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStopGE = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSnap = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnGESnap = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAPISnap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mainPanel.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tabControl);
            this.mainPanel.Controls.Add(this.toolBar);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1182, 855);
            this.mainPanel.TabIndex = 0;
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAppx,
            this.toolStripSeparator3,
            this.btnSnap,
            this.toolStripSeparator4});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1182, 27);
            this.toolBar.TabIndex = 0;
            this.toolBar.Text = "toolStrip1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGEViewr);
            this.tabControl.Controls.Add(this.tabXPViewer);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1182, 828);
            this.tabControl.TabIndex = 1;
            // 
            // tabGEViewr
            // 
            this.tabGEViewr.Location = new System.Drawing.Point(4, 32);
            this.tabGEViewr.Name = "tabGEViewr";
            this.tabGEViewr.Padding = new System.Windows.Forms.Padding(3);
            this.tabGEViewr.Size = new System.Drawing.Size(1174, 792);
            this.tabGEViewr.TabIndex = 0;
            this.tabGEViewr.Text = "GEViewer";
            this.tabGEViewr.UseVisualStyleBackColor = true;
            // 
            // tabXPViewer
            // 
            this.tabXPViewer.Location = new System.Drawing.Point(4, 32);
            this.tabXPViewer.Name = "tabXPViewer";
            this.tabXPViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabXPViewer.Size = new System.Drawing.Size(1174, 794);
            this.tabXPViewer.TabIndex = 1;
            this.tabXPViewer.Text = "XPViewer";
            this.tabXPViewer.UseVisualStyleBackColor = true;
            // 
            // btnAppx
            // 
            this.btnAppx.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartGE,
            this.btnStopGE,
            this.btnExitApp});
            this.btnAppx.Image = ((System.Drawing.Image)(resources.GetObject("btnAppx.Image")));
            this.btnAppx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAppx.Name = "btnAppx";
            this.btnAppx.Size = new System.Drawing.Size(68, 24);
            this.btnAppx.Text = "开始";
            // 
            // btnStartGE
            // 
            this.btnStartGE.Name = "btnStartGE";
            this.btnStartGE.Size = new System.Drawing.Size(175, 24);
            this.btnStartGE.Text = "启动GE";
            // 
            // btnStopGE
            // 
            this.btnStopGE.Name = "btnStopGE";
            this.btnStopGE.Size = new System.Drawing.Size(175, 24);
            this.btnStopGE.Text = "关闭GE";
            // 
            // btnExitApp
            // 
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(175, 24);
            this.btnExitApp.Text = "退出程序";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnSnap
            // 
            this.btnSnap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGESnap,
            this.btnAPISnap});
            this.btnSnap.Image = ((System.Drawing.Image)(resources.GetObject("btnSnap.Image")));
            this.btnSnap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(68, 24);
            this.btnSnap.Text = "截图";
            // 
            // btnGESnap
            // 
            this.btnGESnap.Name = "btnGESnap";
            this.btnGESnap.Size = new System.Drawing.Size(175, 24);
            this.btnGESnap.Text = "GE截图";
            // 
            // btnAPISnap
            // 
            this.btnAPISnap.Name = "btnAPISnap";
            this.btnAPISnap.Size = new System.Drawing.Size(175, 24);
            this.btnAPISnap.Text = "API截图";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // GEDemo4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 855);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GEDemo4";
            this.Text = "GEDemo4";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGEViewr;
        private System.Windows.Forms.TabPage tabXPViewer;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripDropDownButton btnAppx;
        private System.Windows.Forms.ToolStripMenuItem btnStartGE;
        private System.Windows.Forms.ToolStripMenuItem btnStopGE;
        private System.Windows.Forms.ToolStripMenuItem btnExitApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton btnSnap;
        private System.Windows.Forms.ToolStripMenuItem btnGESnap;
        private System.Windows.Forms.ToolStripMenuItem btnAPISnap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

    }
}

