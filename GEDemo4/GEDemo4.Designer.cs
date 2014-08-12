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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GEDemo4));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tabDocker = new System.Windows.Forms.TabControl();
            this.tabGEViewer = new System.Windows.Forms.TabPage();
            this.tabXPViewer = new System.Windows.Forms.TabPage();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.btnAppx = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnStartGE = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStopGE = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSnap = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnGESnap = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAPISnap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.msgBar = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanel.SuspendLayout();
            this.tabDocker.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tabDocker);
            this.mainPanel.Controls.Add(this.toolBar);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1182, 855);
            this.mainPanel.TabIndex = 0;
            // 
            // tabDocker
            // 
            this.tabDocker.Controls.Add(this.tabGEViewer);
            this.tabDocker.Controls.Add(this.tabXPViewer);
            this.tabDocker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDocker.Location = new System.Drawing.Point(0, 27);
            this.tabDocker.Name = "tabDocker";
            this.tabDocker.SelectedIndex = 0;
            this.tabDocker.Size = new System.Drawing.Size(1182, 828);
            this.tabDocker.TabIndex = 1;
            // 
            // tabGEViewer
            // 
            this.tabGEViewer.BackColor = System.Drawing.Color.LightGray;
            this.tabGEViewer.Location = new System.Drawing.Point(4, 32);
            this.tabGEViewer.Name = "tabGEViewer";
            this.tabGEViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabGEViewer.Size = new System.Drawing.Size(1174, 792);
            this.tabGEViewer.TabIndex = 0;
            this.tabGEViewer.Text = "GEViewer";
            // 
            // tabXPViewer
            // 
            this.tabXPViewer.BackColor = System.Drawing.Color.LightGray;
            this.tabXPViewer.Location = new System.Drawing.Point(4, 32);
            this.tabXPViewer.Name = "tabXPViewer";
            this.tabXPViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabXPViewer.Size = new System.Drawing.Size(1174, 792);
            this.tabXPViewer.TabIndex = 1;
            this.tabXPViewer.Text = "XPViewer";
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAppx,
            this.toolStripSeparator1,
            this.btnSnap,
            this.toolStripSeparator2});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1182, 27);
            this.toolBar.TabIndex = 0;
            this.toolBar.Text = "toolStrip1";
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
            this.btnStartGE.Click += new System.EventHandler(this.btnStartGE_Click);
            // 
            // btnStopGE
            // 
            this.btnStopGE.Name = "btnStopGE";
            this.btnStopGE.Size = new System.Drawing.Size(175, 24);
            this.btnStopGE.Text = "关闭GE";
            this.btnStopGE.Click += new System.EventHandler(this.btnStopGE_Click);
            // 
            // btnExitApp
            // 
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(175, 24);
            this.btnExitApp.Text = "退出程序";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
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
            this.btnGESnap.Click += new System.EventHandler(this.btnGESnap_Click);
            // 
            // btnAPISnap
            // 
            this.btnAPISnap.Name = "btnAPISnap";
            this.btnAPISnap.Size = new System.Drawing.Size(175, 24);
            this.btnAPISnap.Text = "API截图";
            this.btnAPISnap.Click += new System.EventHandler(this.btnAPISnap_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // GEDemo4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 855);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Cambria", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GEDemo4";
            this.Text = "GEDemo4";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.tabDocker.ResumeLayout(false);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripDropDownButton btnAppx;
        private System.Windows.Forms.ToolStripMenuItem btnStartGE;
        private System.Windows.Forms.ToolStripMenuItem btnStopGE;
        private System.Windows.Forms.ToolStripMenuItem btnExitApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton btnSnap;
        private System.Windows.Forms.ToolStripMenuItem btnGESnap;
        private System.Windows.Forms.ToolStripMenuItem btnAPISnap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl tabDocker;
        private System.Windows.Forms.TabPage tabGEViewer;
        private System.Windows.Forms.TabPage tabXPViewer;
        private System.Windows.Forms.ToolTip msgBar;
    }
}

