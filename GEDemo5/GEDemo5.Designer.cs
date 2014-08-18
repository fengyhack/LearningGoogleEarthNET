namespace GEDemo5
{
    partial class GEDemo5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GEDemo5));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tabDocker = new System.Windows.Forms.TabControl();
            this.tabGEViewer = new System.Windows.Forms.TabPage();
            this.tabXPViewer = new System.Windows.Forms.TabPage();
            this.btnOKCamParams = new System.Windows.Forms.Button();
            this.setCameraParameters = new System.Windows.Forms.GroupBox();
            this.label_LonExp = new System.Windows.Forms.Label();
            this.label_LatExp = new System.Windows.Forms.Label();
            this.label_Speed = new System.Windows.Forms.Label();
            this.label_Azimuth = new System.Windows.Forms.Label();
            this.label_Angle = new System.Windows.Forms.Label();
            this.label_Range = new System.Windows.Forms.Label();
            this.label_Altitude = new System.Windows.Forms.Label();
            this.label_Longitude = new System.Windows.Forms.Label();
            this.label_Latitude = new System.Windows.Forms.Label();
            this.txtBoxSpd = new System.Windows.Forms.TextBox();
            this.txtBoxAzm = new System.Windows.Forms.TextBox();
            this.txtBoxAng = new System.Windows.Forms.TextBox();
            this.txtBoxRng = new System.Windows.Forms.TextBox();
            this.txtBoxAlt = new System.Windows.Forms.TextBox();
            this.txtBoxLon = new System.Windows.Forms.TextBox();
            this.txtBoxLat = new System.Windows.Forms.TextBox();
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
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.msgToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanel.SuspendLayout();
            this.tabDocker.SuspendLayout();
            this.tabXPViewer.SuspendLayout();
            this.setCameraParameters.SuspendLayout();
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
            this.tabDocker.Location = new System.Drawing.Point(0, 30);
            this.tabDocker.Name = "tabDocker";
            this.tabDocker.SelectedIndex = 0;
            this.tabDocker.Size = new System.Drawing.Size(1182, 825);
            this.tabDocker.TabIndex = 1;
            // 
            // tabGEViewer
            // 
            this.tabGEViewer.BackColor = System.Drawing.Color.LightGray;
            this.tabGEViewer.Location = new System.Drawing.Point(4, 32);
            this.tabGEViewer.Name = "tabGEViewer";
            this.tabGEViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabGEViewer.Size = new System.Drawing.Size(1174, 789);
            this.tabGEViewer.TabIndex = 0;
            this.tabGEViewer.Text = "GEViewer";
            // 
            // tabXPViewer
            // 
            this.tabXPViewer.BackColor = System.Drawing.Color.LightGray;
            this.tabXPViewer.Controls.Add(this.btnOKCamParams);
            this.tabXPViewer.Controls.Add(this.setCameraParameters);
            this.tabXPViewer.Location = new System.Drawing.Point(4, 32);
            this.tabXPViewer.Name = "tabXPViewer";
            this.tabXPViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabXPViewer.Size = new System.Drawing.Size(1174, 789);
            this.tabXPViewer.TabIndex = 1;
            this.tabXPViewer.Text = "XPViewer";
            // 
            // btnOKCamParams
            // 
            this.btnOKCamParams.Location = new System.Drawing.Point(87, 531);
            this.btnOKCamParams.Name = "btnOKCamParams";
            this.btnOKCamParams.Size = new System.Drawing.Size(146, 39);
            this.btnOKCamParams.TabIndex = 1;
            this.btnOKCamParams.Text = "应用";
            this.btnOKCamParams.UseVisualStyleBackColor = true;
            this.btnOKCamParams.Click += new System.EventHandler(this.btnOKCamParams_Click);
            // 
            // setCameraParameters
            // 
            this.setCameraParameters.Controls.Add(this.label_LonExp);
            this.setCameraParameters.Controls.Add(this.label_LatExp);
            this.setCameraParameters.Controls.Add(this.label_Speed);
            this.setCameraParameters.Controls.Add(this.label_Azimuth);
            this.setCameraParameters.Controls.Add(this.label_Angle);
            this.setCameraParameters.Controls.Add(this.label_Range);
            this.setCameraParameters.Controls.Add(this.label_Altitude);
            this.setCameraParameters.Controls.Add(this.label_Longitude);
            this.setCameraParameters.Controls.Add(this.label_Latitude);
            this.setCameraParameters.Controls.Add(this.txtBoxSpd);
            this.setCameraParameters.Controls.Add(this.txtBoxAzm);
            this.setCameraParameters.Controls.Add(this.txtBoxAng);
            this.setCameraParameters.Controls.Add(this.txtBoxRng);
            this.setCameraParameters.Controls.Add(this.txtBoxAlt);
            this.setCameraParameters.Controls.Add(this.txtBoxLon);
            this.setCameraParameters.Controls.Add(this.txtBoxLat);
            this.setCameraParameters.Location = new System.Drawing.Point(18, 34);
            this.setCameraParameters.Name = "setCameraParameters";
            this.setCameraParameters.Size = new System.Drawing.Size(329, 471);
            this.setCameraParameters.TabIndex = 0;
            this.setCameraParameters.TabStop = false;
            this.setCameraParameters.Text = "相机参数设定";
            // 
            // label_LonExp
            // 
            this.label_LonExp.AutoSize = true;
            this.label_LonExp.Location = new System.Drawing.Point(32, 153);
            this.label_LonExp.Name = "label_LonExp";
            this.label_LonExp.Size = new System.Drawing.Size(219, 23);
            this.label_LonExp.TabIndex = 15;
            this.label_LonExp.Text = "[-180,180](东经+,西经-)";
            // 
            // label_LatExp
            // 
            this.label_LatExp.AutoSize = true;
            this.label_LatExp.Location = new System.Drawing.Point(33, 70);
            this.label_LatExp.Name = "label_LatExp";
            this.label_LatExp.Size = new System.Drawing.Size(256, 23);
            this.label_LatExp.TabIndex = 14;
            this.label_LatExp.Text = "[-90,90](赤道0,北纬+,南纬+)";
            // 
            // label_Speed
            // 
            this.label_Speed.AutoSize = true;
            this.label_Speed.Location = new System.Drawing.Point(21, 422);
            this.label_Speed.Name = "label_Speed";
            this.label_Speed.Size = new System.Drawing.Size(90, 23);
            this.label_Speed.TabIndex = 13;
            this.label_Speed.Text = "移动速度";
            // 
            // label_Azimuth
            // 
            this.label_Azimuth.AutoSize = true;
            this.label_Azimuth.Location = new System.Drawing.Point(21, 369);
            this.label_Azimuth.Name = "label_Azimuth";
            this.label_Azimuth.Size = new System.Drawing.Size(94, 23);
            this.label_Azimuth.TabIndex = 12;
            this.label_Azimuth.Text = "方位角(°)";
            // 
            // label_Angle
            // 
            this.label_Angle.AutoSize = true;
            this.label_Angle.Location = new System.Drawing.Point(21, 315);
            this.label_Angle.Name = "label_Angle";
            this.label_Angle.Size = new System.Drawing.Size(74, 23);
            this.label_Angle.TabIndex = 11;
            this.label_Angle.Text = "倾角(°)";
            // 
            // label_Range
            // 
            this.label_Range.AutoSize = true;
            this.label_Range.Location = new System.Drawing.Point(21, 262);
            this.label_Range.Name = "label_Range";
            this.label_Range.Size = new System.Drawing.Size(86, 23);
            this.label_Range.TabIndex = 10;
            this.label_Range.Text = "视场(米)";
            // 
            // label_Altitude
            // 
            this.label_Altitude.AutoSize = true;
            this.label_Altitude.Location = new System.Drawing.Point(21, 210);
            this.label_Altitude.Name = "label_Altitude";
            this.label_Altitude.Size = new System.Drawing.Size(86, 23);
            this.label_Altitude.TabIndex = 9;
            this.label_Altitude.Text = "高度(米)";
            // 
            // label_Longitude
            // 
            this.label_Longitude.AutoSize = true;
            this.label_Longitude.Location = new System.Drawing.Point(21, 115);
            this.label_Longitude.Name = "label_Longitude";
            this.label_Longitude.Size = new System.Drawing.Size(74, 23);
            this.label_Longitude.TabIndex = 8;
            this.label_Longitude.Text = "经度(°)";
            // 
            // label_Latitude
            // 
            this.label_Latitude.AutoSize = true;
            this.label_Latitude.Location = new System.Drawing.Point(21, 38);
            this.label_Latitude.Name = "label_Latitude";
            this.label_Latitude.Size = new System.Drawing.Size(74, 23);
            this.label_Latitude.TabIndex = 7;
            this.label_Latitude.Text = "纬度(°)";
            // 
            // txtBoxSpd
            // 
            this.txtBoxSpd.Location = new System.Drawing.Point(115, 419);
            this.txtBoxSpd.Name = "txtBoxSpd";
            this.txtBoxSpd.Size = new System.Drawing.Size(100, 31);
            this.txtBoxSpd.TabIndex = 6;
            // 
            // txtBoxAzm
            // 
            this.txtBoxAzm.Location = new System.Drawing.Point(115, 366);
            this.txtBoxAzm.Name = "txtBoxAzm";
            this.txtBoxAzm.Size = new System.Drawing.Size(100, 31);
            this.txtBoxAzm.TabIndex = 5;
            // 
            // txtBoxAng
            // 
            this.txtBoxAng.Location = new System.Drawing.Point(115, 312);
            this.txtBoxAng.Name = "txtBoxAng";
            this.txtBoxAng.Size = new System.Drawing.Size(100, 31);
            this.txtBoxAng.TabIndex = 4;
            // 
            // txtBoxRng
            // 
            this.txtBoxRng.Location = new System.Drawing.Point(115, 259);
            this.txtBoxRng.Name = "txtBoxRng";
            this.txtBoxRng.Size = new System.Drawing.Size(100, 31);
            this.txtBoxRng.TabIndex = 3;
            // 
            // txtBoxAlt
            // 
            this.txtBoxAlt.Location = new System.Drawing.Point(115, 207);
            this.txtBoxAlt.Name = "txtBoxAlt";
            this.txtBoxAlt.Size = new System.Drawing.Size(100, 31);
            this.txtBoxAlt.TabIndex = 2;
            // 
            // txtBoxLon
            // 
            this.txtBoxLon.Location = new System.Drawing.Point(115, 110);
            this.txtBoxLon.Name = "txtBoxLon";
            this.txtBoxLon.Size = new System.Drawing.Size(188, 31);
            this.txtBoxLon.TabIndex = 1;
            // 
            // txtBoxLat
            // 
            this.txtBoxLat.Location = new System.Drawing.Point(115, 35);
            this.txtBoxLat.Name = "txtBoxLat";
            this.txtBoxLat.Size = new System.Drawing.Size(188, 31);
            this.txtBoxLat.TabIndex = 0;
            // 
            // toolBar
            // 
            this.toolBar.Font = new System.Drawing.Font("Cambria", 12F);
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAppx,
            this.toolStripSeparator1,
            this.btnSnap,
            this.toolStripSeparator2,
            this.btnSettings});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1182, 30);
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
            this.btnAppx.Size = new System.Drawing.Size(79, 27);
            this.btnAppx.Text = "开始";
            this.btnAppx.ToolTipText = "点此开始";
            // 
            // btnStartGE
            // 
            this.btnStartGE.Name = "btnStartGE";
            this.btnStartGE.Size = new System.Drawing.Size(164, 28);
            this.btnStartGE.Text = "启动GE";
            this.btnStartGE.ToolTipText = "启动Google Earth实例";
            this.btnStartGE.Click += new System.EventHandler(this.btnStartGE_Click);
            // 
            // btnStopGE
            // 
            this.btnStopGE.Name = "btnStopGE";
            this.btnStopGE.Size = new System.Drawing.Size(164, 28);
            this.btnStopGE.Text = "关闭GE";
            this.btnStopGE.ToolTipText = "关闭Google Earth实例";
            this.btnStopGE.Click += new System.EventHandler(this.btnStopGE_Click);
            // 
            // btnExitApp
            // 
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(164, 28);
            this.btnExitApp.Text = "退出程序";
            this.btnExitApp.ToolTipText = "关闭窗口并退出程序";
            this.btnExitApp.Click += new System.EventHandler(this.btnExitApp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // btnSnap
            // 
            this.btnSnap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGESnap,
            this.btnAPISnap});
            this.btnSnap.Image = ((System.Drawing.Image)(resources.GetObject("btnSnap.Image")));
            this.btnSnap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(79, 27);
            this.btnSnap.Text = "截图";
            this.btnSnap.ToolTipText = "截取当前画面";
            // 
            // btnGESnap
            // 
            this.btnGESnap.Name = "btnGESnap";
            this.btnGESnap.Size = new System.Drawing.Size(153, 28);
            this.btnGESnap.Text = "GE截图";
            this.btnGESnap.ToolTipText = "Google Earth 内嵌截图(灰度图,但更稳定)";
            this.btnGESnap.Click += new System.EventHandler(this.btnGESnap_Click);
            // 
            // btnAPISnap
            // 
            this.btnAPISnap.Name = "btnAPISnap";
            this.btnAPISnap.Size = new System.Drawing.Size(153, 28);
            this.btnAPISnap.Text = "API截图";
            this.btnAPISnap.ToolTipText = "能截取彩色图像";
            this.btnAPISnap.Click += new System.EventHandler(this.btnAPISnap_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // btnSettings
            // 
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(70, 27);
            this.btnSettings.Text = "设置";
            this.btnSettings.ToolTipText = "参数设置";
            this.btnSettings.Click += new System.EventHandler(this.btnParamsSettings_Click);
            // 
            // GEDemo5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 855);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Cambria", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GEDemo5";
            this.Text = "GEDemo5";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.tabDocker.ResumeLayout(false);
            this.tabXPViewer.ResumeLayout(false);
            this.setCameraParameters.ResumeLayout(false);
            this.setCameraParameters.PerformLayout();
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
        private System.Windows.Forms.ToolTip msgToolTip;
        private System.Windows.Forms.GroupBox setCameraParameters;
        private System.Windows.Forms.Label label_LonExp;
        private System.Windows.Forms.Label label_LatExp;
        private System.Windows.Forms.Label label_Speed;
        private System.Windows.Forms.Label label_Azimuth;
        private System.Windows.Forms.Label label_Angle;
        private System.Windows.Forms.Label label_Range;
        private System.Windows.Forms.Label label_Altitude;
        private System.Windows.Forms.Label label_Longitude;
        private System.Windows.Forms.Label label_Latitude;
        private System.Windows.Forms.TextBox txtBoxSpd;
        private System.Windows.Forms.TextBox txtBoxAzm;
        private System.Windows.Forms.TextBox txtBoxAng;
        private System.Windows.Forms.TextBox txtBoxRng;
        private System.Windows.Forms.TextBox txtBoxAlt;
        private System.Windows.Forms.TextBox txtBoxLon;
        private System.Windows.Forms.TextBox txtBoxLat;
        private System.Windows.Forms.Button btnOKCamParams;
        private System.Windows.Forms.ToolStripButton btnSettings;
    }
}

